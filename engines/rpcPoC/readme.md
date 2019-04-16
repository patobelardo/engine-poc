# Overview

## Topics

- Timeout Created
- Engine-Controller (sidecar pattern)
    1. Allows to cancel when engines throws an error
    2. Allow other functionality (kill long running)
    3. Logging / Monitorings
- grpc - Intro

## Pendings

- Change Proto to represent an engine action - DONE
- Generate errors and long running scenarios to test - DONE  (http://localhost/api/work/error will generate an error at the engine)
- Add it to a pod (k8s) and see how it works
- Cancel reception event during current work (QoS) - DONE
- Concurrency - DONE
- Share the code
