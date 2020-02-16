#!/bin/bash



#update os
for i in 1 2 3; do
	echo "updating Node-$i"
    docker-machine ssh Node-$i 'apt-get update &&\ reboot '
done
 
sleep 10
