use s4e;

-- script de carga 

-- tabela de associado
insert into Associado(Nome, Cpf, Data_Nascimento) values ('Associado 1', '68298393007', '23-07-2000');

insert into Associado(Nome, Cpf, Data_Nascimento) values ('Associado 2', '57266219051', '24-08-2001');

insert into Associado(Nome, Cpf, Data_Nascimento) values ('Associado 3', '97405495001', '25-09-2002');


-- tabela de empresa
insert into Empresa(Nome, Cnpj) values ('Empresa 1', '18745484000163');

insert into Empresa(Nome, Cnpj) values ('Empresa 2', '02166036000175');

insert into Empresa(Nome, Cnpj) values ('Empresa 3', '85238439000100');


-- tabela de vinculo entre associado e empresa
insert into Associado_Empresa(Id_Associado, Id_Empresa) values (1, 1);

insert into Associado_Empresa(Id_Associado, Id_Empresa) values (1, 2);

insert into Associado_Empresa(Id_Associado, Id_Empresa) values (2, 1);