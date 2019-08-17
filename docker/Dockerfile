FROM ubuntu:latest
ENV TERRAFORM_VERSION=0.12.6 
ENV GO_VERSION=1.12.7

RUN apt-get update -y
RUN apt-get install -y jq ca-certificates curl zip wget make git 
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
ADD control.sh /harmony
ADD terraform.tfvars /harmony
RUN chmod 755 /harmony/control.sh
ADD tf /harmony
RUN cd /harmony && terraform init
WORKDIR /harmony
ENTRYPOINT ["/harmony/control.sh"]
CMD [ "" ]