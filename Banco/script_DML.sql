use AssociadoEmpresa;

-- script de carga 

-- tabela de associado
insert into Associado(Nome, Cpf, Data_Nascimento) values ('Associado 1', '68298393007', '2000-07-23');

insert into Associado(Nome, Cpf, Data_Nascimento) values ('Associado 2', '57266219051', '2001-08-24');

insert into Associado(Nome, Cpf, Data_Nascimento) values ('Associado 3', '97405495001', '2002-09-25');
GO


-- tabela de empresa
insert into Empresa(Nome, Cnpj) values ('Empresa 1', '18745484000163');

insert into Empresa(Nome, Cnpj) values ('Empresa 2', '02166036000175');

insert into Empresa(Nome, Cnpj) values ('Empresa 3', '85238439000100');
GO


-- tabela de vinculo entre associado e empresa
insert into Associado_Empresa(Id_Associado, Id_Empresa) values (1, 1);

insert into Associado_Empresa(Id_Associado, Id_Empresa) values (1, 2);

insert into Associado_Empresa(Id_Associado, Id_Empresa) values (2, 1);
GO