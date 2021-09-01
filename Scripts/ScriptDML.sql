Use M_Rental;
GO

INSERT INTO Empresa(NomeEmpresa)
VALUES ('Localiza');
GO

INSERT INTO Cliente(NomeCliente, SobrenomeCliente, CPF)
VALUES ('Marcos', 'Santos', '87512289212'), ('Claudio', 'Bonari', '84751728634');
GO

INSERT INTO Marca(NomeMarca)
VALUES ('Ford'), ('Fiat'), ('Chevrolet');
GO


INSERT INTO Modelo(IdMarca, NomeModelo, AnoLancamento)
VALUES (3, 'Camaro', '2020-12-06'), (1, 'Ecosport', '2020-05-21'), (2, 'Mobi', '2019-01-19');
GO

INSERT INTO Veiculo(IdEmpresa, IdModelo, CorVeiculo)
VALUES (1, 1, 'Branco'), (1, 2, 'Preto'), (1, 3, 'Cinza');
GO

INSERT INTO Aluguel(IdVeiculo, IdCliente, DataRetirada, DataDevolucao)
VALUES (1, 1, '2021-08-03', '2021-08-10'), (2, 2, '2021-08-28', '2021-08-31');
GO