# .Net Core + C# + MongoDB

Esse é um pequeno projeto com exemplo de como utilizar o bando NoSQL MongoDB com C#.
O código-fonte está todo comentado com explicações de configurações básicas e as várias formas de mapeamento das classes para os objetos do banco.

## Instalação

Para rodar essa aplicação, deve-se ter instalado o MongoDB, .Net Core 3.1 e o Visual Studio Code, que podem ser obtidos nos respectivos links:


    https://docs.mongodb.com/manual/administration/install-community/

    https://dotnet.microsoft.com/download/dotnet-core/3.1

    https://code.visualstudio.com/download


## Utilização

Após baixar o fonte, abrir a pasta no Visual Studio Code e pressionar F5 (windows) para debugar


## Estrutura do Projeto

* src/Program.cs
  * Classe principal que será executada ao rodar ou debugar a aplicação
* src/Models/Pessoa.cs
  * Objeto principal que será armazenado no banco de dados
* src/Models/Endereco.cs
  * Classe utilizada para exemplificar como armazenar um objeto contido dentro de outro objeto
* src/Models/Telefone.cs
  * Classe utilizada para exemplificar como armazenar uma lista contida dentro de um objeto
* src/Models/TelefoneTipos.cs
  * Classe utilizada para exemplificar como armazenar um enumerador
* src/Data/AppDbContext.cs
  * Classe que contém toda a configuração do banco de dados assim como a instância do objeto utilizado para manipular os dados

## Resultado da execução

Após executar a aplicação, as seguintes linhas devem ser impressas no console
Note que o Id é impresso no formato do mongo devido a utilização do método de serialização para json do próprio driver do MongoDB ("_id" : ObjectId("5f3e803dc26133cc20b3bc72"))

```json
Id da pessoa inserida:
5f3e803dc26133cc20b3bc72

Pessoa selecionada:
{
  "_id" : ObjectId("5f3e803dc26133cc20b3bc72"),
  "nome" : "Pessoa teste",
  "salario" : "100.50",
  "endereco" : {
    "cep" : "17207000",
    "logradouro" : "Nome da rua da pessoa",
    "numero" : "123",
    "bairro" : "Bairro da pessoa",
    "cidade" : "Cidade da pessoa",
    "uf" : "SP"
  },
  "telefones" : [{
      "prefixo" : "14",
      "numero" : "9123456789",
      "tipo" : "Celular"
    }, {
      "prefixo" : "11",
      "numero" : "9987654321",
      "tipo" : "Comercial"
    }, {
      "prefixo" : "11",
      "numero" : "36251487",
      "tipo" : "Fixo"
    }]
}

Pessoa atualizada:
{
  "_id" : ObjectId("5f3e803dc26133cc20b3bc72"),
  "nome" : "Nome atualizado",
  "salario" : "100.50",
  "endereco" : {
    "cep" : "17207000",
    "logradouro" : "Nome da rua da pessoa",
    "numero" : "123",
    "bairro" : "Bairro da pessoa",
    "cidade" : "Cidade da pessoa",
    "uf" : "SP"
  },
  "telefones" : [{
      "prefixo" : "14",
      "numero" : "9123456789",
      "tipo" : "Celular"
    }, {
      "prefixo" : "11",
      "numero" : "9987654321",
      "tipo" : "Comercial"
    }, {
      "prefixo" : "11",
      "numero" : "36251487",
      "tipo" : "Fixo"
    }]
}

Lista de pessoas:
[{
    "_id" : ObjectId("5f3e803dc26133cc20b3bc72"),
    "nome" : "Nome atualizado",
    "salario" : "100.50",
    "endereco" : {
      "cep" : "17207000",
      "logradouro" : "Nome da rua da pessoa",
      "numero" : "123",
      "bairro" : "Bairro da pessoa",
      "cidade" : "Cidade da pessoa",
      "uf" : "SP"
    },
    "telefones" : [{
        "prefixo" : "14",
        "numero" : "9123456789",
        "tipo" : "Celular"
      }, {
        "prefixo" : "11",
        "numero" : "9987654321",
        "tipo" : "Comercial"
      }, {
        "prefixo" : "11",
        "numero" : "36251487",
        "tipo" : "Fixo"
      }]
  }]

Pessoa excluída com sucesso:
5f3e803dc26133cc20b3bc72

```
