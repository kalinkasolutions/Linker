# Linker - A Minimalistic URL Shortener

**Linker** is a free, open-source, and minimalistic URL shortener built with .NET 9.0. Designed for simplicity and performance, it allows you to quickly shorten and share links.

The application is Dockerized and can be easily deployed behind a reverse proxy.

## Quick Start

To run the Linker service with Docker and Docker Compose, you can use the following `docker-compose.yml` configuration:

```yaml
version: "3"
services:
  linker:
    container_name: linker
    image: kalinkasolutions/linker:latest
    restart: always
    volumes:
      - ./data:/var/data
    ports:
      - 31333:8080
```
