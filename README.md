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
### 1.3 Create your ssh-key
Fresh ssh-keys will be generated which the tool uses to connect to the nodes, see the data/ssh-key/ directory output after running the command below
```
./nodes.sh ssh-key
```

## 2. Configuring your node(s)

Start the config process with running this:
```
./nodes.sh config
```
### 2.1 The Vultr Personal Access Token

```
Enter your Vultr Personal Access Token:
```
To be able the created the required infrastructure you need to supply a the access token.

Follow [this guide](http://help.gridpane.com/en/articles/1991725-provision-a-vultr-instance-using-the-vultr-api) till your reach Step 5. You should then have a an acces token to supply to the scripts.

### 2.2 Select the type of Node(s) you want to run
```
Do you want to launch a Pangaea Node [y/n]?
```
Select yes if you want to launch a Pangaea node, and follow 2.2.1 to config this node, otherwise skip the section.

#### 2.2.1 Finish the Pangaea Configuration
Get your keys with following this [guide](https://docs.harmony.one/pangaea/setup-your-node-and-connect-to-pangaea/pangaea-key-generation)

```
Do you want to launch a Foundation (mainnet) Node [y/n]?
```
Select yes if you want to launch a Foundation node.


## 3. Create your node(s)


## 3. Starting your node(s)

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
