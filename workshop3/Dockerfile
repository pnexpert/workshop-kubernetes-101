# build with buildx command:
# docker buildx build --platform linux/amd64,linux/arm/v7,linux/arm64,linux/arm/v6,linux/ppc64le,linux/s390x -t <IMAGE> --push .
FROM --platform=$BUILDPLATFORM alpine:3.14 AS build

ARG TARGETPLATFORM
ARG BUILDPLATFORM
ARG HELM_TAG=v3.6.3
ARG KUBECTL_TAG=v1.19.12

RUN apk add curl

# modify from https://raw.githubusercontent.com/helm/helm/master/scripts/get-helm-3
RUN ARCH=$(uname -m) && \
    case $ARCH in \
        armv5) ARCH="armv5"; ;; \
        armv6) ARCH="armv6"; ;; \
        armv7) ARCH="arm"; ;; \
        aarch64) ARCH="arm64"; ;; \
        x86) ARCH="386"; ;; \
        x86_64) ARCH="amd64"; ;; \
        i686) ARCH="386"; ;; \
        i386) ARCH="386"; ;; \
    esac && \
    curl -o helm.tar.gz https://get.helm.sh/helm-${HELM_TAG}-linux-${ARCH}.tar.gz && \
    tar -xf helm.tar.gz && \
    mv linux-${ARCH}/helm /usr/bin/helm && \
    chmod +x /usr/bin/helm && \
    rm -rf linux-${ARCH} helm.tar.gz

# reference: https://www.downloadkubernetes.com/
RUN case ${TARGETPLATFORM} in \
         "linux/386")      ARCH="386";  ;; \
         "linux/amd64")    ARCH="amd64";  ;; \
         "linux/arm/v6")   ARCH="arm";  ;; \
         "linux/arm/v7")   ARCH="arm";  ;; \
         "linux/arm64/v8") ARCH="arm64";   ;; \
         "linux/arm64") ARCH="arm64";   ;; \
         "linux/ppc64le")  ARCH="ppc64le";   ;; \
         "linux/s390x")    ARCH="s390x";   ;; \
    esac && \
    curl -o /usr/bin/kubectl -L https://dl.k8s.io/release/${KUBECTL_TAG}/bin/linux/${ARCH}/kubectl && \
  chmod +x /usr/bin/kubectl

FROM alpine:3.14
WORKDIR /workspace
COPY --from=build /usr/bin/kubectl /usr/bin/kubectl
COPY --from=build /usr/bin/helm /usr/bin/helm
CMD ["sleep", "365d"]