USE tcc_db;

-- CLIENTES --
INSERT INTO cliente (nome, email, numeroCelular, ativo) VALUES 
	('Rafaela Sebastiana Teixeira', 'rrafaelasebastianateixeira@parker.com', '(41) 98929-3625', 1),
	('Elias Osvaldo Isaac Nunes', 'eliasosvaldoisaacnunes..eliasosvaldoisaacnunes@pubdesign.com.br', '(67) 99247-0232', 0);

INSERT INTO endereco (logradouro, numero, complemento, bairro, cep, cidadeID, estadoID) VALUES
	('Rua Nagib Moussi Fatouch','882','-','Pineville','83320-240', 3050, 18 ),
	('Rua Teófilo Rodrigues','448','-','Vila Erondina','79814-100', 1518, 12 );

INSERT INTO clienteEndereco (clienteID, enderecoID) VALUES 
	(1,1),
	(2,2);

-- ESTABELECIMENTOS --
INSERT INTO estabelecimentoCategoria (descricao) VALUES 
	('Pizzaria'),
	('Lanchonete'),
	('Restaurante'),
	('Cafeteria'),
	('Padaria');

INSERT INTO estabelecimento(razaoSocial, nomeFantasia, cnpj, inscricaoEstadual, ativo, estabelecimentoCategoriaID) VALUES
	('Leandro e Milena Fast-foods Ltda','Pizzaria Max', '33.678.365/0001-29', '820.609.105.821', 1, 1),
	('Otávio e Sophia Alimentos ME','Restaurante Villa Deck', '70.099.581/0001-46', '689.352.315.213', 1, 3);

INSERT INTO endereco (logradouro, numero, complemento, bairro, cep, cidadeID, estadoID) VALUES 
	('Rua Fagundes Varela','734','-','Vila Ribeiro','19802-150', 1, 1),
	('Rua Alair','242','-','Chácara Califórnia','03404-150', 5270, 26);

INSERT INTO estabelecimentoEndereco (estabelecimentoID, enderecoID) VALUES 
	(1, 3),
	(2, 4);

-- USUÁRIOS --
INSERT INTO usuario (login, senha, ativo, estabelecimentoID) VALUES
	('admin@pizzamax','123456', 1, 1),
	('user@pizzamax','abcdef', 1, 1),
	('caixa@admin','123456', 1, 2),
	('atendimento@admin','abcdef', 1, 2);

-- PRODUTOS --
INSERT INTO produtoCategoria (descricao) VALUES
	('Lanche'), ('Prato Feito'), ('Bebida'), ('Pizza');

INSERT INTO produto (descricao, precoUnitario, ativo, produtoCategoriaID) VALUES
	('Pizza de Calabresa com Requeijão M', 40, 1, 4),
	('Pizza a Portuguesa M', 35, 1, 4),
	('Pizza Baiana M', 35, 1, 4),
	('Pizza da Roça M', 45, 1, 4),
	('Pizza de Strogonoff M', 30, 0, 4),
	('Pizza a Italiana M', 50, 1, 4),
	('Pizza de Romeu e Julieta M', 35, 1, 4),
	('Pizza de Frango com Catupiry M', 40, 0, 4),
	('Coca-cola 2L', 7, 1, 3),
	('Sprite 2L', 6, 1, 3),
	('Água 550 ml', 3, 1, 3),
	('Coca-cola zero 2L', 7.5, 1, 3),
	('Prato Feito do Dia', 14, 1, 2),
	('Prato Feito Strogonoff', 17.9, 1, 2),
	('Prato Feito Bife Acebolado', 17.9, 0, 2),
	('Prato Feito Vegetariano', 17.9, 1, 2),
	('Prato Feito Vegano', 17.9, 1, 2);

INSERT INTO estabelecimentoProduto (estabelecimentoID, produtoID) VALUES
	(1,1), (1,2), (1,3), (1,4), (1,5), (1,6), (1,7), (1,8),	(1,9), (1,10), (1,11), (2,12), (2,13), (2,14), (2,15), (2,16), (2,8), (2,10), (2,11);

INSERT INTO pedido (dataPedido, valorPedido, quantidadeTotal, entrega, clienteID, estabelecimentoID) VALUES
	(GETDATE(), 47, 2, 0, 1, 1);

INSERT INTO produtoPedido (pedidoID, produtoID, quantidade) VALUES 
	(1,1,1), (1,8,1);