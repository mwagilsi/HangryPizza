PROPOSTA DO PROJETO

Esta é uma pizzaria muito famosa no bairro, seus donos sempre foram muito reticentes quando o assunto é a venda online, mas diante das atuais circunstâncias eles tiveram de reconsiderar.

Seu desafio é criar uma API para receber os pedidos feitos a partir do site da pizzaria que atenda aos requisitos abaixo:

1 - Todo pedido precisa ter um identificador único
2 - Um pedido pode ter no mínimo uma pizza e no máximo 10.
3 - Cada pizza pode ter até dois sabores, os sabores disponíveis são:
 - Três Queijos (R$ 50)
 - Frango com requeijão (R$ 59.99)
 - Mussarela (R$ 42.50)
 - Calabresa (R$ 42.50)
 - Pepperoni (R$ 55)
 - Portuguesa (R$ 45)
 - Veggie (R$ 59.99)
4 - O preço da pizza com dois sabores (meio a meio) deve ser composto pela metade do valor de cada uma das pizzas.
5 - O cliente não precisa ter cadastro para fazer um pedido, mas nesse caso precisará informar os dados de endereço de entrega, caso seja um cliente cadastrado ele não precisa informar o endereço de entrega, pois deve constar em seu cadastro.
6 - Não vamos cobrar frete nessa primeira versão do sistema
7 - O cliente deve ser capaz de ver seu histórico de pedidos, com os detalhes das pizzas, valor individual e valor total do pedido.
9 - O front-end será desenvolvido por outro time, por isso a criação de testes de unidade e de integração são imprescindíveis.
10 - Fique a vontade para testar os cenários que achar mais relevantes.

PROJETOS DA SOLUÇÃO

• HungryPizza.Presentation: Aplicação Web API, usando Swagger permite assim mapear os metodos, e testar a aplicação.
• HungryPizza.Application: Nesta camada contém os serviços, interfaces, regras de negócio e validações.
• HungryPizza.Infrastructure: Nesse repositorio temos as classes referentes ao repositório e conexão com o banco de dados.
• HungryPizza.Domain: Nesse repositorio possui as entidades do projeto.
• HungryPizza.Tests: Nesse repositorio possui os testes automatizados. Permite testar os commands, queries e controllers utilizando dados mockados.

DADOS DO PROJETO

.NET Core
Swagger
AutoMapper
Entity Framework
SQLServer

PATTERNS/DESIGNS

Domain Driven Design


