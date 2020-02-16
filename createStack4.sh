#!/bin/bash

success=$?


if [ ${success} -eq 0 ];
then 
	eval $(docker-machine env Node-1) && \
 docker stack deploy --compose-file grid.yml grid

sleep 10
 else

 echo "Unable to create swarm"

 fi
