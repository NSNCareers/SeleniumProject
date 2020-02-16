#!/bin/bash


 eval $(docker-machine env Node-1) && \
 docker stack deploy --compose-file grid.yml grid

sleep 10
