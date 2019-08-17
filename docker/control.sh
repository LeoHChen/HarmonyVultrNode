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
    echo "Done generation new ssh keys, see data/ssh-keys directory"
}

function launch 
{
    terraform init
    terraform apply -var-file="data/terraform.tfvars" -auto-approve
}
function harmony-keys
{
    echo "Downloading wallet"
    mkdir -p /wallet
    cd /wallet
    curl -LO https://harmony.one/wallet.sh
    chmod 755 wallet.sh
    ./wallet.sh -d
    echo "Start making a new wallet"
    ./wallet.sh new
    echo "Done making a new wallet"
    echo "Start making a new BLS key pair"
    ./wallet.sh blsgen   
    ./wallet.sh list
    mv /wallet/.hmy/keystore/UTC* /harmony/data/harmony-keys/
    mv *.key /harmony/data/harmony-keys/
    echo "Done generation new keys, see data/harmony-keys directory"
    echo "Important: backup these keys"
}

function init
{
    mkdir -p /harmony/data/ssh-key/
    mkdir -p /harmony/data/harmony-keys/
    mkdir -p /harmony/data/mainnet/
    mkdir -p /harmony/data/pangaea/
    mkdir -p /harmony/data/state/
}

function initial
{
    echo "Created data directories"
    echo "Creating clean config file"
    cp -f  /harmony/terraform.tfvars /harmony/data/state/
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
init 

case $ACTION in

   harmony-keys)
         harmony-keys ;;
   initial)
         initial ;;
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