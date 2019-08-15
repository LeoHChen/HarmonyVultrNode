FROM golang:alpine
ENV TERRAFORM_VERSION=0.12.6 

RUN echo "http://dl-cdn.alpinelinux.org/alpine/edge/testing" >> /etc/apk/repositories
RUN apk update && apk upgrade && \
    apk add --update jq  curl zip bash make git openssh 

# Install terraform
RUN curl -sSL https://releases.hashicorp.com/terraform/${TERRAFORM_VERSION}/terraform_${TERRAFORM_VERSION}_linux_amd64.zip -o /tmp/terraform.zip && \
    unzip /tmp/terraform.zip -d /usr/bin && \
    rm /tmp/terraform.zip && \
    apk del curl zip && \
    rm -rf /var/cache/apk/* 

RUN mkdir -p touch: /root/.ssh && \
    touch ~/.ssh/known_hosts && \
    chmod 777 ~/.ssh/known_hosts

RUN mkdir -p /harmony/terraform.d/plugins/linux_amd64

#Install vultr provider
RUN mkdir -p $GOPATH/src/github.com/vultr; cd $GOPATH/src/github.com/vultr && \
    git clone https://github.com/vultr/terraform-provider-vultr.git && \
    cd $GOPATH/src/github.com/vultr/terraform-provider-vultr && \
    make build && \
    ln -s $GOPATH/bin/terraform-provider-vultr /harmony/terraform.d/plugins/linux_amd64/terraform-provider-vultr 
ADD control.sh /harmony
RUN chmod 755 /harmony/control.sh
ADD tf /harmony
# RUN cd /harmony && terraform init
WORKDIR /harmony
ENTRYPOINT ["/harmony/control.sh"]
CMD [ "" ]