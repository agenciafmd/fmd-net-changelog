### :tada: F&MD .Net Changelog :tada:

<img src="./docs/images/image.png">

## Installation

.Net Changelog can be installed through nuget

```shell
  nuget install Fmd.Net.Changelog
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

| Icon Name  | Icon                                      |
|------------|-------------------------------------------|
| definicoes | <img src="./docs/icons/definicoes.svg">   |
| editar     | <img src="./docs/icons/editar.svg">       |
| exclamacao | <img src="./docs/icons/exclamacao.svg">   |
| foguete    | <img src="./docs/icons/foguete.svg">      |
| lapis      | <img src="./docs/icons/lapis.svg">        |
| like       | <img src="./docs/icons/like.svg">         |
| megafone   | <img src="./docs/icons/megafone.svg">     |
| trancar    | <img src="./docs/icons/trancar.svg">      |

## Usage

Access the path /changelog in your application and you are ready to go!




