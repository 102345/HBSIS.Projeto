# HBSIS.Projeto
Projeto exemplo de em ASP.NET MVC com DDD, AutoMapper , ORM Dapper. e com consumo de métodos de serviços em WEB API MVC Rest

# Para Testar funcionamento do projeto , siga os seguintes passos:

1. Instalar o SDGB Ms SQL Server Express 2012.
2. Rodar os scripts que se encontram na pasta \Scripts_Database na seguinte ordem:
a - Database_create.sql
b - Table_create.sql

3. Abrir o arquivo Web.Config do projeto HBSIS.Presentation e localizar a chave <connectionString> e mudar o parametro 
connectionString para sua string de conexao local.
4 - Fazer o mesmo procedimento para a chave urlBaseApi e mudar para endereço do local onde roda o projeto HBSIS.Api 

5- Rodar primeiro o projeto HBSIS.api
4 -Em seguida rodar o projeto HBSIS.Presentation

OBS: Para rodar os projetos desta solução usar o Visual Studio 2017 ou versão superior.
