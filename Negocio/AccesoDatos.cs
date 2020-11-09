﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    class AccesoDatos
    {
        public SqlDataReader lector { get; set; }
        public SqlConnection conexion { get; set; }
        //public SqlConnection conexion_aws { get; set; }
        public SqlCommand comando { get; set; }

        public AccesoDatos()
        {
        conexion = new SqlConnection("data source=DESKTOP-PEA82KB\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi");
            //conexion_aws = new SqlConnection("");    
            comando = new SqlCommand();
            comando.Connection = conexion;


        }

        public void setearQuery(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }


        public void setearSP(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;

        
        }

        public void agregarParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void ejecutarLector()
        {
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally { conexion.Close(); }

        }

        public void cerrarConexion()
        {
            conexion.Close();
        
        }

        internal void ejecutarAccion()
        {
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally { conexion.Close(); }
        }
    
    }
}
