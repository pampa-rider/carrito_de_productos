<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebForm.Productos" %>




<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>

<body>
    <form id="form1" runat="server">

        <asp:Button class="btn btn-primary" Text="Buscar" ID="Buscar" OnClick="Btn_Buscar" runat="server" />
        <asp:TextBox runat="server" ID="txt_buscar"></asp:TextBox>
        <table border="0">
            <%
                if (((List<Dominio.Articulo>)Session["ListaBuscar"]).Count() == 0)
                {

                    foreach (Dominio.Articulo item in listaArticulos)
                    { %>
            <tr>
                <td><%=item.Nombre %></td>
                <td>

                    <a href="carrito.aspx?id=<%=item.id.ToString()%>">Agregar al Carrito</a>

                    <a href="Detalle_Producto.aspx?id=<%=item.id.ToString()%>">Ver mas</a>
                </td>
            </tr>
            <% }
                }
                else
                { %>
        </table>


        <table border="0">
            <% foreach (Dominio.Articulo item in ((List<Dominio.Articulo>)Session["ListaBuscar"]))
                { %>
            <tr>
                <td><%=item.Nombre %></td>
                <td>

                    <a href="producto.aspx?id=<%=item.id.ToString()%>">Agregar al Carrito</a>

                    <a href="detalle_producto.aspx?id=<%=item.id.ToString()%>">Detalle</a>
                </td>
            </tr>
            <% }
                }%>
        </table>



        <div>
        </div>
    </form>
</body>
</html>
