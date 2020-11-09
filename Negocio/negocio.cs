using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Articulo> lista = new List<Articulo>();

            conexion.ConnectionString = "data source=DESKTOP-PEA82KB\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "select P.id,P.Codigo,P.nombre,P.descripcion,M.Descripcion,T.Descripcion,P.ImagenUrl,P.Precio from ARTICULOS P, MARCAS M, CATEGORIAS T Where P.IdCategoria=T.Id and P.IdMarca=M.Id";

            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Articulo aux = new Articulo();
                aux.id = (int)lector["id"]; ;
                aux.codigo = lector.GetString(1);

                aux.Nombre = lector.GetString(2);
                aux.Descripcion = lector.GetString(3);

                aux.marca = new Marca();
                aux.marca.Descripcion = lector.GetString(4);

                aux.categoria = new Categoria();
                aux.categoria.Descripcion = lector.GetString(5);


                aux.Precio = (decimal)lector["Precio"];


                aux.ImageUrl = lector.GetString(6);


                lista.Add(aux);
            }
            conexion.Close();
            return lista;
        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.setearQuery("Update ARTICULOS set Codigo=@Codigo, Nombre=@Nombre,Descripcion=@Descripcion,IdMarca=@IdMarca,IdCategoria=@IdCategoria,ImagenUrl=@imagenUrl,Precio=@Precio Where Id=@id");
                conexion.agregarParametro("@Id", articulo.id);
                conexion.agregarParametro("@Codigo", articulo.codigo);
                conexion.agregarParametro("@Nombre", articulo.Nombre);
                conexion.agregarParametro("@Descripcion", articulo.Descripcion);
                conexion.agregarParametro("@IdMarca", articulo.marca.Id);
                conexion.agregarParametro("@IdCategoria", articulo.categoria.Id);
                conexion.agregarParametro("@ImagenUrl", articulo.ImageUrl);
                conexion.agregarParametro("@Precio", articulo.Precio);
                conexion.ejecutarAccion();
            }

            catch (Exception ex)
            { throw ex; }

        }


        public void eliminar(int id)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.setearQuery("Delete from ARTICULOS Where Id=@id");
                conexion.agregarParametro("@id", id);
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void agregar(Articulo nuevo)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                conexion.ConnectionString = "data source=DESKTOP-PEA82KB\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into ARTICULOS (Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values('" + nuevo.Nombre + "','" + nuevo.Descripcion + "','" + nuevo.marca.Id + "','" + nuevo.categoria.Id + "','" + nuevo.ImageUrl + "','" + nuevo.Precio + "')";
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();



            }
            catch (Exception)
            {
                throw;
            }





        }

    }
}
