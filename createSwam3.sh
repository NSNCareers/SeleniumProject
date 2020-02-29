#!/bin/bash

success=$?


if [ ${success} -eq 0 ];
then 
	echo "Initializing Swarm mode..."
for i in 1 2 3; do
	if [ "$i" == "1" ]; then
        manager_ip=$(docker-machine ip Node-$i)
		eval $(docker-machine env Node-$i) && \
          docker swarm init --advertise-addr "$manager_ip"
        worker_token=$(docker swarm join-token worker -q)
	else
		eval $(docker-machine env Node-$i) && \
        docker swarm join --token "$worker_token" "$manager_ip:2377"
    fi
done

sleep 10

 else

 echo "Unable to update droplets"

 fi
