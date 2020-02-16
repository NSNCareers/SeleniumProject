#!/bin/bash


#update os
success=$?


if [ ${success} -eq 0 ];
then 

for i in 1 2 3; do
	echo "updating Node-$i"
    docker-machine ssh Node-$i 'apt-get update &&\ reboot '
done

sleep 10
 else

 echo "Unable to create droplets"

 fi
