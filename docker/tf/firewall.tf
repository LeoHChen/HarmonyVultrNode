resource "vultr_ssh_key" "my_ssh_key" {
  name = "my-ssh-key"
 ssh_key = file("/harmony/data/ssh-key/harmony.pub")
}

resource "vultr_firewall_group" "fwg" {
  description = "harmony-fwg"
}

resource "vultr_firewall_rule" "ssh" {
  firewall_group_id = "${vultr_firewall_group.fwg.id}"
  protocol = "tcp"
  network = "0.0.0.0/0"
  from_port = "22"
}

resource "vultr_firewall_rule" "harmony_6000" {
  firewall_group_id = "${vultr_firewall_group.fwg.id}"
  protocol = "tcp"
  network = "0.0.0.0/0"
  from_port = "6000"
}

resource "vultr_firewall_rule" "harmony_9000" {
  firewall_group_id = "${vultr_firewall_group.fwg.id}"
  protocol = "tcp"
  network = "0.0.0.0/0"
  from_port = "9000"
}

resource "vultr_firewall_rule" "harmony_9999" {
  firewall_group_id = "${vultr_firewall_group.fwg.id}"
  protocol = "tcp"
  network = "0.0.0.0/0"
  from_port = "9999"
}

resource "vultr_firewall_rule" "harmony_14555" {
  firewall_group_id = "${vultr_firewall_group.fwg.id}"
  protocol = "tcp"
  network = "0.0.0.0/0"
  from_port = "14555"
}