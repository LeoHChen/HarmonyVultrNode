# Harmony Vultr Node Guide

Automatic deployment guide for a Harmony Node running on Vultr. With following these steps you should have a node up running pretty fast.

The Vultr CLI is a command-line interface for managing Harmony Foundation or Pangaea Nodes. It is installed on your local computer/laptop, and will automatically create and update machines for you on Vultr.

# Prerequisites
- A Vultr Account, choose:
  - [Sign up here](https://www.vultr.com/?ref=8224844-4F)  and receive 50 dollar to run your node ~ 2,3 months but full disclaimer, its an affiliate link.
  - Or sign up [here](https://www.vultr.com).
- Docker installed on your laptop/computer: see https://docs.docker.com/install/


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
Fresh ssh-keys will be generated which the tool uses to connect to the nodes, see the data/ssh-key/ directory output after running the command below. You should something like:

```
New SSH key will be generated in data/ssh-key
Generating public/private rsa key pair.
```

#### 1.2.2 The Vultr Personal Access Token
```
Enter your Vultr Personal Access Token:
```
To be able the created the required infrastructure you need to supply a the access token.

Follow [this guide](http://help.gridpane.com/en/articles/1991725-provision-a-vultr-instance-using-the-vultr-api) all the way till your Step 5. You should then have a an acces token to supply to the scripts.

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
Get your keys with following this [guide](https://docs.harmony.one/pangaea/setup-your-node-and-connect-to-pangaea/pangaea-key-generation)

Go into your unzipped keys folder and you will see two key files, place both keys in the data\pangaea directory. Those will be placed on the Pangaea node after the creation.

## 2.2 Create the node
```
./nodes.sh launch
```

The nodes should be created in a few minutes and should you end with 

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
Follow these [steps](https://docs.harmony.one/pangaea/setup-your-node-and-connect-to-pangaea/node-setup/advanced-users/vultr#step-3-launching-your-vultr-node) of the official guide. Most steps are already done but will shorten it some day.

tl;dr type this:
```
tmux new-session -s node
sudo ./node.sh -t
No passphrase so just press enter
First hit "Ctrl+b", then hit "d"
```

If you want to see the loggin again type
```
tmux a
```
to exit again
```
First hit "Ctrl+b", then hit "d"
```

# 3 Config your Foundation Node
```
./nodes.sh mainnet
```
Select yes if you want to launch a mainnet node, or No if you dont want or dont longer want to run a mainnet node.

```
./nodes.sh harmony-keys
```
This wil generate your harmony keys
.....




## 5. Starting your node(s)

Read [here](https://docs.harmony.one/pangaea/setup-your-node-and-connect-to-pangaea/node-setup/advanced-users/vultr#step-3-launching-your-vultr-node) about start the Harmony node


##Vultr Regions 


{
  "id": "1",
  "message": "New Jersey"
}
{
  "id": "2",
  "message": "Chicago"
}
{
  "id": "3",
  "message": "Dallas"
}
{
  "id": "4",
  "message": "Seattle"
}
{
  "id": "5",
  "message": "Los Angeles"
}
{
  "id": "6",
  "message": "Atlanta"
}
{
  "id": "39",
  "message": "Miami"
}


{
  "id": "12",
  "message": "Silicon Valley"
}
{
  "id": "40",
  "message": "Singapore"
}
{
  "id": "7",
  "message": "Amsterdam"
}
{
  "id": "25",
  "message": "Tokyo"
}
{
  "id": "8",
  "message": "London"
}
{
  "id": "24",
  "message": "Paris"
}
{
  "id": "9",
  "message": "Frankfurt"
}
{
  "id": "22",
  "message": "Toronto"
}
{
  "id": "19",
  "message": "Sydney"
}
