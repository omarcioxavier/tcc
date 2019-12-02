USE tcc_db;

-- CLIENTES --
INSERT INTO cliente (nome, email, numeroCelular, ativo) VALUES 
	('Rafaela Sebastiana Teixeira', 'rrafaelasebastianateixeira@parker.com', '(19) 98929-3625', 1),
	('Elias Osvaldo Isaac Nunes', 'eliasosvaldoisaacnunes..eliasosvaldoisaacnunes@pubdesign.com.br', '(19) 99247-0232', 1);

INSERT INTO endereco (logradouro, numero, complemento, bairro, cep, cidadeID, estadoID, latitude, longitude) VALUES
	('Rua José Alves Guedes','444','-','Centro','13820-971', 4988, 26, -22.704699, -46.984654),
	('Rua Julia Bueno','348','-','Centro','13820-970', 4988, 26, -22.706139, -46.986468);

INSERT INTO clienteEndereco (clienteID, enderecoID) VALUES 
	(1,1),
	(2,2);

-- ESTABELECIMENTOS --
INSERT INTO estabelecimentoCategoria (descricao) VALUES 
	('Pizzaria');

-- PRODUTOS --
INSERT INTO produtoCategoria (descricao) VALUES ('Pizza'), ('Bebida');

INSERT INTO pagamento (descricao) VALUES ('Dinheiro'), ('Cartão');