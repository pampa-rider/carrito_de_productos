using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
 public class carro
    {
        public SqlMoney importe_total { get; set; }
        public int cantidad_items { get; set; }

  
    public carro()
    {
        importe_total = 0;
        cantidad_items = 0;
    }

    }
}
