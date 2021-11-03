#!/bin/sh

if [ "${ENV}" == "prod" ]; then
  python3 prod-server.py
else
  python3 dev-server.py
fi
