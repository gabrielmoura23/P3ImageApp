select * from Tab_Categoria


insert into Tab_Categoria
select 'Veículos e Acessórios', 'veiculos-acessorios'


insert into Tab_Categoria
select 'Motos e Acessórios', 'motos-acessorios'


insert into Tab_Categoria
select 'Náutica e Acessórios', 'nautica-acessorios'

insert into Tab_Categoria
select 'A1 e Acessórios ', 'a1-acessorios'

insert into Tab_Categoria
select 'B2 e Acessórios ', 'b2-acessorios'

------------------------------------

select * from Tab_Subcategoria


insert into Tab_Subcategoria
select 1, 'som', 'som'


insert into Tab_Subcategoria
select 1, 'motor', 'motor'


------------------------------------

select * from Tab_Campo


insert into Tab_Campo
select 1, 1, 'Campo1', 'checkbox', '["Opção1", "Opção2", "Opção3"]'

insert into Tab_Campo
select 1, 2, 'Campo2', 'select', '["Opção1", "Opção2", "Opção3"]'

insert into Tab_Campo
select 1, 3, 'Campo3', 'text', null

insert into Tab_Campo
select 1, 4, 'Campo4', 'textarea', null



