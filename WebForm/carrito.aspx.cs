using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebForm
{
    public partial class carrito : System.Web.UI.Page
    {

        public Articulo a_buscado;
        public List<Articulo> lista_carrito;
        int id_aux;
        int extra;
        carro carrin;
        protected void Page_Load(object sender, EventArgs e)
        {
        ArticuloNegocio negocio_a = new ArticuloNegocio();
        carrin = new carro();
        List<Articulo> lista_a;
        
        extra = Convert.ToInt32(Request.QueryString["extra"]);
        id_aux = Convert.ToInt32(Request.QueryString["id"]);    
        lista_a=negocio_a.listar();
        a_buscado = lista_a.Find(X=> X.id == id_aux);
        
                if(id_aux !=0 && extra == 1)
                {
                try
                    {
                    lista_carrito = ((List<Articulo>)Session["list_articulos"]);    
                        foreach(Articulo item in lista_carrito)
                        {
                            if(item.id == id_aux)
                            {
                            lista_carrito.Remove(item);
                            Session.Add("list_articulos",lista_carrito);
                            Response.Redirect("Carrito.aspx");
                            }
                        }
                    }
                catch(Exception ex)
                {throw ex;}    

                }

                    else if(id_aux == 0)
                    {
                    if(Session["list_articulos"] == null)
                    {
                    lista_carrito = new List<Articulo>();    
                    Session["list_articulos"] = lista_carrito;            
                    }

                    else{lista_carrito = (List<Articulo>)Session["list_articulos"];}    

                    }

        else
        {
            try
            {
            if(Session["list_articulos"] == null)
                {
                lista_carrito = new List<Articulo>();    
                lista_carrito.Add(a_buscado);
                Session["list_articulos"] = lista_carrito;
                }

                else
                {
                lista_carrito = (List<Articulo>)Session["list_articulos"];    
                lista_carrito.Add(a_buscado);
                Session["list_articulos"] = lista_carrito;
                }  



            }        

        catch(Exception)
        {
        Response.Redirect("Error.aspx");
        }
    }

    
            foreach(Articulo item in lista_carrito)
            {
            carrin.importe_total += item.Precio;
            carrin.cantidad_items++;
            }
                

            importe_t.Text += (carrin.cantidad_items);
            cant_items.Text += (carrin.importe_total);
        }
    }
}