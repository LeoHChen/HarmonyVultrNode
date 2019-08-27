#!/bin/bash
echo ""
echo "Downloading the Harmoney Wallet"
mkdir -p /wallet
cd /wallet
curl -LO https://harmony.one/wallet.sh
chmod 755 wallet.sh
./wallet.sh -d
echo "Create a new ECDSA account address"
./wallet.sh new
echo "Done creating a new ECDSA account address"
echo "Create a new BLS key pair"
./wallet.sh blsgen   
echo "Done creating a new BLS key pair"
echo ""
echo "Result:"
./wallet.sh list
cp /wallet/.hmy/keystore/UTC* /harmony/data/harmony-keys/
cp *.key /harmony/data/harmony-keys/
rm -f /harmony/data/mainnet/*
cp -f /wallet/.hmy/keystore/UTC* /harmony/data/mainnet/
cp -f *.key /harmony/data/mainnet/
echo "Done generation new keys, see the data/harmony-keys directory"
