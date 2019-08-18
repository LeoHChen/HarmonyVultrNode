#!/bin/bash

function login-pangaea
{   
    terraform init
    echo "Determine ip of the pangaea node"    
    INSTANCE_IP=$(terraform output -state=data/state/tf.tfstate -json pangaea-ips | jq -r '.[0][0]')
    echo "Connection to $INSTANCE_IP"
    mkdir -p /keys
    cp /harmony/data/ssh-key/harmony /keys
    chmod 700 /keys/harmony
    ssh -i /keys/harmony root@$INSTANCE_IP
}
function login-mainnet
{   
    terraform init
    echo "Determine ip of the pangaea node"    
    INSTANCE_IP=$(terraform output -state=data/state/tf.tfstate -json pangaea-ips | jq -r '.[0][0]')
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
    echo "Done generation new ssh keys, see data/ssh-key directory"
}

function launch 
{
    PANGAEA_KEY_COUNT=$(grep 'harmony_pangaea_count = 1' data/terraform.tfvars  | wc -l)
    if [ $PANGAEA_KEY_COUNT -eq 1 ]
    then
        count=$(ls data/pangaea | wc -l)
        if [ $count -eq 0 ]
        then
            echo "Warning, the Pangaea keys are missing, copy them first to /data/pangaea directory"
            exit
        fi
    fi
    MAINNET_KEY_COUNT=$(grep 'harmony_mainnet_count = 1' data/terraform.tfvars  | wc -l)
    if [ $MAINNET_KEY_COUNT -eq 1 ]
    then
        count=$(ls data/mainnet | wc -l)
        if [ $count -eq 0 ]
        then
            echo "Warning, the Mainnet keys are missing, copy them first to /data/mainnet directory"
            exit
        fi
    fi
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


function install
{
    echo "Creating data directories and clean config file"
    mkdir -p /harmony/data/ssh-key/
    mkdir -p /harmony/data/harmony-keys/
    mkdir -p /harmony/data/mainnet/
    mkdir -p /harmony/data/pangaea/
    mkdir -p /harmony/data/state/
    cp -f  /harmony/terraform.tfvars /harmony/data/
    echo "Created data directories and clean config file"
    ssh-key 
    echo "Enter your Vultr Personal Access Token:"
    read VULTR_ACCESS_TOKEN
    echo "You entered: "$VULTR_ACCESS_TOKEN
    sed -i "/.*vultr_api_key.*/ c\vultr_api_key = \"$VULTR_ACCESS_TOKEN\"" data/terraform.tfvars

    echo "The initialization was succesfull!"
}

function pangaea
{
    echo "Do you want to launch a Pangaea Node [y/n]?"
    read AWSYES
    case $AWSYES in
        yY][eE][sS]|[yY])
         sed -i "/.*harmony_pangaea_count.*/ c\harmony_pangaea_count = 1" data/terraform.tfvars;;
        nN][oO]|[nN])
         sed -i "/.*harmony_pangaea_count.*/ c\harmony_pangaea_count = 0" data/terraform.tfvars;;
    esac
    echo "Pangaean status saved"
}

function mainnet
{
    echo "Do you want to launch a Foundation (mainnet) Node [y/n]?"
    read AWSYES
    case $AWSYES in
        yY][eE][sS]|[yY])
         sed -i "/.*harmony_mainnet_count.*/ c\harmony_mainnet_count = 1" data/terraform.tfvars;;
        nN][oO]|[nN])
         sed -i "/.*harmony_mainnet_count.*/ c\harmony_mainnet_count = 0" data/terraform.tfvars;;
    esac
    echo "All set"

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

   harmony-keys)
         harmony-keys ;;
   install)
         install ;;
   config)
         config ;;         
   launch)  
         launch ;;
   destroy )
         destroy ;;
   mainnet )
         mainnet ;;
   pangaea )
         pangaea ;;  
   login-pangaea)
         login-pangaea ;;
   login-mainnet)
         login-mainnet ;;
   ssh-key)
         ssh-key ;;
esac

exit 0  