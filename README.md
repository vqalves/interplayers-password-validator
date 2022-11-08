# Interplayers Password Validator
Exemplo de código aplicando conceitos de arquitetura e testes automatizados.

## Execução
```
git clone https://github.com/vqalves/interplayers-password-validator.git
cd interplayers-password-validator
dotnet run --project Interplayers.WebAPI
```

```
POST http://localhost:5000/validate-password

Payload (JSON):
{
	"password": "string"
}
```

## Caso de uso

### ValidatePassword

A validação da senha é feita executando um conjunto de regras de validação. Cada regra é uma classe que implementa `IPasswordRule`, e pode executar seu próprio algoritmo, permitindo que novas regras possam ser adicionadas sem afetar o fluxo do caso de uso.

Além de checar a validade da senha, cada regra também indica qual a mensagem que corresponde com a regra, permitindo devolver mensagens customizadas para o caller.

As regras disponíveis estão encapsuladas dentro de `IPasswordRulesProvider`, permitindo que diferentes callers utilizem diferentes regras, sem afetar o caso de uso.

```mermaid
graph TD;
    ValidatePasswordHandler-->IPasswordRulesProvider;
    IPasswordRulesProvider-->IPasswordRule
    IPasswordRule-.->PasswordCharacterCountRule
    IPasswordRule-.->...
    IPasswordRule-.->PasswordLowerLetterCountRule
```

Para encapsulamento, foi criado o value object `Password`, que contém métodos relevantes para análise da senha, como `AmountOfLowerLetters`. Como as regras de validação estão desacopladas do objeto de senha e são arbitradas pelo caller, considerei que não há problemas instanciar um value object sem executar nenhum `IPasswordRule`.

Para a API, o `IPasswordRulesProvider` é implementado dentro de `Infrastructure`. A instanciação é realizada pelo `WebAPI`, que lê a configuração dentro de seu `appsettings.json`. Isso permite que as regras possam ser alteradas na API sem nenhuma alteração no código fonte.

## Camadas
Camada | Descrição
-- | --
WebAPI | Gerencia endpoints, injeções de dependência, interpreta configurações, recebimento de payload e tradução do payload para uso dos serviços da `Application`
Application | Libera serviços que coordenam o fluxo de cada um dos casos de uso e executa as regras de negócio especificadas em `Domain`
Infrastructure | Implementa lógicas e estruturas que estão correlacionados com entidades externas, por exemplo arquivos de configuração
Domain | Especifica entidades, objetos e regras de negócio relativas ao domínio

## Árvore de Dependências
```mermaid
graph TD;
    WebAPI-->Infrastructure;
    WebAPI-->Application;
    WebAPI-->Domain;
    Infrastructure-->Domain;
    Application-->Domain
```

## Exemplo de fluxo da arquitetura

### Configuração e startup
```mermaid
sequenceDiagram
    WebAPI->>WebAPI: reads appsettings.json
    WebAPI->>Infrastructure: feed settings data
    Infrastructure->>WebAPI: returns object instances
    WebAPI->>WebAPI: feed dependency injector
```

### Processamento de HTTP POST
```mermaid
sequenceDiagram
    Client->>WebAPI: HTTP POST;
    WebAPI->>Endpoint (WebAPI): hydrate payload & dependency injection;
    Endpoint (WebAPI)->>UseCase Handler (Application): call using translated Data model; 
    UseCase Handler (Application)-->>Domain: apply business rules;
    UseCase Handler (Application)->>Endpoint (WebAPI): returns Result model;
    Endpoint (WebAPI)->>WebAPI: returns WebAPI IResult;
    WebAPI->>Client: HTTP Response
```