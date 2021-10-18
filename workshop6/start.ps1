docker -v
docker rm -f ws-cli
echo "Starting ws-cli"
docker pull pnk8s101/ws-cli
docker run -d -v ${pwd}:/workspace -v ${pwd}/config:/root/.kube/config --name ws-cli pnk8s101/ws-cli
echo "Preparing kube config"
docker exec -ti ws-cli chmod 600 /root/.kube/config
echo "exec bash in ws-cli"
docker exec -ti ws-cli bash

# docker rm -f ws-cli