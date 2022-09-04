Alter table Person
add Id int Identity(1,1) not null


insert into Person(
Id, Name, Address)
values (1, 'Jenny Maharjan', 'KTM, nepal');

select * from Person