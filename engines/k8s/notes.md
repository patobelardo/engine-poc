# Setup rabbitmq

## Prepare yaml file

````yaml
# To install:
# helm install stable/rabbitmq --name my-rabbit --namespace rabbit -f rabbit-values.yam

replicas: 3

rbacEnabled: false

service:
  type: NodePort

# SPECIAL NOTE to the stable/rabbitmq chart authors: The chart currently has a
# slight problem in svc.yaml where the service.nodePort is being applied to the
# wrong port. Instead of applying the NodePort to named _amqp_ port, it should be
# applied to the port name _stats_ (the manager ui port).
#  nodePort: 31000

rabbitmq:
  username: guest
  password: guest
````

## Install rabbit

````
helm install stable/rabbitmq --name my-rabbit --namespace rabbit -f rabbit-values.yaml
````

## output

````
NAME:   orbiting-catfish
E0405 11:50:25.312196   20956 portforward.go:363] error copying from remote stream to local connection: readfrom tcp4 127.0.0.1:57066->127.0.0.1:57070: write tcp4 127.0.0.1:57066->127.0.0.1:57070: write: broken pipe
LAST DEPLOYED: Fri Apr  5 11:50:24 2019
NAMESPACE: default
STATUS: DEPLOYED

RESOURCES:
==> v1/ConfigMap
NAME                              DATA  AGE
orbiting-catfish-rabbitmq-config  2     0s

==> v1/Pod(related)
NAME                         READY  STATUS             RESTARTS  AGE
orbiting-catfish-rabbitmq-0  0/1    ContainerCreating  0         0s

==> v1/Role
NAME                                       AGE
orbiting-catfish-rabbitmq-endpoint-reader  0s

==> v1/RoleBinding
NAME                                       AGE
orbiting-catfish-rabbitmq-endpoint-reader  0s

==> v1/Secret
NAME                       TYPE    DATA  AGE
orbiting-catfish-rabbitmq  Opaque  2     0s

==> v1/Service
NAME                                TYPE       CLUSTER-IP   EXTERNAL-IP  PORT(S)                                AGE
orbiting-catfish-rabbitmq           ClusterIP  10.0.165.99  <none>       4369/TCP,5672/TCP,25672/TCP,15672/TCP  0s
orbiting-catfish-rabbitmq-headless  ClusterIP  None         <none>       4369/TCP,5672/TCP,25672/TCP,15672/TCP  0s

==> v1/ServiceAccount
NAME                       SECRETS  AGE
orbiting-catfish-rabbitmq  1        0s

==> v1beta2/StatefulSet
NAME                       READY  AGE
orbiting-catfish-rabbitmq  0/1    0s


NOTES:

** Please be patient while the chart is being deployed **

Credentials:

    Username      : user
    echo "Password      : $(kubectl get secret --namespace default orbiting-catfish-rabbitmq -o jsonpath="{.data.rabbitmq-password}" | base64 --decode)"
    echo "ErLang Cookie : $(kubectl get secret --namespace default orbiting-catfish-rabbitmq -o jsonpath="{.data.rabbitmq-erlang-cookie}" | base64 --decode)"

RabbitMQ can be accessed within the cluster on port  at orbiting-catfish-rabbitmq.default.svc.cluster.local

To access for outside the cluster, perform the following steps:

To Access the RabbitMQ AMQP port:

    kubectl port-forward --namespace default svc/orbiting-catfish-rabbitmq 5672:5672
    echo "URL : amqp://127.0.0.1:5672/"

To Access the RabbitMQ Management interface:

    kubectl port-forward --namespace default svc/orbiting-catfish-rabbitmq 15672:15672
    echo "URL : http://127.0.0.1:15672/"


````

Followed [this](https://www.katacoda.com/javajon/courses/kubernetes-applications/rabbitmq)

````
URL : amqp://10.240.0.5:31118/
````