select * from Tab_Categoria


insert into Tab_Categoria
select 'Ve�culos e Acess�rios', 'veiculos-acessorios'


insert into Tab_Categoria
select 'Motos e Acess�rios', 'motos-acessorios'


insert into Tab_Categoria
select 'N�utica e Acess�rios', 'nautica-acessorios'

insert into Tab_Categoria
select 'A1 e Acess�rios ', 'a1-acessorios'

insert into Tab_Categoria
select 'B2 e Acess�rios ', 'b2-acessorios'

------------------------------------

select * from Tab_Subcategoria


insert into Tab_Subcategoria
select 1, 'som', 'som'


insert into Tab_Subcategoria
select 1, 'motor', 'motor'


------------------------------------

select * from Tab_Campo


insert into Tab_Campo
select 1, 1, 'Campo1', 'checkbox', '["Op��o1", "Op��o2", "Op��o3"]'

insert into Tab_Campo
select 1, 2, 'Campo2', 'select', '["Op��o1", "Op��o2", "Op��o3"]'

insert into Tab_Campo
select 1, 3, 'Campo3', 'text', null

insert into Tab_Campo
select 1, 4, 'Campo4', 'textarea', null



