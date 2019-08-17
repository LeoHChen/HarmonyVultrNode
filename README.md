# Harmony Vultr Node Guide

Automic deployment guide for a Harmony Node running on Vultr. With following these steps you should have a node up running pretty fast.

The Vultr CLI is a command-line interface for managing Harmony Foundation or Pangaea Nodes. It is installed on your local computer/laptop, and will automatically create and update machines for you on Vultr.

# Prerequisites
- A Vultr Account, choose:
  - [Sign up here](https://www.vultr.com/?ref=8224844-4F)  and receive 50 dollar to run your node ~ 2,3 months but full disclaimer, its an affiliate link.
  - Or sign up [here](https://www.vultr.com) and receive 0 dollar.
- Docker installed on your laptop/computer: see https://docs.docker.com/install/
## 1. Installation 

There is no difference between Foundation or Pangaea nodes in this stage.

### 1.1 Download script
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

```

# 2 Config your Pangaea Node
```
./nodes.sh pangaea
```
Select yes if you want to launch a Pangaea node, or no if you dont want or no longer want to run a Pangaea node.

## 2.1 Finish the Pangaea Configuration
Get your keys with following this [guide](https://docs.harmony.one/pangaea/setup-your-node-and-connect-to-pangaea/pangaea-key-generation)

# 3 Config your Foundation Node

Select yes if you want to launch a Foundation node.

## 4. Starting your node(s)

Read [here](https://docs.harmony.one/pangaea/setup-your-node-and-connect-to-pangaea/node-setup/advanced-users/vultr#step-3-launching-your-vultr-node) about launching your node


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
