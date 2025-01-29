### :tada: F&MD .Net Changelog :tada:

<img src="./docs/images/image.png">

## Installation

.Net Changelog can be installed through nuget

```shell
  nuget install Fmd.Net.Changelog
```

or

```shell
    dotnet add package Fmd.Net.Changelog --version 1.0.0
```

## Configuration

Add the following instructions in your Program.cs file

```csharp
//Add the path to the json file that will contain the changelog
builder.Services.AddChangelog(options =>
{
    options.JsonPath = Path.Combine(builder.Environment.WebRootPath, "json", "changelog.json");
});
```

```csharp
app.UseChangelog();
```

Add the json file to your project. The file should have the following structure:

```json
{
  "versions": [
    {
      "date": "28/01/2025",
      "changes": [
        {
          "type": "changed",
          "label": "ALTERAÇÃO",
          "icon": "lapis",
          "description": "Otimizamos a integração com a plataforma Contoso SA",
          "details": "O carregamento de dados agora é mais rápido"
        }
      ]
    }
  ]
}
```

## Customization

| Type     | Badge           |
|----------|-----------------|
| added    | badge-success   |
| changed  | badge-warning   |
| security | badge-security  |
| fix      | badge-fix       |
| default  | badge-secondary |

| Icon Name  | Icon                                               |
|------------|----------------------------------------------------|
| definicoes | <img src="./docs/icons/definicoes.svg" width="32"> |
| editar     | <img src="./docs/icons/editar.svg" width="32">     |
| exclamacao | <img src="./docs/icons/exclamacao.svg" width="32"> |
| foguete    | <img src="./docs/icons/foguete.svg" width="32">    |
| lapis      | <img src="./docs/icons/lapis.svg" width="32">      |
| like       | <img src="./docs/icons/like.svg" width="32">       |
| megafone   | <img src="./docs/icons/megafone.svg" width="32">   |
| trancar    | <img src="./docs/icons/trancar.svg" width="32">    |

## Usage

Access the path /changelog in your application and you are ready to go!




