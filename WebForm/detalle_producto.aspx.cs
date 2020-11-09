using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class detalle_producto : System.Web.UI.Page
    {
        public Articulo mostrar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_item = Request.QueryString["id"];
            try 
            {
                mostrar = ((List<Articulo>)Session.Contents["ListaArticulos"]).Find(X => X.id.ToString().Contains(id_item));
            }

            catch (Exception ex)
            {
                Session.Add("ErrorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
                throw;
            }
        }
    }
}