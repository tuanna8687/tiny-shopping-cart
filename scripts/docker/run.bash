#!/bin/bash

sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=sql2k8@123456' \
   -p 1433:1433 --name sqlServer2k8 \
   -d microsoft/mssql-server-linux:latest

echo SQl Server started!