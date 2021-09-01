USE M_Rental;
GO

SELECT * FROM Empresa;
GO

SELECT * FROM Cliente;
GO

SELECT * FROM Marca;
GO

SELECT * FROM Modelo;
GO

SELECT * FROM Veiculo;
GO

SELECT * FROM Aluguel;
GO

SELECT DataRetirada, DataDevolucao, NomeCliente, SobrenomeCliente, NomeModelo
FROM Aluguel
LEFT JOIN Cliente
ON Aluguel.IdCliente = Cliente.IdCliente
LEFT JOIN Veiculo
ON Aluguel.IdVeiculo = Veiculo.IdVeiculo
LEFT JOIN Modelo
ON Veiculo.IdModelo = Modelo.IdModelo;
GO

SELECT NomeCliente, SobrenomeCliente, DataRetirada, DataDevolucao, NomeModelo
FROM Aluguel
RIGHT JOIN Cliente
ON Aluguel.IdCliente = Cliente.IdCliente
LEFT JOIN Veiculo
ON Aluguel.IdVeiculo = Veiculo.IdVeiculo
LEFT JOIN Modelo
ON Veiculo.IdModelo = Modelo.IdModelo
WHERE NomeCliente = 'Lucas';
GO
