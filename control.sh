#!/bin/bash

NODE_TYPE=""
function login
{   
    terraform init
    echo "Determine ip of $NODE_TYPE node"    
    INSTANCE_IP=$(terraform output -state=data/state/tf.tfstate -json $NODE_TYPE-ips | jq -r '.[0][0]')
    echo "Connection to $INSTANCE_IP"
    mkdir -p /keys
    cp /harmony/data/ssh-key/harmony /keys
    chmod 700 /keys/harmony
    ssh -i /keys/harmony root@$INSTANCE_IP
}

function ssh-key 
{
    echo "New SSH key will be generated in data/ssh-key"
    mkdir -p "/harmony/data/ssh-key/"
    ssh-keygen -N '' -f /harmony/data/ssh-key/harmony
}

function launch 
{
    terraform init
    terraform apply -var-file="data/terraform.tfvars" -auto-approve
}

function destroy
{ 
    terraform init
    terraform destroy -var-file="data/terraform.tfvars"  
}

ACTION=$1
if [ -z "$ACTION" ]; then
    ACTION=launch
fi

case $ACTION in
 
   launch)  
         launch ;;
   destroy )
         destroy ;;
   login)
         NODE_TYPE=$2
         login ;;
   ssh-key)
         ssh-key ;;
esac

exit 0