# Cadastro de Pacientes App

## Visão Geral

O CadastroPacientesApp é uma aplicação web para gerenciamento de registros de pacientes. Ele é composto por uma API em .NET, conexão com banco de dados SQL Server e interface em Angular.

![CadastroPacientesApp-screenshot](https://github.com/andrenunes57/CadastroPacientesApp/assets/44682302/2833e5d9-295f-4cc3-9c47-b756692025cf)

## Funcionalidades

- Funcionalidade 1: Criar um Paciente
- Funcionalidade 2: Editar um Paciente

## Como Começar

### Pré-requisitos

- Node 14.15.0 ou 16.10.0

  Utilize o [NVM for Windows](https://github.com/coreybutler/nvm-windows/releases) ou [Download direto](https://nodejs.org/download/release/v16.10.0/)

- Angular CLI 14
  ```shell
  npm install -g @angular/cli@14
  ```
- SQL Server
  - Express (Windows) [Download direto](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
    OU
  - Docker (Multiplataforma) [Docker Desktop](https://www.docker.com/products/docker-desktop/) com a [imagem SQL Server](https://hub.docker.com/_/microsoft-mssql-server)
- .NET 7

  [Download direto](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0)

### Instalação

- Clone o repositório:
  ```shell
  git clone https://github.com/andrenunes57/CadastroPacientesApp.git
  ```

## USO

1. Edite a string de conexão:

   - Na pasta da API `CadastroPacientesApp\PacienteAPI\API`, abra o arquivo `appsettings.json`

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "server=[Nome do Servidor];database=[Nome do Banco];trusted_connection=true;TrustServerCertificate=True"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }
   ```

   - Altere o valor de "DefaultConnection" para apontar para o seu banco de dados local.

   Onde, **[Nome do Servidor]** e **[Nome do Banco]** são variáveis e devem ser alteradas.

   Caso o seu banco de dados possua usuário e senha, após "database=[Nome do Banco]", acrescente na string:

   ```string
   User ID=[Seu Usuário];Password=[Sua Senha];
   ```

   Onde, **[Seu Usuário]**, **[Sua Senha]** também são variáveis e devem ser alteradas.

2. Garanta que os pacotes NuGet estão restaurados:

   - Na pasta raiz do projeto da API `CadastroPacientesApp\PacienteAPI\API`, execute o comando:

   ```shell
   dotnet restore
   ```

3. Crie o banco de dados local através das Migrations:

   - Verifique se o serviço do banco de dados está em execução.
   - Instale o .NET Tool, caso ainda não a possua, executando o comando:

   ```shell
   dotnet tool install --global dotnet-ef
   ```

   Se já possui o .NET Tool, verifique se ela está atualizada executando o comando:

   ```shell
   dotnet tool update --global dotnet-ef
   ```

   - Na pasta raiz do projeto da API `CadastroPacientesApp\PacienteAPI\API`, execute o comando:

   ```shell
   dotnet ef database update
   ```

4. Popule a tabela [Convenio] do Banco de Dados:

   - Verifique se o banco de dados foi criado e popule a tabela [Convenio] executando o seguinte comando SQL (substitua os nomes dos convênios, se desejar):

   ```sql
   INSERT INTO Convenio (Nome)
   VALUES
   ('SulAmérica'),
   ('NotreDame Intermédica'),
   ('Prevent Senior'),
   ('Amil Assistência Médica');
   ```

5. Rode a API:

   - Na pasta raiz do projeto `CadastroPacientesApp\PacienteAPI\API`, execute o comando:

   ```shell
   dotnet run
   ```

6. Garanta que os pacotes para a aplicação cliente (interface) estão restaurados:

   - Na pasta raiz do projeto da interface `CadastroPacientesApp\Paciente.UI`, execute o comando:

   ```shell
   npm install
   ```

7. Rode a aplicação cliente:

   - Na pasta raiz do projeto `CadastroPacientesApp\Paciente.UI`, execute o comando:

   ```shell
   ng serve -o
   ```

   - Será aberta uma página no endereço http://localhost:4200/

8. Cadastre e Edite um Paciente:
   - Com a aplicação front-end em funcionamento, conforme a captura de tela no topo deste README, você pode cadastrar e editar um paciente de acordo com as validações implementadas.
