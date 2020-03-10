
# MyBank Api
Projeto desenvolvido como exemplo de estrutura de aplicação.

## Páginas

* / => UI de Açãoes

* /api-docs => Swagger

  

## Endpoints Adicionado

  

* POST /api/bank/NewCustomer - Adiciona novo cliente

  

* POST /api/bank/OpenBankAccount - Abre nova conta

  

* POST /api/bank/Deposit - Realiza Depósito

  

* POST /api/bank/Withdraw - Realiza Saque de Valores

  

* POST /api/bank/Account - Adiciona nova Conta

  

* GET /api/bank/Account - Retorna Conta

  

* GET /api/bank/AccountTransactions - Retorna transações de uma conta

  

## Regras Adicionadas

  

* Depósitos: Valores não devem ser negativos

* Realizar Saque : Valores Devem ser sempre maior que Zero e Menores que o Saldo atual

  
  

## Patterns Utilizados:

  

* Repository Pattern

* Service Pattern

* IoC - Inversion of Control

* MVC

* DDD - Apesar de não ter muita evolução no DDD, está presente.

## Bibliotecas Utilizadas

 - Scrutor
 - Entity Framework Core
 - Automapper 9.0

# Rodando a aplicação

  

## Via Docker:

Realizar build

    $ docker-compose build
 Rodando apenas o Banco de Dados>

    docker-compose up -d mybank.db

> Foi escolhido o MariaDB pois utiliza as mesmas funcionalidades e drivers do MySQL, porém, na minha humilde opinião é mais performático e seguro.
> Após Iniciar o Banco de dado é possível que seja necessário esperar alguns minutos até que todas as configurações sejam aplicadas.

Rodar a aplicação

     docker-compose -f docker-compose.yml up --build -d mybank.web
