# Interplayers Password Validator
Exemplo de código aplicando conceitos de arquitetura e testes automatizados.

## Execução
```
git clone https://github.com/vqalves/interplayers-password-validator.git
cd interplayers-password-validator
dotnet run --project Interplayers.WebAPI
```

### Documentação Swagger (apenas ambiente desenvolvimento)
```
GET http://localhost:5000/swagger
```

### Validate Password Request
```
POST http://localhost:5000/validate-password

Headers:
Content-Type application/json
Accept-Language pt,en

Payload:
{
	"Password": string
}
```

### Validate Password Response
#### StatusCode 200
#### StatusCode 401
```
Body:
{
    "Password": ["validation messages"]
}
```


## Caso de uso

### ValidatePassword

A validação da senha é feita executando um conjunto de regras de validação. Cada regra é uma classe que implementa `IPasswordRule`, e pode executar seu próprio algoritmo, permitindo que novas regras possam ser adicionadas sem afetar o fluxo do caso de uso.

As regras disponíveis estão encapsuladas dentro de `IPasswordRulesProvider`, permitindo que diferentes callers utilizem diferentes regras, sem afetar o caso de uso.

```mermaid
graph TD;
    ValidatePasswordHandler-->|consumes|IPasswordRulesProvider;
    IPasswordRulesProvider-->|contains collection of|IPasswordRule
    IPasswordRule-.->PasswordCharacterCountRule
    IPasswordRule-.->...
    IPasswordRule-.->PasswordLowerLetterCountRule
```

Para encapsulamento, foi criado o value object `Password`, que contém métodos relevantes para análise da senha, como `AmountOfLowerLetters`. Como as regras de validação estão desacopladas do objeto de senha e são arbitradas pelo caller, considerei que não há problemas instanciar um value object sem executar nenhum `IPasswordRule`.

Para a API, o `IPasswordRulesProvider` é implementado dentro de `Infrastructure`. A instanciação é realizada pelo `WebAPI`, que lê a configuração dentro de seu `appsettings.json`. Isso permite que as regras possam ser alteradas na API sem nenhuma alteração no código fonte.

Além de checar a validade da senha, cada `IPasswordRule` também pode retornar uma instância de `IPasswordValidationTranslatableMessage` com o tipo de inconsistência detectada e os dados relevantes na inconsistência, que pode ser formatado em uma mensagem através de uma implementação de `IPasswordValidationMessageLocale`.

Para a internacionalização (i18n), a `WebAPI` utiliza uma classe abstrata de `Language`, aonde cada linguagem pode implementar sua própria classe e ser registrada no `LanguageProvider`. O uso da classe abstrata obrigará as classes herdadas a sobreescreverem determinados os métodos, evitando erros de falta de tradução pelo sistema. O idioma é selecionado pelo `HttpLanguageDecider`, que analisa o header `Accept-Language` fornecido no HTTP.

Cada `Language` deve retornar uma implementação de `IPasswordValidationMessageLocale`, que exige que cada tipo de `IPasswordValidationTranslatableMessage` tenha uma mensagem de texto correspondente.

Esta estrutura permite uma i18n totalmente desacoplada do domínio, e torna fácil adicionar novos idiomas com efeito imediato nos usuários, já que é utilizada a parametrização inata do HTTP.

```mermaid
graph TD;
    HttpLanguageDecider-->|consumes|LanguageProvider;
    LanguageProvider-->|returns|Language
    Language-.->|implemented by|LanguageEnglish
    Language-.->|implemented by|LanguagePortuguese
    LanguageEnglish--->|contains|PasswordValidationMessageLocaleEnglish
    LanguagePortuguese--->|contains|PasswordValidationMessageLocalePortuguese
```

## Camadas
Camada | Descrição
-- | --
WebAPI | Gerencia endpoints, injeções de dependência, interpreta configurações e internalização, responsável pelo recebimento de payload HTTP e tradução do payload para uso dos serviços da `Application`
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
    Endpoint (WebAPI)->>WebAPI: format and return WebAPI IResult;
    WebAPI->>Client: HTTP Response
```