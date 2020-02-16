#!/bin/bash

export ApiToken="bd5feead5824afa4233c17bbb0542eaf746889b574fa447f1cb89e4474de2607"
export IPNode1=""
export Token=""



echo "Spinning up three droplets...."


for i in 1 2 3;
  do

  docker-machine create \
        --driver digitalocean \
        --digitalocean-access-token $ApiToken \
        --digitalocean-size "1gb" \
          Node-$i;

  docker-machine env Node-$i
  eval $(docker-machine env Node-$i)
  done
  
echo "Successfully created droplets"
echo $?
