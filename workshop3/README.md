## 設定環境
首先把 kubectl 設定檔放到當前目錄，再執行以下指令  
Windows
```
docker run -d -v ${pwd}:/workspace -v ${pwd}/config:/root/.kube/config -ti --name helm pnk8s101/helm sleep 365d
docker exec -ti helm sh
```

Linux & Mac
```
docker run -d -v $(pwd):/workspace -v $(pwd)/config:/root/.kube/config -ti --name helm pnk8s101/helm sleep 365d
docker exec -ti helm sh
```

## MySQL 的 helm repo
ArtifactHub: [https://artifacthub.io/packages/helm/bitnami/mysql](https://artifacthub.io/packages/helm/bitnami/mysql)  
GitHub: [https://github.com/bitnami/charts/tree/master/bitnami/mysql](https://github.com/bitnami/charts/tree/master/bitnami/mysql)


# 關閉環境
```
docker rm -f helm
```