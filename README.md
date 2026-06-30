# OpenAPI Definition Starter

A starter for multi-file API definitions managed with the [Redocly CLI](https://redocly.com/docs/cli/). The bundled example is the [**Redocly Cafe** demo API](https://cafe.redocly.com/openapi/cafe).

## How to use this starter

![Click use template button](https://user-images.githubusercontent.com/3975738/92927304-12e35d80-f446-11ea-9bd3-a0f8a69792d0.png)

## Working on your OpenAPI Definition

### Install

1. Install [Node JS](https://nodejs.org/).
2. Clone this repo and run `npm install` in the repo root.

### Usage

#### `npm start`
Starts the reference docs preview server.

#### `npm test`
Validates the definition.

## Contribution Guide

Below is a sample contribution guide. The tools
in the repository don't restrict you to any
specific structure. Adjust the contribution guide
to match your own structure. However, if you
don't have a structure in mind, this is a
good place to start.

Update this contribution guide if you
adjust the file/folder organization.

The `redocly.yaml` controls settings for various
tools including the lint tool and the reference
docs engine.  Open it to find examples and
[read the docs](https://redocly.com/docs/cli/configuration/)
for more information.


### Schemas

#### Adding Schemas

1. Navigate to the `openapi/components/schemas` folder.
2. Add a file named as you wish to name the schema.
3. Define the schema.
4. Refer to the schema using the `$ref` (see example below).

##### Example Schema
This is a very simple schema example:
```yaml
type: string
description: Menu item ID. Unique identifier prefixed with `prd_`.
pattern: ^prd_[0-9abcdefghjkmnpqrstvwxyz]{26}$
example: prd_01h1s5z6vf2mm1mz3hevnn9va7
```
This is a more complex schema example. It uses `allOf` to compose a
`Beverage` from its own properties plus a shared `MenuBaseItem` schema:
```yaml
allOf:
  - type: object
    properties:
      category:
        description: Menu item category.
        type: string
        const: beverage
      volume:
        type: number
        description: Size of the beverage in milliliters.
        exclusiveMinimum: 0
      containsCaffeine:
        type: boolean
        description: Indicates if the beverage contains caffeine.
    required:
      - category
      - volume
      - containsCaffeine
  - $ref: ./MenuBaseItem.yaml
```

If you have an JSON example, you can convert it to JSON schema using Redocly's [JSON to JSON schema tool](https://redocly.com/tools/json-to-json-schema/).

##### Using the `$ref`

Notice in the complex example above the schema definition itself has `$ref` links to other schemas defined.

Here is a small excerpt with an example:

```yaml
page:
  $ref: ./Page.yaml
```

The value of the `$ref` is the path to the other schema definition.

You may use `$ref`s to compose schema from other existing schema to avoid duplication.

You will use `$ref`s to reference schema from your path definitions.

#### Editing Schemas

1. Navigate to the `openapi/components/schemas` folder.
2. Open the file you wish to edit.
3. Edit.

### Paths

#### Adding a Path

1. Navigate to the `openapi/paths` folder.
2. Add a new YAML file named like your URL endpoint except replacing `/` with `_` (or whichever character you prefer) and putting path parameters into curly braces like `{example}`.
3. Add the path and a ref to it inside of your `openapi.yaml` file inside of the `openapi` folder.

Example addition to the `openapi.yaml` file:
```yaml
'/menu/{menuItemId}':
  $ref: './paths/menu_{menuItemId}.yaml'
```

Here is an example of a YAML file named `menu_{menuItemId}.yaml` in the `paths` folder:

```yaml
parameters:
  - $ref: ../components/parameters/MenuItemId.yaml
delete:
  tags:
    - Products
  summary: Delete a menu item
  description: Delete an existing menu item.
  operationId: deleteMenuItem
  security:
    - OAuth2:
        - menu:write
  responses:
    '204':
      description: Menu item deleted successfully.
    '400':
      $ref: ../components/responses/BadRequest.yaml
    '401':
      $ref: ../components/responses/Unauthorized.yaml
    '403':
      $ref: ../components/responses/Forbidden.yaml
    '404':
      $ref: ../components/responses/NotFound.yaml
    '500':
      $ref: ../components/responses/InternalServerError.yaml
```

The top-level `parameters` list is shared across all HTTP methods in the file. You'll also see `$ref`s to reusable parameters and responses.

### Code samples

Automated code sample generation is enabled in the `redocly.yaml` configuration
file (`curl`, `Node.js`, `JavaScript`, `PHP`, and `Python`). Use the manual
`x-codeSamples` extension to add samples for languages the generator doesn't
cover (for example, C#) or to override a generated sample. To add one:

1. Navigate to the `openapi/code_samples` folder.
2. Navigate to the `<language>` sub-folder, then a `<path>` folder.
   The convention is `<language>/<path>/<HTTP verb>.<extension>`, where `<path>`
   replaces each `/` with `_`. For example, `GET /menu` lives at
   `C_sharp/menu/get.cs`.
3. Add the file, then reference it from the operation with `x-codeSamples`:

```yaml
x-codeSamples:
  - lang: C#
    label: C#
    source:
      $ref: ../code_samples/C_sharp/menu/get.cs
  - lang: PHP
    label: PHP
    source:
      $ref: ../code_samples/PHP/menu/get.php
```

You can add languages by adding new folders at the appropriate path level.

More details inside the `code_samples` folder README.
