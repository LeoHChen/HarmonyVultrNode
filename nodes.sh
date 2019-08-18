#!/bin/bash

function login-pangaea
{   
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest login-pangaea
}
function login-mainnet
{   
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest login-mainnet
}

function ssh-key 
{
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest ssh-key
}
function pangaea 
{
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest pangaea
}
function mainnet
{
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest mainnet
}

function launch 
{
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest launch
}

function config 
{
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest config
}

function harmony-keys
{
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest harmony-keys
}

function init
{
      docker pull mwillems/harmony-vultr-node:latest
}

function install
{
      docker run -v ${PWD}/data:/harmony/data --rm -it mwillems/harmony-vultr-node:latest install
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

   harmony-keys)
         harmony-keys ;;
   install)
         install ;;
   init)
         init ;;
   config)
         config ;;
   launch)  
         launch ;;
   mainnet)  
         mainnet ;;
   pangaea)  
         pangaea ;;
   destroy )
         destroy ;;
   login-pangaea)
         login-pangaea ;;
   login-mainnet)
         login-mainnet ;;
   ssh-key)
         ssh-key ;;
esac

exit 0