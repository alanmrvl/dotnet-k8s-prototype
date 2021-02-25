#!/bin/sh

dotnet publish -c Release
podman build -t mrvl-dotnet-k8s-prototype -f Dockerfile .