using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class TipoNegocio
    {
        public List<Marca> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Marca> lista = new List<Marca>();
            
            conexion.ConnectionString = "data source=DESKTOP-PEA82KB\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select Id,Descripcion from MARCAS";
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
            lista.Add(new Marca((int)lector["Id"], (string)lector["Descripcion"]));
            }

            lector.Close();
            conexion.Close();
            return lista;
        }

    }
}
