USE tcc_db;

INSERT INTO estabelecimentoCategoria (descricao) VALUES 
	('Pizzaria'),
	('Lanchonete'),
	('Restaurante'),
	('Cafeteria'),
	('Padaria');

INSERT INTO estabelecimento(razaoSocial, nomeFantasia, cnpj, inscricaoEstadual, ativo, estabelecimentoCategoriaID) VALUES
	('Leandro e Milena Fast-foods Ltda','Pizzaria Max', '33.678.365/0001-29', '820.609.105.821', 1, 1);

INSERT INTO endereco (logradouro, numero, complemento, bairro, cep, cidadeID, estadoID) VALUES 
	('Rua Fagundes Varela','734','-','Vila Ribeiro','19802-150',1,1);

INSERT INTO estabelecimentoEndereco (estabelecimentoID, enderecoID) VALUES 
	(1, 3);