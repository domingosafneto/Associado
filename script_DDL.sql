-- Criação das tabelas
use s4e; 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- Associoados
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS
           WHERE CONSTRAINT_NAME = 'FK_Associado_Empresa_Associado')
BEGIN
	ALTER TABLE Associado_Empresa DROP CONSTRAINT FK_Associado_Empresa_Associado	
	PRINT 'Constraint FK_Associado_Empresa_Associado foi removida'
END
GO

IF OBJECT_ID('Associado', 'U') IS NOT NULL
BEGIN
    DROP TABLE Associado
	PRINT 'A tabela Associado foi removida.'	
END
GO

CREATE TABLE Associado (
	Id_Associado INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(200) NOT NULL,
	Cpf VARCHAR(11) NOT NULL UNIQUE,
	Data_Nascimento Date NULL
);
GO

PRINT 'A tabela Associado foi criada.'
GO


-- Empresas
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS
           WHERE CONSTRAINT_NAME = 'FK_Associado_Empresa_Empresa')
BEGIN
	ALTER TABLE Associado_Empresa DROP CONSTRAINT FK_Associado_Empresa_Empresa	
	PRINT 'Constraint FK_Associado_Empresa_Empresa foi removida'
END
GO

IF OBJECT_ID('Empresa', 'U') IS NOT NULL
BEGIN
    DROP TABLE Empresa
	PRINT 'A tabela Empresa foi removida.'	
END
GO

CREATE TABLE Empresa (
	Id_Empresa INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(200) NOT NULL,
	Cnpj VARCHAR(14) NOT NULL UNIQUE
);
GO

PRINT 'A tabela Empresa foi criada.'
GO


-- Tabela de relacionamento
IF OBJECT_ID('Associado_Empresa', 'U') IS NOT NULL
BEGIN
    DROP TABLE Associado_Empresa
	PRINT 'A tabela Associado_Empresa foi removida.'	
END
GO

CREATE TABLE Associado_Empresa (
    Id_Associado INT NOT NULL,
    Id_Empresa INT NOT NULL,
    PRIMARY KEY (Id_Associado, Id_Empresa),
    CONSTRAINT FK_Associado_Empresa_Associado FOREIGN KEY (Id_Associado) REFERENCES Associado (Id_Associado),
    CONSTRAINT FK_Associado_Empresa_Empresa FOREIGN KEY (Id_Empresa) REFERENCES Empresa (Id_Empresa)
);
GO

PRINT 'A tabela Associado_Empresa foi criada.'
GO