# SGPI

### **SGPI.Application:**
#### Executando a Aplicação Localmente
#### Passos para configuração e execução:

1. Da raiz do projeto, navegue até o diretório ***src/SGPI.Application***
2. Localize o arquivo [appsettings.json](src/SGPI.Application/appsettings.json)
3. Adicione a variável de ambiente no arquivo conforme o exemplo abaixo:
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
2. Localize o arquivo [appsettings.json](jobs/SGPI.NotifyInvest.Job/appsettings.json) da **SGPI.NotifyInvest.Job** e preencha as variáveis de ambiente em branco:
   
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
   
- # Referência

- https://www.milanjovanovic.tech/blog/how-to-structure-minimal-apis
- https://www.youtube.com/watch?v=GCuVC_qDOV4&ab_channel=MilanJovanovi%C4%87
- https://code-maze.com/benchmarking-csharp-and-asp-net-core-projects/
- https://github.com/jasontaylordev/CleanArchitecture/blob/main/src/Infrastructure/Data/Interceptors/AuditableEntityInterceptor.cs#L36C5-L36C51
- https://crontab.guru/



1. Na raiz do projeto, localize o arquivo ***[docker-compose.yml](docker-compose.yml)***.

4. Execute o comando abaixo para construir e iniciar os contêineres:
   ```shell
   docker-compose up -d
   ```
   Este comando irá baixar e criar as imagens necessárias para rodar a aplicação em segundo plano.