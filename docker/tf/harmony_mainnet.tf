resource "vultr_server" "harmony-mainnet-node" {
  plan_id = "${var.vultr_mainnet_nodetype}"
  region_id = "${var.vultr_region}"
  app_id = "37"
  label = "harmony-mainnet-node${format("%02d", count.index + 1)}"
  enable_ipv6 = false
  auto_backup = false
  enable_private_network = false
  notify_activate = false
  ddos_protection = false
  firewall_group_id = "${vultr_firewall_group.fwg.id}"
  ssh_key_ids = ["${vultr_ssh_key.harmony-ssh-key.id}"]
  provisioner "file" {
    source      = "data/mainnet"
    destination = "/tmp"
  }

  provisioner "remote-exec" {
    inline = [
        "sudo apt update && sudo apt install -y wget tmux",
        "mkdir -p ~/.hmy/keystore",
        "wget https://harmony.one/wallet.sh && chmod u+x wallet.sh && ./wallet.sh -d",
        "curl -LO https://harmony.one/node.sh && chmod u+x node.sh",
        "mv /tmp/mainnet/UTC* ~/.hmy/keystore",
        "mv /tmp/mainnet/*.key ~"
    ]
  }

 
  count = "${var.harmony_mainnet_count}"
  connection {
    type = "ssh"
    host = "${element(vultr_server.harmony-mainnet-node.*.main_ip, count.index)}"
    user = "root"
    password = "${element(vultr_server.harmony-mainnet-node.*.default_password, count.index)}"
  }
}
