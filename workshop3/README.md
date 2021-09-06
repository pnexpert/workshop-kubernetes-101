## 設定環境
首先把 kubectl 設定檔放到當前目錄，再執行以下指令  
Windows
```
docker run -d -v ${pwd}:/workspace -v ${pwd}/config:/root/.kube/config -ti --name helm asia-east1-docker.pkg.dev/pentitum-sre/workshop/helm sleep 365d
docker exec -ti helm sh
```

Linux & Mac
```
docker run -d -v $(pwd):/workspace -v $(pwd)/config:/root/.kube/config -ti --name helm asia-east1-docker.pkg.dev/pentitum-sre/workshop/helm sleep 365d
docker exec -ti helm sh
```

# 關閉環境
```
docker rm -f helm
```