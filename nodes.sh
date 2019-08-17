#!/bin/bash

NODE_TYPE=""
function login
{   
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest login 
}

function ssh-key 
{
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest ssh-key
}


function launch 
{
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest launch
}

function harmony-keys
{
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest harmony-keys
}

function init
{
      docker pull mwillems/harmony-vultr-node:latest
}
function initial
{
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest initial
}

function destroy
{ 
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest destroy
}

ACTION=$1
if [ -z "$ACTION" ]; then
    ACTION=launch
fi
init 

case $ACTION in

   keys)
         keys ;;
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