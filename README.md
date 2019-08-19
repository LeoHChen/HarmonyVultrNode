# Harmony Vultr Node Guide

Automatic deployment guide for a Harmony Node running on Vultr. With following these steps you should have a node up running pretty fast. There seem to be some consensus that considering performance and bandwith, Vultr is the best or at least a very good choice.

The Vultr CLI is a command-line interface for managing Harmony Foundation or Pangaea Nodes. It is installed on your local computer/laptop, and will automatically create and update machines for you on Vultr.


# Prerequisites

- A Vultr Account:
  - <a href="https://www.vultr.com/?ref=8224844-4F" target="_blank">Sign up here</a> and receive a 50 dollar signing bonus which enables you to run your node ~3-4 months ( and gets me :coffee:).
- Docker installed on your laptop/computer: see <a href="https://docs.docker.com/install/" target="_blank">https://docs.docker.com/install/</a>

# Content
* [Installation](#1-installation)
* [Config your Pangaea Node](#2-config-your-pangaea-node)
* [Config your Foundation Node](#3-config-your-foundation-node)
* [Migrate your Foundation Node to Vultr](#4-migrate-your-foundation-node-)
* [Migrate your Foundation Node to Vultr](#4-migrate-your-foundation-node-)


## 1. Installation 

There is no difference between Foundation or Pangaea nodes in this stage.

### 1.1 Download the script
```
wget https://raw.githubusercontent.com/MarkWillems/HarmonyVultrNode/master/nodes.sh && chmod 755 ./nodes.sh
```
### 1.2 Create and setup directories
```
./nodes.sh install
```
The will download the required software and start the initialization.


### 1.2.1 SSH keys
Fresh ssh-keys will be generated which is used to connect to the Harmony nodes, see the data/ssh-key/ directory after running the command below. You should something like:

```
New SSH key will be generated in data/ssh-key
Generating public/private rsa key pair.
```
These can also be used in Windows, follow the 
<a href="https://devops.ionos.com/tutorials/use-ssh-keys-with-putty-on-windows/" target="_blank">here</a>. You need the select data/ssh-key/harmony as private key 

#### 1.2.2 The Vultr Personal Access Token
```
Enter your Vultr Personal Access Token:
```
To be able the created the required infrastructure you need to supply a the access token.

Follow <a href="http://help.gridpane.com/en/articles/1991725-provision-a-vultr-instance-using-the-vultr-api)" target="_blank">this guide</a> all the way till your Step 5. You should then have a an acces token to supply to the scripts.

```
The initialization was succesfull!
``` 
As it says, you are done. Now setup your Pangaea Node or Mainnet Node


# 2 Config your Pangaea Node
```
./nodes.sh pangaea
```
Select yes if you want to launch a Pangaea node, or No if you dont want or dont longer want to run a Pangaea node.


## 2.1 Configure keys of the Pangaea Node
Get your keys with following this <a href="https://docs.harmony.one/pangaea/setup-your-node-and-connect-to-pangaea/pangaea-key-generation" target="_blank">guide</a>

Go into your unzipped keys folder and you will see two key files, place both keys in the data\pangaea directory. Those will be placed at the correct location on the Pangaea node during the creation.

## 2.2 Create the node
```
./nodes.sh launch
```

The actually creates the nodes and it should be created in a few minutes and should you end with something like.

```
Outputs:

mainnet-ips = [
  [],
]
pangaea-ips = [
  [
    "45.32.221.8",
  ],
]

```
In this example the pangaea node IP address is 45.32.221.8, and can be reached now.

## 2.2 Login the nodes
```
./nodes.sh login-pangaea
```
This will connect your to the node, press yes for establishing identity.

## 2.3 Start the node software
Follow these <a href="hhttps://docs.harmony.one/pangaea/setup-your-node-and-connect-to-pangaea/node-setup/advanced-users/vultr#step-3-launching-your-vultr-node" target="_blank">steps</a> of the official guide. Most steps are already done but will shorten it some day. 

For now this is the short version:
```
tmux new-session -s node
sudo ./node.sh -t
No passphrase so just press enter
First hit "Ctrl+b", then hit "d"
```

If you want to attach the node logging again type:
```
tmux a
```
to exit then again
```
First hit "Ctrl+b", then hit "d"
```

# 3 Config your Foundation Node
```
./nodes.sh mainnet
```
Select yes if you want to launch a mainnet node, or No if you dont want or dont longer want to run a mainnet node.

## 3.1 Create the Harmony keys
```
./nodes.sh harmony-keys
```
This wil generate your new Harmony keys in the data/harmony-keys/ directory, follow the guide <a href="https://nodes.harmony.one/foundational-node-playbook/setting-up-your-node/vultr-setup#step-2-connecting-to-your-vultr-node" target="_blank">here</a> starting from the sentence "Create a BLS key pair with..." with what they are and what to do with it. Make sure to backup them and send the email!

## 3.2 Create the node
```
./nodes.sh launch
```
This generates the actuale node, the node should be created in a few minutes and finishes with an output like below

```
Outputs:

mainnet-ips = [
 [
    "45.32.221.8",
  ],
]
pangaea-ips = [
   [],
]

```
In this example the Foundation node IP address is 45.32.221.8, and can be reached now with your public keys or generated password visible in the Vult portal.

```
./nodes.sh login-mainnet
```
Follow <a href="https://nodes.harmony.one/foundational-node-playbook/setting-up-your-node/vultr-setup#step-3-launching-your-node" target="_blank">these</a> steps to start the node.

tl;dr type this:
```
tmux new-session -s node
sudo ./node.sh
Enter your passphrase which you choose in the previous steps.
First hit "Ctrl+b", then hit "d"
```

If you want to attach the node logging again type:
```
tmux a
```

to exit then again
```
First hit "Ctrl+b", then hit "d"
```



## 4. Migrate your existing Foundation Node

1. Follow the installation of [Step 1. Installation] (#1-installation)
2. Run the following command and select y.
```
./nodes.sh mainnet
```
3. Then copy both your Harmony keys to data/harmony-keys directory on your laptop/computer
4. Start the actual Node generation
```
./nodes.sh launch
```
The nodes should be created in a few minutes and should you end with and output like below

```
Outputs:

mainnet-ips = [
 [
    "45.32.221.8",
  ],
]
pangaea-ips = [
   [],
]

```
In this example the Foundation node IP address is 45.32.221.8, and can be reached now with your public keys or generated password visible in the Vult portal.

5. Read [here](https://docs.harmony.one/pangaea/setup-your-node-and-connect-to-pangaea/node-setup/advanced-users/vultr#step-3-launching-your-vultr-node) about start the Harmony node
6. Let the new Node sync.
7. Destroy old the node when the sync is finished on the new Vultr Node.

# 5. Manual Configuration
## Vultr Regions config 
[link](http://www.google.nl){:target="_blank"}
As default the node is deployed to Seatle, this can be changed by altering the vultr_region in the data/terraform.tfvars apply.

| Id        | Region           |
| ------------- |:-------------:| 
| 1 | New Jersey 
| 2 | Chicago
| 3 | Dalles
| 4 | Seatle
| 5 | Los Angelos
| 6 | Atlanta
| 7 | Amsterdam
| 8 | London
| 9 | Frankfurt
| 12 | Silicon Valley
| 19 | Sydney
| 22 | Toronto
| 24 | Paris
| 25 | Tokyo
| 39 | Miami 
| 40 | Singaport 
| 10 | 

# Troubleshooting
Nothing yet.
