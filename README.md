# VemDoBem.Api
[![Build Status](https://dev.azure.com/frbatist/O%20que%20vem%20do%20bem/_apis/build/status/O%20que%20vem%20do%20bem-Docker%20container-CI?branchName=develop)](https://dev.azure.com/frbatist/O%20que%20vem%20do%20bem/_build/latest?definitionId=17&branchName=develop)

Repositorio com as operações básicas do projeto "O que vem do bem".

No momento estão em desenvolvimento as seguintes funcionalidades:

- Cadastro de usuário;
- Cadastro de Instituição;
- Cadstro de evento;
- Subscrição de usuário como voluntário da insitituição/evento;
- Sistema de comunicação entre instituição e voluntário.

Segue o mapeamento inicial das entidades e relacionamentos (os atributos das entidades, poderão ser visualizadas no código): 

![Alt](Diagramas/MER_base.svg)

- Um usuário pode criar uma nova instituição, ou se associar como voluntário de alguma existente;
- Um usuário pode se inscrever à um evento cadastrado por uma instituição existente;
- O sistema de comunicação irá servir para que insitituição e voluntários se comuniquem, e também para retorno (a ser realizado pelas duas partes) sobre trabalhos realizados em eventos realizados, esses retornos podem ser públicos ou privádos.
