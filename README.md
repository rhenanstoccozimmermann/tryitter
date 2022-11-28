<div align="center">
  <h3 align="center">Desafio Final da Aceleração em C# da Turma XP - Trybe</h3>
  <p align="center">
    Trata-se de desafio técnico proposto ao final da Aceleração em C# da Turma XP - Trybe, no qual foi desenvolvido um aplicativo de rede social, o Tryitter.
  </p>
</div>


## Sumário

<ol>
  <li>
    <a href="#1-sobre-o-desafio">Sobre o desafio</a>
  </li>
  <li>
    <a href="#2-explicação-sobre-as-tomadas-de-decisão-no-projeto">Explicação sobre as tomadas de decisão no projeto</a>
  </li>
  <li>
    <a href="#3-instruções-sobre-como-executar-o-projeto">Instruções sobre como executar o projeto</a>
  </li>
  <li>
    <a href="#4-contato">Contato</a>
  </li>
</ol>


## 1. Sobre o desafio

Foi realizado o desafio de Tema 1 - Tryitter.

Trata-se de uma rede social em que as pessoas estudantes poderão, por meio de textos e imagens, compartilhar experiências e aprendizados.

O desafio é composto dos seguintes requisitos técnicos:

- Utilizar C#, SQL Server e Azure;
- Ter rotas autenticadas e rotas anônimas;
- Utilizar os frameworks xUnit e FluentAssertions para criar testes;
- Implementar um CRUD para as contas de pessoas estudantes;
- Implementar um CRUD para um post de uma pessoa estudante; e
- 30%, no mínimo, de cobertura de testes.

## 2. Explicação sobre as tomadas de decisão no projeto

Seguem as decisões tomadas no planejamento e na implementação do projeto, com a correspondente explicação.

### I) Etapa de planejamento

Nesta etapa foram definidos os endpoints e o Diagrama de Entidade-Relacionamento (DER), para orientar a construção das tabelas no banco de dados.

Nesta etapa também foi confecionada a versão inicial deste README.

Seguem as definições com as justificativas.

#### Diagrama de Entidade-Relacionamento (DER)

Para orientar a construção das tabelas, foi elaborado o DER a seguir:

<div align="center">
  <img src=".github/database.png" alt="Diagrama de Entidade-Relacionamento" width="600px" />
</div>
<br />

#### Endpoints

Para orientar o desenvolvimento dos endpoints, foi elaborada a lista a seguir:

- POST /account
- POST /login
- GET /account/:id
- PUT /account/:id
- DELETE /account/:id
- POST /post
- GET /post/account/:id
- GET /post/:id
- PUT /post/:id
- DELETE /post/:id

### II) Etapa de implementação

Na etapa de implementação, foram elaborados os endpoints com os requisitos especificados.

Seguem os endpoints implementados:

#### POST /account

O endpoint cria uma nova conta na rede social.

Recebe como entradas o nome e uma senha.

Retorna o id da nova conta.

#### POST /login

O endpoint se destina à autenticação e autorização JWT.

Recebe como entradas o nome e a senha do estudante.

Retorna um token.

#### GET /account/:id

O endpoint retorna o nome e a senha da pessoa estudante na rede social.

Recebe como entrada o id da conta.

#### PUT /account/:id

O endpoint altera o nome e a senha da pessoa estudante na rede social.

Recebe como entradas o id da conta e um novo nome e uma nova senha.

Retorna uma mensagem confirmando a alteração.

#### DELETE /account/:id

O endpoint remove uma conta na rede social.

Recebe como entrada o código da conta.

Retorna uma mensagem confirmando a remoção.

#### POST /post

O endpoint cria um post na conta indicada.

Recebe como entradas o id da conta e o conteúdo do post.

Retorna o id do post.

#### GET /post/account/:id

O endpoint lista todos os posts de uma pessoa estudante na rede social.

Recebe como entrada o id da conta.

Retorna uma lista com o id da conta e os ids e conteúdos dos posts.

#### GET /post/:id

Retorna o id da conta e o id e conteúdo do post.

Recebe como entrada o id do post.

#### PUT /post/:id

O endpoint altera o conteúdo de um post na rede social.

Recebe como entradas o id do post e um novo conteúdo.

Retorna uma mensagem confirmando a alteração.

#### DELETE /post/:id

O endpoint remove um post na rede social.

Recebe como entrada o id do post.

Retorna uma mensagem confirmando a remoção.

#### Testes unitários

O projeto conta com testes unitários para garantir a qualidade e o funcionamento das unidades do código.

Atualmente, todos os testes estão sendo executados com êxito, conforme pode ser observado abaixo.

Além disso, os testes possuem atualmente cobertura de código de `+30%`.

<div align="center">
  <img src=".github/tests.png" alt="Resultado Testes Unitários" width="600px" />
</div>

#### Deploy da API

Foi feito o deploy da API, que pode ser encontrada na URL abaixo:

## 3. Instruções sobre como executar o projeto

## 4. Contato

Ingrid Mattos

<div>
  <a href="https://www.linkedin.com/in/ingrid-mattos/">
    <img src="https://img.shields.io/badge/-LinkedIn-%230077B5?style=for-the-badge&logo=linkedin&logoColor=white" />
  </a>
</div>
<br />

Rhenan Stocco Zimmermann

<div>
  <a href="https://www.linkedin.com/in/rhenanstoccozimmermann/">
    <img src="https://img.shields.io/badge/-LinkedIn-%230077B5?style=for-the-badge&logo=linkedin&logoColor=white" />
  </a>
</div>
<br />

<a href="#sumário">🔝 Voltar ao topo</a>