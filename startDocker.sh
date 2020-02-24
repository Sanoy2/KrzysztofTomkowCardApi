#!/bin/bash

docker run -it --rm -p 5000:80 -v /home/krzysztof/CardApiFiles/:/files --name CardApiInstance cardapiapp
