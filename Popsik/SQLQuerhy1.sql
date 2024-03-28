create procedure sp_insert_cu(@Name nvarchar(max),
                                    @Age int,
                                    @id int)
as
insert into Persons(FullName, age,id)
values (@Name, @Age, @id)
return scope_identity()