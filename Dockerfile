FROM mcr.microsoft.com/dotnet/aspnet:3.1

# add missing packages
RUN apt update -y && apt-get install -y libbrotli1 libmbedtls12 && apt-get clean

ARG APPNAME

COPY src/$APPNAME/bin/Release/netcoreapp3.1/publish/ App/

WORKDIR /App

ENV APPNAME=$APPNAME
RUN echo "dotnet $APPNAME.dll" > /run.sh

ENTRYPOINT ["/bin/sh", "/run.sh"]
