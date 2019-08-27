#!/bin/bash
echo ""
terraform init
terraform apply -var-file="data/terraform.tfvars" -auto-approve
