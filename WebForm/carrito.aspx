<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="WebForm.carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<table border="0">

<% 
foreach(Dominio.Articulo item in lista_carrito)
{
%>

<tr>
 <td><p></p><%=item.Nombre%></td>  
 <td><p><%=item.Precio%></p></td>  
 <td><img src=<%=item.ImageUrl%> width="200"></td>  
</tr>
<a href="Carrito.aspx?id=<%=item.id.ToString()%>&extra=<%=1.ToString() %>" >Eliminar</a>

<a href="Productos.aspx?">Volver</a>

<%}%>

</table>


    <asp:Label ID="importe_t" runat="server" Text="Cantidad Articulos:"></asp:Label>
     <asp:Label ID="cant_items" runat="server" Text="Importe $:"></asp:Label>



<%
if(lista_carrito.Count()==0)
{
%>
<p>Carrito Vacio</p>
<%
}
%>



</form>
</body>
</html>
