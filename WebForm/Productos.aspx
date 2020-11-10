<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebForm.Productos" %>





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
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link disabled" href="#">Productos</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" href="#">Acerca de</a>
                    </li>

                </ul>
                 <form class="form-inline my-2 my-lg-0">
                 <asp:TextBox runat="server" ID="txt_buscar" Class="form-control mr-sm-2" Width="300"></asp:TextBox>
                 <asp:Button class="btn btn-primary" Text="Buscar" ID="Buscar" OnClick="Btn_Buscar" runat="server" />

                </form>
            </div>
        </nav>

        <main role="main">


            <div class="jumbotron">
            </div>



            <div class="container">
      

                <div class="row">

                    <% if (((List<Dominio.Articulo>)Session["ListaBuscar"]).Count() == 0)
                        { %>

                    <%foreach (Dominio.Articulo item in listaArticulos)
    { %>
                    <div class="col-lg-4 col-md-6 mb-4">
                        <div class="card h-100">
                            <a href="<% = item.codigo %>">
                                <img class="card-img-top" src="<% = item.ImageUrl %>" alt=""></a>
                            <div class="card-body">
                                <h4 class="card-title">
                                 <a href="Detalle_Producto.aspx?id=<%=item.id.ToString()%>"><%=item.Nombre %></a>
                                </h4>
                                <h5>AR$<% = item.Precio %></h5>
                                <a href="carrito.aspx?id=<%=item.id.ToString()%>" class="btn btn-primary">Agregar al Carrito 🛒</a>
                                <p class="card-text"><% = item.Descripcion %></p>
                            </div>
                        </div>
                    </div>
                    <% } %>

                    <%}

                        else
                        {
                            foreach (Dominio.Articulo item in ((List<Dominio.Articulo>)Session["ListaBuscar"]))
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
                                <a href="carrito.aspx?id=<%=item.id.ToString()%>" class="btn btn-primary">Agregar al Carrito 🛒</a>
                                <p class="card-text"><% = item.Descripcion %></p>
                            </div>
                        </div>
                    </div>
                    <%} %>


                    <%} %>
                </div>
            </div>
        </main>


    </form>
</body>
</html>
