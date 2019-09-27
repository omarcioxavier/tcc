USE tcc_db;

-- USUÁRIOS --
INSERT INTO usuario (login, senha, ativo, estabelecimentoID) VALUES
	('admin@pizzamax','123456', 1, 0, 1),
	('user@pizzamax','abcdef', 1, 0, 1);

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
	('Leandro e Milena Fast-foods Ltda','Pizzaria Max', '33.678.365/0001-29', '820.609.105.821', 1, 1);

INSERT INTO endereco (logradouro, numero, complemento, bairro, cep, cidadeID, estadoID) VALUES 
	('Rua Fagundes Varela','734','-','Vila Ribeiro','19802-150', 1, 1);

INSERT INTO estabelecimentoEndereco (estabelecimentoID, enderecoID) VALUES 
	(1, 3);

-- OUTRO --