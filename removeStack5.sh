#!/bin/bash


docker-machine rm Node-1 Node-2 Node-3 -y

success=$?

if [ ${success} -eq 0 ];
then 
 echo "successfully removed stack"
 else

 echo "Unable to remove stack"

 fi
