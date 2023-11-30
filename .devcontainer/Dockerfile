FROM mcr.microsoft.com/vscode/devcontainers/dotnet:7.0

# COPY ./rootfs/certs/awn-corp-ca-bundle.pem /home/vscode/awn-corp-ca-bundle.pem
# COPY ./rootfs/certs/cert_AWN-Prisma-Root.pem /usr/local/share/ca-certificates/cert_AWN-Prisma-Root.crt
# RUN update-ca-certificates

# hadolint ignore=DL3008,DL3009,DL3015
RUN apt-get update \
    && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install curl zsh docker.io pandoc

# Bazel & Python compatibility
RUN ln /usr/bin/python3 /usr/bin/python

ARG BAZEL_BAZELISK_VERSION="v1.10.1"
ARG BAZEL_BUILDTOOLS_VERSION="4.2.4"
ARG BAZEL_BAZELISK_URL="https://github.com/bazelbuild/bazelisk/releases/download"
ARG BAZEL_BUILDTOOLS_URL="https://github.com/bazelbuild/buildtools/releases/download"
RUN curl -sSL "${BAZEL_BUILDTOOLS_URL}/${BAZEL_BUILDTOOLS_VERSION}/buildozer-linux-$(dpkg --print-architecture)" > /usr/local/bin/buildozer && \
    curl -sSL "${BAZEL_BUILDTOOLS_URL}/${BAZEL_BUILDTOOLS_VERSION}/buildifier-linux-$(dpkg --print-architecture)" >  /usr/local/bin/buildifier && \
    curl -sSL "${BAZEL_BAZELISK_URL}/${BAZEL_BAZELISK_VERSION}/bazelisk-linux-$(dpkg --print-architecture)" > /usr/local/bin/bazel && \
    chmod +x /usr/local/bin/bazel && \
    chmod +x /usr/local/bin/buildozer && \
    chmod +x /usr/local/bin/buildifier
