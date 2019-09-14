USE tcc_db

INSERT INTO clienteCategoria (descricao) VALUES 
	('Pessoa Física'), 
	('Pessoa Jurídica');

INSERT INTO cliente (nome, email, numeroCelular, ativo, clienteCategoriaID) VALUES 
	('Caleb Caio Lorenzo Nogueira', 'ccalebcaiolorenzonogueira@ozsurfing.com.br', '(21) 99112-8852', 1, 1),
	('Rafaela Sebastiana Teixeira', 'rrafaelasebastianateixeira@parker.com', '(41) 98929-3625', 0, 1);