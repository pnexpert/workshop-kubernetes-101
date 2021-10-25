# build with buildx command:
# docker buildx build --platform linux/amd64,linux/arm/v7,linux/arm64,linux/arm/v6 -t <IMAGE> --push .
FROM --platform=$BUILDPLATFORM alpine:3.14 AS base

ARG TARGETPLATFORM
ARG BUILDPLATFORM
ARG HELM_TAG=v3.6.3
ARG KUBECTL_TAG=v1.19.12
ARG FLUX_VERSION=0.17.1

RUN apk add curl

FROM --platform=$BUILDPLATFORM base AS helm
# modify from https://raw.githubusercontent.com/helm/helm/master/scripts/get-helm-3
RUN case ${TARGETPLATFORM} in \
  "linux/amd64")    ARCH="amd64";  ;; \
  "linux/arm/v6")   ARCH="arm";  ;; \
  "linux/arm/v7")   ARCH="arm";  ;; \
  "linux/arm64/v8") ARCH="arm64";   ;; \
  "linux/arm64") ARCH="arm64";   ;; \
  esac && \
  curl -o helm.tar.gz https://get.helm.sh/helm-${HELM_TAG}-linux-${ARCH}.tar.gz && \
  tar -xf helm.tar.gz && \
  mv linux-${ARCH}/helm /usr/bin/helm && \
  chmod +x /usr/bin/helm && \
  rm -rf linux-${ARCH} helm.tar.gz


FROM --platform=$BUILDPLATFORM base AS kubectl
# reference: https://www.downloadkubernetes.com/
RUN case ${TARGETPLATFORM} in \
  "linux/amd64")    ARCH="amd64";  ;; \
  "linux/arm/v6")   ARCH="arm";  ;; \
  "linux/arm/v7")   ARCH="arm";  ;; \
  "linux/arm64/v8") ARCH="arm64";   ;; \
  "linux/arm64") ARCH="arm64";   ;; \
  esac && \
  curl -o /usr/bin/kubectl -L https://dl.k8s.io/release/${KUBECTL_TAG}/bin/linux/${ARCH}/kubectl && \
  chmod +x /usr/bin/kubectl


FROM --platform=$BUILDPLATFORM base AS flux
# reference: https://github.com/fluxcd/flux2/releases
RUN case ${TARGETPLATFORM} in \
  "linux/amd64")    ARCH="amd64";  ;; \
  "linux/arm/v6")   ARCH="arm";  ;; \
  "linux/arm/v7")   ARCH="arm";  ;; \
  "linux/arm64/v8") ARCH="arm64";   ;; \
  "linux/arm64") ARCH="arm64";   ;; \
  esac && \
  curl -o flux.tar.gz -L https://github.com/fluxcd/flux2/releases/download/v${FLUX_VERSION}/flux_${FLUX_VERSION}_linux_${ARCH}.tar.gz && \
  tar xf flux.tar.gz && \
  mv flux /usr/bin/flux && \
  chmod +x /usr/bin/flux && \
  rm -rf flux.tar.gz


FROM alpine:3.14
WORKDIR /workspace
ENV PS1 "\[\e[1;32m\]/\W \[\e[1;34m\]# \[\e[0m\]"
COPY --from=kubectl /usr/bin/kubectl /usr/bin/kubectl
COPY --from=helm /usr/bin/helm /usr/bin/helm
COPY --from=flux /usr/bin/flux /usr/bin/flux
RUN apk add bash bash-completion jq curl
RUN echo 'source /etc/profile.d/bash_completion.sh' >> ~/.bashrc && \
    echo 'source <(kubectl completion bash)' >> ~/.bashrc && \
    echo 'command -v flux >/dev/null && . <(flux completion bash)' >> ~/.bashrc
CMD ["sleep", "365d"]