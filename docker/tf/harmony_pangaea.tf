resource "vultr_server" "harmony-pangaea-node" {
  plan_id = "${var.vultr_nodetype}"
  region_id = "${var.vultr_region}"
  app_id = "37"
  label = "harmony-pangaea-${format("%02d", count.index + 1)}"
  enable_ipv6 = false
  auto_backup = false
  enable_private_network = false
  notify_activate = false
  ddos_protection = false
  firewall_group_id = "${vultr_firewall_group.fwg.id}"
  ssh_key_ids = ["${vultr_ssh_key.harmony-ssh-key.id}"]
  provisioner "file" {
    source      = "data/pangaea"
    destination = "/tmp"
  }

  provisioner "remote-exec" {
    inline = [
        "sudo apt update && sudo apt install -y wget tmux",
        "mkdir -p ~/.hmy/keystore",
        "wget https://harmony.one/wallet.sh && chmod u+x wallet.sh && ./wallet.sh -d",
        "wget https://raw.githubusercontent.com/harmony-one/harmony/587a29696a9bf7d77226c4b5699f495e39feb032/scripts/node.sh && chmod u+x node.sh",
        "mv /tmp/pangaea/UTC* ~/.hmy/keystore",
        "mv /tmp/pangaea/*.key ~"
    ]
  }

 
  count = "${var.harmony_pangaea_count}"
  connection {
    type = "ssh"
    host = "${element(vultr_server.harmony-pangaea-node.*.main_ip, count.index)}"
    user = "root"
    password = "${element(vultr_server.harmony-pangaea-node.*.default_password, count.index)}"
  }
}
