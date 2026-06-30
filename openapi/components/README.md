# Reusable components

Reusable [Component Objects](https://spec.openapis.org/oas/v3.1.0.html#components-object)
live here, one per file, and are pulled into paths and schemas with `$ref`.
Each subfolder maps to a component type.
You can add component-type folders as you need them:

* `schemas` - reusable [Schema Objects](https://spec.openapis.org/oas/v3.1.0.html#schema-object)
* `parameters` - reusable [Parameter Objects](https://spec.openapis.org/oas/v3.1.0.html#parameter-object)
* `responses` - reusable [Response Objects](https://spec.openapis.org/oas/v3.1.0.html#response-object)
* `examples` - reusable [Example Objects](https://spec.openapis.org/oas/v3.1.0.html#example-object)
* `headers` - reusable [Header Objects](https://spec.openapis.org/oas/v3.1.0.html#header-object)
* `requestBodies` - reusable [Request Body Objects](https://spec.openapis.org/oas/v3.1.0.html#request-body-object)
* `links` - reusable [Link Objects](https://spec.openapis.org/oas/v3.1.0.html#link-object)
* `callbacks` - reusable [Callback Objects](https://spec.openapis.org/oas/v3.1.0.html#callback-object)
* `securitySchemes` - reusable [Security Scheme Objects](https://spec.openapis.org/oas/v3.1.0.html#security-scheme-object)

The filename of each file is the component name, e.g. `MenuItem.yaml` is
referenced as `$ref: ../components/schemas/MenuItem.yaml`.
