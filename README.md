<!-- TOC titleSize:2 tabSpaces:4 depthFrom:1 depthTo:6 withLinks:1 updateOnSave:1 orderedList:0 skip:0 title:1 charForUnorderedList:* -->
## Table of Contents
* [About](#about)
* [k3s/k3d](#k3sk3d)
    * [Project description](#project-description)
    * [Single node k3s](#single-node-k3s)
    * [k3d multi-node cluster](#k3d-multi-node-cluster)
        * [Installation](#installation)
        * [Deployment](#deployment)
        * [Cluster Management](#cluster-management)
        * [Local registry](#local-registry)
* [Serverless Application Model (AWS SAM)](#serverless-application-model-aws-sam)
    * [Project description](#project-description)
    * [Setup](#setup)
    * [Testing](#testing)
* [Xamarin](#xamarin)
    * [Project description](#project-description)
    * [Issues](#issues)
    * [Further steps](#further-steps)
<!-- /TOC -->

# About
Repo for the coding exercises and trying new technologies.

# k3s/k3d
## Project description
Simple k3s/k3d with kubernetes dashboard.

## Single node k3s
Installation can be done by issuing `curl -sfL https://get.k3s.io | sh -` command.

In order to allow writing to kubeconfig, following command should be used:
```
curl -sfL https://get.k3s.io | sh -s - --write-kubeconfig-mode 644
```
This will add this option to the systemd service:
```
ExecStart=/usr/local/bin/k3s \
       server \
       '--write-kubeconfig-mode' \
       '644'
```

In order to deploy/upgrade dashboard, run `deploy.sh` shell script.
To access the dashboard, create a secure channel by running:
```
k3s kubectl proxy
```

## k3d multi-node cluster
Multi node installation using k3d, which uses k3s under the hood.

### Installation
Installation can be accomplished by running:
```
wget -q -O - https://raw.githubusercontent.com/rancher/k3d/main/install.sh | bash
```

Create new 3 nodes k3d cluster by executing:
```
k3d cluster create devcluster \
--servers 3 \
--api-port localhost:6444 \
-p 80:80@loadbalancer
```

Export config:
```
k3d kubeconfig get devcluster > ~/.k3d/kubeconfig-devcluster.yaml
export KUBECONFIG=~/.k3d/kubeconfig-devcluster.yaml
```
Or, alternatively:
```
export KUBECONFIG=$(k3d kubeconfig write devcluster)
```

After that test access to the cluster by running:
```
kubectl config use-context k3d-devcluster
kubectl cluster-info
```

### Deployment
Deploy nginx:
```
kubectl apply -f nginx/nginx.yaml
```

Test nginx being available over http:
```
curl http://localhost
```

### Cluster Management
To list running pods:
```
kubectl get pods
```

To run commands in the pod:
```
kubectl exec -it nginx-7848d4b86f-j28df -- bash
```

### Local registry

`k3d` can create dedicated docker registry if `--registry-create` is used.
One of the disadvantages of this solution is that registry port will be randomly
mapped to the host.

So, in case cluster is created using following command:
```
k3d cluster create devcluster --registry-create
```

Run `docker ps -f 'name=k3d-devcluster-registry'` in order to figure out mapped
port.

More scalable solution is to run registry separately. Then you won't have to
push images every time cluster is re-deployed, as well as keep port static.
Use following command to create registry:
```
k3d registry create registry.localhost --port 12345
```
NOTE: `k3d` adds `k3d-` prefix to all created resources, so registry name will
be: `k3d`

In order to simplify name resolution, one could install `nss-myhostname`
(`libnss-myhostname` for some distris). Do not forget to modify
`/etc/nsswitch.conf` to include `myhostname` to `hosts:` line, e.g.:
```
hosts:  files mdns_minimal [NOTFOUND=return] dns myhostname
```

Alternative is to simply add entry to `/etc/hosts`:
```
127.0.0.1   k3d-registry.localhost
```

Tag existing image and push to the created registry:
```
docker pull nginx:latest
docker tag nginx:latest k3d-registry.localhost:12345/nginx:latest
docker push k3d-registry.localhost:12345/nginx:latest
```

After that, it can be used in the manifest file (see k3s/nginx/nginx_localregistry.yaml):
```
...
spec:
  containers:
  - name: nginx
    image: k3d-registry.localhost:12345/nginx:latest
    ports:
    - containerPort: 80
      protocol: TCP
```

After that, you can point k3d to this registry with
`--registry-use k3d-registry.localhost:12345` option:
```
k3d cluster create devcluster \
--registry-use k3d-registry.localhost:12345
```

In case you want point k3s to your local registry, simply use `--registry-config`
flag see (k3s/registries.yaml).
```
k3d cluster create devcluster \
--registry-config registries.yaml
```
This is handy in case you want to use same manifest file as for production, and
use dev pods available in the local mirror.

# Serverless Application Model (AWS SAM)
## Project description
Idea of the project is to get familiar with serverless applications in aws.

Installation of sam on linux is available [here](https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/serverless-sam-cli-install-linux.html).

## Setup
After that run `sam init` command to setup the project using template.

I've chosen template in ruby.

Simple helloworld app in go, can be started locally by running `sam local start-api`.

After that, access the service with `http://127.0.0.1:3000/hello`

## Testing
In order to test application, we can create event and trigger it.
To generate event, following command can be used:
```
sam local generate-event apigateway aws-proxy --body "" --path "hello" --method GET
```
It can be saved as json and then used to test the application.
This can be achieved by running:
```
sam local invoke "HelloWorldFunction" -e events/event.json
```
Same structure can be used to define event in the unit tests and pass it to
the handler method in order to test the input.

Unit tests can be executed same way as for normal ruby app:
```
ruby tests/unit/test_handler.rb
```

As of now, tests are not using RSpec, therefore are just executable files.



# Xamarin
## Project description
Project uses Xamarin.Forms framework to develop an app for android and UWP platforms.
Developed application contains 3 fields for the side lengths of the triangle and returns
type of the triangle using simple label.
MVC pattern was used for the application. UI tests use classical PageObject software
design pattern.
NUnit was chosen as a framework for UI and unit tests, as provides rich functionality
for the fixtures and data driven testing.

## Issues
Multiple issues were faced during the project:
* UWP application behavior differs from Android and first control which is focusable gets focused on the app start. In our case, this is text field. It causes the issue that placeholder for the text field is not visible on the app start. Issue doesn't occur on android platform. Solution proposed on stack overflow was to use invisible controls, which will get the focus in this case. Therefore, seems that case of truly cross-platform UI application is not a common use-case and Xamarin is commonly use for Android/iOS applications.
* Newer versions of the Andoid API have issues with `Xamarin.UITest` testing methods, namely `EnterText` and `ClearText`. Only API versions >= 29 are affected. See https://github.com/microsoft/appcenter/issues/1451 . Github issue desribes the workaround for the `EnterText`. `ClearText` though, works only by setting empty string to the text field.
* When executing UITest on android, multiple times HttpRequestException was thrown, and no controls were detected. Root cause of the issue was not identified. I've tried not to restart the application before each test case, but it didn't resolve the issue. After further chanegs to the project, the issue was resolved. Likely this happened due to big numer of the test scenarios, which was reduced after covering more cases as unit tests. See https://github.com/xamarin/xamarin-android/issues/4721 .

## Further steps
* Project is created using Visual Studio Community Edition and misses easy way to build the project and execute tests.
* App is very basic and doesn't use any of the async events handling features.
* Project doesn't use `Model` functionality Xamarin provides for the interaction with the database.
* UI tests are developed for the Android only.
* Testing framework missing wrappers to wait for the conditions to become true.
