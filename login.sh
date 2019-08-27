#!/bin/bash
mkdir -p /keys
cp /harmony/data/ssh-key/harmony /keys
chmod 700 /keys/harmony
ssh -o StrictHostKeyChecking=no -i /keys/harmony root@$1
rm -rf /keys