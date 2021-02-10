dotnet-k8s-prototype
===

Building
---
```sh
dotnet publish -c Release
podman build -t mrvl-dotnet-k8s-prototype -f Dockerfile .
podman-compose up
```

Running Single Container
---
```sh
podman run -d --name mrvl-dotnet-k8s-prototype -p 8080:80 mrvl-dotnet-k8s-prototype
```