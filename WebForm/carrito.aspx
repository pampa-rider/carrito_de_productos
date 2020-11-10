<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="WebForm.carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://getbootstrap.com/docs/4.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <title><%: Title %></title>


</head>

<body>
    <form id="form1" runat="server">

        <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
            <a class="navbar-brand" href="#">Tech-e-Mark</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarsExampleDefault">
                <ul class="navbar-nav mr-auto">
                    
                    <li class="nav-item">
                        <a class="nav-link" href="home.aspx">Home</a>
                    </li>


                    <li class="nav-item">
                        <a class="nav-link" href="productos.aspx">Productos</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" href="#">Acerca de</a>
                    </li>

                </ul>
            </div>
        </nav>

        <main role="main">


            <div class="jumbotron">
     <h3><asp:Label ID="importe_t" runat="server" Text="Cantidad Articulos:"></asp:Label></h3>
     <h3><asp:Label ID="cant_items" runat="server" Text="Importe $:"></asp:Label></h3>
    <a href="productos.aspx" class="btn btn-primary">volver</a>
            </div>



            <div class="container">

                <div class="row">
                
                    <% foreach (Dominio.Articulo item in lista_carrito)
                        {
                    %>

                      <div class="col-lg-4 col-md-6 mb-4">
                        <div class="card h-100">
                            <a href="<% = item.codigo %>">
                                <img class="card-img-top" src="<% = item.ImageUrl %>" alt=""></a>
                            <div class="card-body">
                                <h4 class="card-title">
                                 <a href="Detalle_Producto.aspx?id=<%=item.id.ToString()%>"><%=item.Nombre %></a>
                                </h4>
                                <h5>AR$<% = item.Precio %></h5>
                                <a href="Carrito.aspx?id=<%=item.id.ToString()%>&extra=<%=1.ToString() %>"  class="btn btn-danger" >Eliminar</a>

                                <p class="card-text"><% = item.Descripcion %></p>
                            </div>
                        </div>
                    </div>

                    <%} %>
                
                </div>
                

            </div>
        </main>


    </form>
</body>
</html>
