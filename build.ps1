#!/bin/sh

dotnet publish -c Release
docker build -t mrvl-dotnet-k8s-prototype-webapi  --build-arg APPNAME="Prototype.WebApi"  -f Dockerfile .
docker build -t mrvl-dotnet-k8s-prototype-backend --build-arg APPNAME="Prototype.Backend" -f Dockerfile .