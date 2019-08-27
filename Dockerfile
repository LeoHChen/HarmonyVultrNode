FROM ubuntu:latest
ENV TERRAFORM_VERSION=0.12.6 
ENV GO_VERSION=1.12.7

RUN apt-get update -y
RUN apt-get install -y jq ca-certificates curl zip wget make git apt-utils

# RUN curl -SL -o dotnet.tar.gz https://dotnetcli.blob.core.windows.net/dotnet/Sdk/master/dotnet-sdk-latest-linux-arm64.tar.gz && \
#     sudo mkdir -p /usr/share/dotnet && \
#     sudo tar -zxf dotnet.tar.gz -C /usr/share/dotnet && \
#     sudo ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet
# Install .NET CLI dependencies
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        libc6 \
        libgcc1 \
        libgssapi-krb5-2 \
        libicu60 \
        libssl1.1 \
        libstdc++6 \
        zlib1g \
    && rm -rf /var/lib/apt/lists/*

# Install .NET Core SDK
ENV DOTNET_SDK_VERSION 3.0.100-preview8-013656
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

RUN curl -SL --output dotnet.tar.gz https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$DOTNET_SDK_VERSION/dotnet-sdk-$DOTNET_SDK_VERSION-linux-x64.tar.gz \
    && dotnet_sha512='448c740418f0ab43b3a8d9f7ccb532e71e590692d3b64239c3f21d46df3a46788b5b824e1a10236e5abe51d4a5143c27b90d08b342a683c96bd9abebc2d33017' \
    && echo "$dotnet_sha512 dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -zxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

# Go
RUN wget https://dl.google.com/go/go${GO_VERSION}.linux-amd64.tar.gz && \
    tar -xvf go${GO_VERSION}.linux-amd64.tar.gz && \
    mv go /usr/local && \
    rm go${GO_VERSION}.linux-amd64.tar.gz && \
    apt-get clean

ENV GOROOT=/usr/local/go
ENV GOPATH=/root/go 
ENV PATH=$GOPATH/bin:$GOROOT/bin:$PATH

# Install terraform
RUN curl -sSL https://releases.hashicorp.com/terraform/${TERRAFORM_VERSION}/terraform_${TERRAFORM_VERSION}_linux_amd64.zip -o /tmp/terraform.zip && \
    unzip /tmp/terraform.zip -d /usr/bin && \
    rm /tmp/terraform.zip 

RUN mkdir -p touch: /root/.ssh && \
    touch ~/.ssh/known_hosts && \
    chmod 777 ~/.ssh/known_hosts

RUN mkdir -p /harmony/terraform.d/plugins/linux_amd64

# #Install vultr provider
RUN mkdir -p $GOPATH/src/github.com/vultr; cd $GOPATH/src/github.com/vultr && \
    git clone https://github.com/vultr/terraform-provider-vultr.git && \
    cd $GOPATH/src/github.com/vultr/terraform-provider-vultr && \
    make build && \
    ln -s $GOPATH/bin/terraform-provider-vultr /harmony/terraform.d/plugins/linux_amd64/terraform-provider-vultr 
ADD wallet-create.sh /harmony
RUN chmod 755 /harmony/wallet-create.sh
ADD terraform-apply.sh /harmony
RUN chmod 755 /harmony/terraform-apply.sh
ADD terraform-destroy.sh /harmony
RUN chmod 755 /harmony/terraform-destroy.sh
ADD login.sh /harmony
RUN chmod 755 /harmony/login.sh
ADD terraform.tfvars /harmony
ADD tf /harmony
RUN cd /harmony && terraform init
WORKDIR /harmony

RUN mkdir -p /harmony-vultr-cli/
ADD harmony-vultr-cli/ /tmp/harmony-vultr-cli/
RUN cd /tmp/harmony-vultr-cli/ && \
    dotnet publish -c release -r ubuntu.18.04-x64 && \
    cp -r /tmp/harmony-vultr-cli/harmony-vultr-cli/bin/Release/netcoreapp3.0/ubuntu.18.04-x64/publish/* /harmony-vultr-cli/ && \
    rm -rf /tmp/harmony-vultr-cli

ENTRYPOINT ["/harmony-vultr-cli/harmonyVultrCli"]
CMD [ "" ]