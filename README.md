# Trucksys

## Sistema Para Cadastro de Caminhões

### Desenvolvido como teste de conhecimento seguindo os requisitos abaixo:

**Requisito principal**
Como usuário, eu necessito de um cadastro de caminhões, onde eu possa:
 - Visualizar os caminhões cadastrados;
  - As propriedades mínimas do caminhão deverão ser:
    - Modelo (Poderá aceitar apenas FH e FM)
    - Ano de Fabricação (Ano deverá ser o atual)
    - Ano Modelo (Poderá ser o atual ou o ano subsequente)
- Atualizar as informações de um caminhão;
- Excluir um caminhão;
- Inserir um novo caminhão.

**Requisito secundário**
Poderão existir vários modelos de caminhões.
 - Os modelos permitidos serão somente (FH e FM)

**Requisitos técnicos**
- Utilizar ASP.NET Core;
- Utilizar base de dados local;
- Utilizar ORM para mapear as tabelas de base de dados
    - Utilizar “Migrations” para criação da base de dados;
    - A criação da base de dados deverá ser automática (sem a necessidade de utilizar algum
comando adicional).
- Criar testes unitários (Cobrir ao menos 80% dos fluxos)

## Instruções para execução
Para executar o sistema, rodar o executável "TruckSys.Web.exe" da pasta Trucksys\src\TruckSys.Web\bin\Release\net6.0\publish
Este criará o banco de dados necessário.

Abrir no navegador o endereço mostrado na janela que será exibida.

Possivelmente: 
http://localhost:5000
ou
https://localhost:5001
