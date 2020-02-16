#!/bin/bash

ApiToken="bd5feead5824afa4233c17bbb0542eaf746889b574fa447f1cb89e4474de2607"
IPNode1=""
Token=""



echo "Spinning up three droplets...."


for i in 1 2 3; 
  do

  docker-machine create \
        --driver digitalocean \
        --digitalocean-access-token $ApiToken \
          Node-$i;

  docker-machine env Node-$i
  eval $(docker-machine env Node-$i)
  done


echo "Initializing docker warm ......"

docker-machine ip Node-1 > $IPNode1

docker-machine ssh Node-1

docker swarm init --advertise-addr $IPNode1 | grep Token | awk '{print $5}' > $Token

exit

echo "Adding nodes to swarm"

for i in 2 3; 
  do
    docker-machine ssh Node-$i
     docker swarm join --token $Token IPNode1:2377
     exit
  done

echo "Initialization Complete ....."
