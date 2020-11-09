using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Dominio
{
    public class Articulo
    {
        public int id { get; set; }
        
        public string codigo { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public SqlMoney Precio { get; set; }

        public string ImageUrl{ get; set; }

        public Marca marca { get; set; }

        public Categoria categoria { get; set; }
       
    }


}
