#!/bin/sh
if [ -z "${AMBASSADOR_URL}" ]; then
  AMBASSADOR_URL="http://localhost:9088"
fi
if [ -n "$1" ]; then
  random_num=$1
  curl -X POST -H 'Content-Type: application/json' -d "{\"random\":\"$random_num\"}" ${AMBASSADOR_URL}
fi
