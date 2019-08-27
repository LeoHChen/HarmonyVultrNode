# Harmony Vultr Node Guide

Automatic deployment guide for a Harmony Node running on Vultr. With following these steps you should have a node up running pretty fast. There seem to be some consensus that considering performance and bandwith, Vultr is the best or at least a very good choice.

The Vultr CLI is a command-line interface for managing Harmony Foundation or Pangaea Nodes. It is installed on your local computer/laptop, and will automatically create and update machines for you on Vultr.

Currently this tool only focus on the setup phase, so:
 - For pangaea follow this link after logging in to the VM:
  - https://docs.harmony.one/pangaea/setup-your-node-and-connect-to-pangaea/node-setup/advanced-users/vultr
  

# Prerequisites

- A Vultr Account:
  - <a href="https://www.vultr.com/?ref=8224844-4F" target="_blank">Sign up here</a> and receive a 50 dollar signing bonus which enables you to run Node for free some time ( and gets me :coffee:). The link will lead to the main page, just click on 'Create Account' . To enable the 50 dollar you need to deposit 10 dollar.
- Docker installed on your laptop/computer: see <a href="https://docs.docker.com/install/" target="_blank">https://docs.docker.com/install/</a>

# Content
* [How to run](#1how-to-run)
* [Manual Configuration](#1-manual-configuration)
* [Troubleshooting](#troubleshooting)

# 1. How to run

Once you installed Docker then run from the same directory:
```
docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:console
```
Or if you desire specify the directory in the command like and you can run the command on every location.
```
docker run -v /your/dir/data:/harmony/data --rm -it mwillems/harmony-vultr-node:console
```


# 2. FAQ
| Question        | Answer           |
| ------------- |:-------------:| 
| How to update? | docker pull  mwillems/harmony-vultr-node:console

# 3. Manual Configuration overrides
## Vultr Regions config 
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

# Troubleshooting
Nothing yet.
