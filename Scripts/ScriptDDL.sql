CREATE DATABASE M_Rental;
GO

USE M_Rental;
GO

CREATE TABLE Empresa(
	idEmpresa INT PRIMARY KEY IDENTITY(1,1),
	nomeEmpresa VARCHAR(30) NOT NULL
);
GO

CREATE TABLE Marca(
	idMarca INT PRIMARY KEY IDENTITY(1,1),
	nomeMarca VARCHAR(14) NOT NULL UNIQUE
);
GO

CREATE TABLE Modelo(
	idModelo INT PRIMARY KEY IDENTITY(1,1),
	idMarca INT FOREIGN KEY REFERENCES Marca(IdMarca),
	nomeModelo VARCHAR(12),
	anoLancamento DATE
);
GO


CREATE TABLE Veiculo(
	idVeiculo INT PRIMARY KEY IDENTITY(1,1),
	idEmpresa INT FOREIGN KEY REFERENCES Empresa(IdEmpresa),
	idModelo INT FOREIGN KEY REFERENCES Modelo(IdModelo),
	corVeiculo VARCHAR(12) NOT NULL
);
GO

CREATE TABLE Cliente(
	idCliente INT PRIMARY KEY IDENTITY(1,1),
	nomeCliente VARCHAR(20) NOT NULL,
	sobrenomeCliente VARCHAR(30),
	CPF CHAR(11) NOT NULL
);
GO

CREATE TABLE Aluguel(
	idAluguel INT PRIMARY KEY IDENTITY(1,1),
	idVeiculo INT FOREIGN KEY REFERENCES Veiculo(IdVeiculo),
	idCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente),
	dataRetirada DATE,
	dataDevolucao DATE
);
GO