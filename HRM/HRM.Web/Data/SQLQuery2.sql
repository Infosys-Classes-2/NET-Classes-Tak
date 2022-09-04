-- Creating New Table
create table [dbo].[Test1]
([Id] int not null,
[Name] varchar(50),
[Address] varchar(50),
[Post] varchar(26)
)

insert into Test1(Id, Name, Address)
values (1, 'Krishna Subedi', 'KTM, Nepal');

select * from Test1

