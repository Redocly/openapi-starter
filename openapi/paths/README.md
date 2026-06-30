# Paths

Organize your path definitions within this folder. Reference each path from the root `openapi.yaml`:

```yaml
paths:
  /menu:
    $ref: paths/menu.yaml
  /menu/{menuItemId}:
    $ref: paths/menu_{menuItemId}.yaml
```

It may help you to adopt some conventions:

* path separator token (e.g. `_`) or subfolders
* path parameter (e.g. `{menuItemId}`)
* file-per-path or file-per-operation

There are different benefits and drawbacks to each decision.

You can adopt any organization you wish. We have some tips for organizing paths based on common practices.

## Each path in a separate file

Use a predefined "path separator" and keep all of your path files in the top level of the `paths` folder.

```
├── menu.yaml
├── menu_{menuItemId}.yaml
├── orders.yaml
└── orders_{orderId}.yaml
```

Redocly recommends using the `_` character for this case.

In addition, Redocly recommends placing path parameters within `{}` curly braces if you adopt this style.

#### Motivations

* Quickly see a list of all paths. Many people think in terms of the "number" of "endpoints" (paths), and not the "number" of "operations" (paths × HTTP methods).

* Only the "file-per-path" option is semantically correct with the OpenAPI Specification 3.1.0. However, [Redocly CLI](https://redocly.com/docs/cli/) will build valid bundles for any of the other options too.

#### Drawbacks

* This may require multiple operation definitions within a single file.
* It requires settling on a path separator (that is allowed to be used in filenames) and sticking to that convention.

## Each operation in a separate file

You may also place each operation in a separate file.

### Files at top-level of `paths`

You may name your files with some concatenation for the HTTP method. For example, following a convention such as: `<path with allowed separator>-<http-method>.yaml`.

#### Motivations

* Quickly see all operations without needing to navigate subfolders.

#### Drawbacks

* Adopting an unusual path separator convention, instead of using subfolders.

### Use subfolders to mirror API path structure

In this case, the path is defined within subfolders which mirror the API URL structure:

```
/menu/{menuItemId} → paths/menu/{menuItemId}.yaml
```

Referenced from `openapi.yaml`:

```yaml
paths:
  /menu/{menuItemId}:
    $ref: paths/menu/{menuItemId}.yaml
```

#### Motivations

It matches the URL structure.

It is pretty easy to reference:

```yaml
paths:
  /menu/{menuItemId}:
    $ref: paths/menu/{menuItemId}.yaml
```

#### Drawbacks

If you have a lot of nested folders, it may be confusing to reference your schemas. For example, from `paths/menu/{menuItemId}.yaml` you need two levels of `../` to reach components:

```yaml
responses:
  '404':
    $ref: ../../components/responses/NotFound.yaml
```

For deeper paths the chain grows longer, and while [Redocly CLI](https://redocly.com/docs/cli/) suggests possible refs when there is a mistake, it is still a net drawback for APIs with deep paths.
