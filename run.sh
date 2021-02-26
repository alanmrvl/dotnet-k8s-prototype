#!/bin/sh

podman-compose down; ./build.sh; podman-compose up -d