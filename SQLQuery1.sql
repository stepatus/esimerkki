create table tuotteet (id integer identity(1,1) primary key, nimi text, hinta integer);
insert into tuotteet (nimi,hinta) values('juusto', 5);
insert into tuotteet (nimi,hinta) values('maito', 1);

select * from tuotteet;