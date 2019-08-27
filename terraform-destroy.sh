#!/bin/bash
echo ""
terraform init
terraform destroy -var-file="data/terraform.tfvars"
