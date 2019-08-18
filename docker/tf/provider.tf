# Configure the Vultr Provider
provider "vultr" {
  api_key = "${var.vultr_api_key}"
  rate_limit = 700
}

variable "vultr_api_key"  {}
variable "vultr_pangaea_nodetype"  {}
variable "vultr_mainnet_nodetype"  {}
variable "vultr_region"  {}

output "mainnet-ips" {
  value = ["${vultr_server.harmony-mainnet-node.*.main_ip}"]
}
output "pangaea-ips" {
  value = ["${vultr_server.harmony-pangaea-node.*.main_ip}"]
}

variable "harmony_mainnet_count"  {
  default = "1"
}
variable "harmony_pangaea_count"  {
  default = "1"
}
