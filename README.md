# SGPI

### **SGPI.Application:**

#### Executando a Aplicação Localmente

#### Passos para configuração e execução:

1. Da raiz do projeto, navegue até o diretório ***src/SGPI.Application***
2. Localize o arquivo [appsettings.json](src/SGPI.Application/appsettings.json)
   e [appsettings.Development.json](src/SGPI.Application/appsettings.Development.json)
3. Preencha as variáveis de ambiente nos arquivos conforme o exemplo abaixo:
    ```json
    {         
      "ConnectionStrings": {
        "AppDb": "Server=localhost;Username=admin;Database=postgres;Port=5432;Password=123;LogParameters=true;"
      }
    }
    ```
4. Execute as migrações existentes:
    1. Certifique-se de estar no diretório raiz do projeto (***src/SGPI.Application***) e execute o comando abaixo:
       ```shell
       dotnet ef database update
       ```
    2. Aguarde a mensagem de sucesso:
       ```
       Done.
       ```
5. Faça o ***build*** da aplicação:
   ```shell
   dotnet build
   ```
6. Execute a aplicação:
   ```shell
   dotnet run -c Release
   ```
7. Abra o seu navegador e acesse a seguinte URL: [http://localhost:5042](http://localhost:5042).

### **SGPI.NotifyInvest.Job**

#### Executando a Aplicação Localmente

#### Passos para configuração e execução:

1. Da raiz do projeto, navegue até o diretório ***jobs/SGPI.NotifyInvest.Job***:
   ```shell
   cd jobs/SGPI.NotifyInvest.Job
   ```
2. Localize o arquivo [appsettings.json](jobs/SGPI.NotifyInvest.Job/appsettings.json)
   e [appsettings.Development.json](jobs/SGPI.NotifyInvest.Job/appsettings.Development.json)
3. Preencha as variáveis de ambiente nos arquivos conforme o exemplo abaixo, completando as variáveis em branco:
    - Preencha ***Recipient*** com nome e e-mail do **administrador**.
       ```json
       {
         "ConnectionStrings": {
           "AppDb": ""
         },
         "MailSendClient": {
           "Url": "",
           "Token": "",
           "Name": "SGPI",
           "Email": ""
         },
         "MailSenderSMTP": {
           "Host": "smtp.mailersend.net",
           "Port": 587,
           "Username": "",
           "Password": "",
           "Name": "SGPI",
           "Email": ""
         },
         "Recipient": {
           "Name": "",
           "Email": ""
         }
       }
       ```

3. Execute as migrações existentes:
    1. Certifique-se de de executar as migrações, caso já tenha executado ignore essa etapa:
       ```shell
       dotnet ef database update -p ../../src/SGPI.Application/SGPI.Application.csproj -s ../../src/SGPI.Application/
       ```
    2. Aguarde a mensagem de sucesso:
       ```
       Done.
       ```
4. Faça o ***build*** da aplicação:
   ```shell
   dotnet build
   ```
5. Execute a aplicação:
   ```shell
   dotnet run -c Release
   ```

### Executando a Aplicação via Docker

1. Configurando o servico **sgpi.application**:
    1. Na raiz do projeto, localize o arquivo ***[docker-compose.yml](docker-compose.yml)***.
    2. No bloco de ***services***, encontre a definição para **sgpi.application**.
    3. Dentro de ***environment*** para **sgpi.application**, adicione a variável de ambiente:
       ```yaml
       environment:
         - ConnectionStrings__AppDb=Server=sgpi.database;Username=admin;Database=postgres;Port=5432;Password=123;LogParameters=true;
       ```
2. Configurando o servico **sgpi.notifyinvest.job**:
    1. No bloco de ***services***, encontre a definição para **sgpi.notifyinvest.job**.
    2. Dentro de ***environment*** para **sgpi.notifyinvest.job**, preencha as variáveis de ambiente em branco:
        - Preencha ***Recipient__Name*** e ***Recipient__Email*** com nome e e-mail do **administrador**.
           ```yaml
           environment:
             - ConnectionStrings__AppDb=Server=sgpi.database;Username=admin;Database=postgres;Port=5432;Password=123;LogParameters=true;
             - MailSendClient__Url= https://api.mailersend.com
             - MailSendClient__Token=
             - MailSendClient__Name=SGPI
             - MailSendClient__Email=
             - MailSenderSMTP__Host=smtp.mailersend.net
             - MailSenderSMTP__Port=587
             - MailSenderSMTP__Username=
             - MailSenderSMTP__Password=
             - MailSenderSMTP__Name=SGPI
             - MailSenderSMTP__Email=
             - Recipient__Name=
             - Recipient__Email=
           ```
3. Execute o comando abaixo para construir e iniciar os contêineres:
   ```shell
   docker-compose up -d
   ```
   Este comando irá baixar e criar as imagens necessárias para rodar a aplicação em segundo plano.
4. Para verificar os _container_ rodando, execute o seguindo comando:
   ```shell
   docker ps
   ```

# API de Gestão de Produto Financeiro

Esta documentação fornece uma visão geral de como usar a API de Gestão de Produto Financeiro. Siga os passos abaixo para
executar os endpoints disponíveis. Você pode utilizar **cURL** ou a [coleção](postman/SGPI.postman_collection.json) do 
**Postman** para fazer as requisições.

**Nota 1:**

- Para execução local, utilize a URL base: `http://localhost:5042`.
- Para execução em container, utilize a URL base: `http://localhost:8080`.

**Nota 2:**
- [Documentação para importação de coleções do Postman](https://learning.postman.com/docs/getting-started/importing-and-exporting/importing-data/)

## Endpoints Disponíveis

### 1. Criação de Produto

Para criar um produto financeiro, utilize o seguinte endpoint:

```sh
curl --location 'http://localhost:5042/api/products' \
--header 'accept: */*' \
--header 'Content-Type: application/json' \
--data '{
  "name": "Nome do produto",
  "type": "Tipo 1",
  "value": 10,
  "maturityDate": "2024-12-25T00:00:00.000Z",
  "interestRate": 10
}'
```

### 2. Visualização de Produtos

Para visualizar todos os produtos criados, utilize o endpoint:

```sh
curl --location 'http://localhost:5042/api/products' \
--header 'accept: */*'
```

Para visualizar os detalhes de um produto específico, substitua `{{id-do-produto}}` pelo ID do produto desejado:

```sh
curl --location 'http://localhost:5042/api/products/{{id-do-produto}}' \
--header 'accept: */*'
```

### 3. Editando Produto

Para editar um produto, utilize o endpoint abaixo, substituindo `{{id-do-produto}}` pelo ID do produto que deseja
editar:

```sh
curl --location --request PUT 'http://localhost:5042/api/products/{{id-do-produto}}' \
--header 'accept: */*' \
--header 'Content-Type: application/json' \
--data '{
  "name": "Nome Editado",
  "type": "Tipo Editado",
  "value": 100,
  "maturityDate": "2024-12-31T00:00:00.000Z",
  "interestRate": 100
}'
```

### 4. Excluindo Produto

Para excluir um produto, utilize o endpoint abaixo, substituindo `{{id-do-produto}}` pelo ID do produto que deseja
excluir:

```sh
curl --location --request DELETE 'http://localhost:5042/api/products/{{id-do-produto}}' \
--header 'accept: */*'
```

## Comprando e Vendendo Investimentos

### Comprando Investimento

Certifique-se de que um produto financeiro foi criado. Para comprar um investimento, substitua `{{id-do-produto}}` pelo
ID do produto que deseja comprar:

```sh
curl --location 'http://localhost:5042/api/products/purchase' \
--header 'accept: */*' \
--header 'Content-Type: application/json' \
--data '{
  "financialProductId": "{{id-do-produto}}",
  "clientId": 1,
  "quantity": 1
}'
```

### Vendendo Investimento

Certifique-se de que um produto financeiro foi criado. Para vender um investimento, substitua `{{id-do-produto}}` pelo
ID do produto que deseja vender:

```sh
curl --location 'http://localhost:5042/api/products/sell' \
--header 'accept: */*' \
--header 'Content-Type: application/json' \
--data '{
  "financialProductId": {{id-do-produto}},
  "clientId": 1,
  "quantity": 1
}'
```

### Visualizando Extrato

Para visualizar o extrato e ver os registros de transações financeiras, substitua `{{id-do-cliente}}` pelo ID do cliente
utilizado nas operações de compra e/ou venda:

```sh
curl --location 'http://localhost:5042/api/extract/{{id-do-cliente}}?transactionType=1' \
--header 'accept: */*'
```

- 1: Extrato apenas de compras.
- 2: Extrato apenas de vendas.
- Sem especificação: Extrato de todas as transações.

---

Siga esses passos para gerenciar produtos financeiros e realizar operações de compra e venda utilizando a API.
Certifique-se de substituir os placeholders (`{{id-do-produto}}`, `{{id-do-cliente}}`) pelos valores apropriados.

- # Referência

- https://www.milanjovanovic.tech/blog/how-to-structure-minimal-apis
- https://www.youtube.com/watch?v=GCuVC_qDOV4&ab_channel=MilanJovanovi%C4%87
- https://code-maze.com/benchmarking-csharp-and-asp-net-core-projects/
- https://github.com/jasontaylordev/CleanArchitecture/blob/main/src/Infrastructure/Data/Interceptors/AuditableEntityInterceptor.cs#L36C5-L36C51
- https://crontab.guru/