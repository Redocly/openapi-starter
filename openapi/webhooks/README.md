# Webhooks

This folder holds [webhook](https://spec.openapis.org/oas/v3.1.0.html#oas-webhooks)
definitions — operations your API *sends* to the consumer, rather than ones the
consumer calls. Webhooks are a top-level feature of OpenAPI 3.1.

Each file is a [Path Item Object](https://spec.openapis.org/oas/v3.1.0.html#path-item-object)
(the same shape as a file in `paths/`): it describes the HTTP method, the
request body your API will deliver, and the responses you expect back from the
consumer's endpoint.

Reference each webhook from the `webhooks` map in `openapi.yaml`, keyed by name:

```yaml
webhooks:
  order-notification:
    $ref: webhooks/order-notification.yaml
```

This starter ships one example, `order-notification.yaml`, fired when a new
order is placed.
