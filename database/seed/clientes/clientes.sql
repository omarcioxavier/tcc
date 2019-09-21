USE tcc_db;

INSERT INTO clienteCategoria (descricao) VALUES 
	('Pessoa Física'), 
	('Pessoa Jurídica');

INSERT INTO cliente (nome, email, numeroCelular, ativo, clienteCategoriaID) VALUES 
	('Rafaela Sebastiana Teixeira', 'rrafaelasebastianateixeira@parker.com', '(41) 98929-3625', 1, 1),
	('Elias Osvaldo Isaac Nunes', 'eliasosvaldoisaacnunes..eliasosvaldoisaacnunes@pubdesign.com.br', '(67) 99247-0232', 0, 1);

INSERT INTO endereco (logradouro, numero, complemento, bairro, cep, cidadeID, estadoID) VALUES
	('Rua Nagib Moussi Fatouch','882','-','Pineville','83320-240', 3050, 18 ),
	('Rua Teófilo Rodrigues','448','-','Vila Erondina','79814-100', 1518, 12 );

INSERT INTO clienteEndereco (clienteID, enderecoID) VALUES 
	(1,1),
	(2,2);