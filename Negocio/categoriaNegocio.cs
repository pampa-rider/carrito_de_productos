using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class categoriaNegocio
    {
        public List<Categoria> listar()
        {

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Categoria> lista = new List<Categoria>();

            conexion.ConnectionString = "data source=DESKTOP-PEA82KB\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select Id,Descripcion from CATEGORIAS";
            comando.Connection = conexion;

            conexion.Open();


            lector = comando.ExecuteReader();
            while (lector.Read())
            {
            lista.Add(new Categoria((int)lector["Id"], (string)lector["Descripcion"]));
            }

            lector.Close();
            conexion.Close();
            return lista;
        }

    }
}
