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
    public partial class Productos : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        public List<Articulo> listaBuscar { get; set; }
        int extra;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                extra = Convert.ToInt32(Request.QueryString["extra"]);

                listaArticulos = negocio.listar();
                Session.Add("ListaArticulos", listaArticulos);

                if (extra == 0)
                {
                    listaBuscar = new List<Articulo>();
                    Session.Add("listaBuscar", listaBuscar);
                }
            }
            catch (Exception ex)
            {

              
            //Response.Redirect("Error.aspx");
            }
        }

        protected void Btn_Buscar(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try 
            {
                if (txt_buscar.Text == "")
                {
                    listaBuscar = negocio.listar();
                    Session.Add("listaBuscar", listaBuscar);

                }
                else 
                {
                listaBuscar = listaArticulos.FindAll(K => K.Nombre.ToUpper().Contains(txt_buscar.Text.ToUpper()) || K.Descripcion.ToUpper().Contains(txt_buscar.Text.ToUpper()) || K.codigo.ToUpper().Contains(txt_buscar.Text.ToUpper()) || K.categoria.Descripcion.ToUpper().Contains(txt_buscar.Text.ToUpper()) || K.marca.Descripcion.ToUpper().Contains(txt_buscar.Text.ToUpper()));
                Session.Add("listaBuscar", listaBuscar); 
                Response.Redirect("Productos.aspx?extra=1");


                }
            }

            catch(Exception ex)
            { 
            }

        }


    }
}