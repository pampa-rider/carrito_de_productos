<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detalle_producto.aspx.cs" Inherits="WebForm.detalle_producto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <table border="0">
            <%if (mostrar != null)
                {
                    Dominio.Articulo item = mostrar;
            %>

            <tr>
                <img src="<%=item.ImageUrl %>" width="200">
                <td><% = item.Nombre %></td>
                <td><% = item.marca %></td>
                <td><% = item.categoria %></td>
                <td><% = item.Precio %></td>
                <td><a href="carrito.aspx?id=<% = item.id.ToString() %>">Agregar al Carrito</a></td>
                <a href="Productos.aspx">Volver</a>
            </tr>


            <%}
                else
                { }
            %>
        </table>
    </form>
</body>
</html>
