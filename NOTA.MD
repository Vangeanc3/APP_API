# ROTAS:

https://localhost:7241/{MODELO}

https://localhost:7241/usuario

- Métodos

[POST]
https://localhost:7241/orcamento/criar

https://localhost:7241/instalador/criar

[GET]

https://localhost:7241/produto/buscar

https://localhost:7241/pedido/buscar

- Podemos passar alguns parametros por query, por ex:
    https://localhost:7241/usuario/buscar?skip=0&take=50
--Fazemos isso, pois, algumas coisas devem ser paginadas, para não comprometer a performaçe. Rotas que implementam isso são: Usuario, Produto, Pedidos, Orçamentos

[GET/ID]

https://localhost:7241/pedido/parametro?id=0

- Também Podemos passar alguns parametros por query, por ex:
    https://localhost:7241/produto/buscar/parametro?id=0
    https://localhost:7241/produto/buscar/parametro?email=ismael@gmail.com


[PUT]

https://localhost:7241/pedido/atualizar/{ID}

https://localhost:7241/usuario/atualizar/{ID}

[DELETE]

https://localhost:7241/pedido/deletar/{ID}
