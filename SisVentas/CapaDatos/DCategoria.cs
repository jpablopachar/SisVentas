using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    class DCategoria
    {
        private int idCategoria;
        private string nombre;
        private string descripcion;
        private string textoBuscar;

        public DCategoria()
        {
        }

        public DCategoria(int idCategoria, string nombre, string descripcion, string textoBuscar)
        {
            this.idCategoria = idCategoria;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.textoBuscar = textoBuscar;
        }

        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string TextoBuscar { get => textoBuscar; set => textoBuscar = value; }

        public string InsertarCategoria(DCategoria categoria)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "spInsertarCategoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParIdCategoria = new SqlParameter();
                sqlParIdCategoria.ParameterName = "@idCategoria";
                sqlParIdCategoria.SqlDbType = SqlDbType.Int;
                sqlParIdCategoria.Direction = ParameterDirection.Output;

                sqlCmd.Parameters.Add(sqlParIdCategoria);

                SqlParameter sqlParNombre = new SqlParameter();
                sqlParNombre.ParameterName = "@nombre";
                sqlParNombre.SqlDbType = SqlDbType.VarChar;
                sqlParNombre.Size = 50;
                sqlParNombre.Value = categoria.Nombre;

                sqlCmd.Parameters.Add(sqlParNombre);

                SqlParameter sqlParDescripcion = new SqlParameter();
                sqlParDescripcion.ParameterName = "@descripcion";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 256;
                sqlParDescripcion.Value = categoria.Descripcion;

                sqlCmd.Parameters.Add(sqlParDescripcion);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return rpta;
        }

        public string EditarCategoria(DCategoria categoria)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;

                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "spEditarCategoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParIdCategoria = new SqlParameter();
                sqlParIdCategoria.ParameterName = "@idCategoria";
                sqlParIdCategoria.SqlDbType = SqlDbType.Int;
                sqlParIdCategoria.Value = categoria.IdCategoria;

                sqlCmd.Parameters.Add(sqlParIdCategoria);

                SqlParameter sqlParNombre = new SqlParameter();
                sqlParNombre.ParameterName = "@nombre";
                sqlParNombre.SqlDbType = SqlDbType.VarChar;
                sqlParNombre.Size = 50;
                sqlParNombre.Value = categoria.Nombre;

                sqlCmd.Parameters.Add(sqlParNombre);

                SqlParameter sqlParDescripcion = new SqlParameter();
                sqlParDescripcion.ParameterName = "@descripcion";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 256;
                sqlParDescripcion.Value = categoria.Descripcion;

                sqlCmd.Parameters.Add(sqlParDescripcion);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se editó el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return rpta;
        }

        public string EliminarCategoria(DCategoria categoria)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "spEliminarCategoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParIdCategoria = new SqlParameter();
                sqlParIdCategoria.ParameterName = "@idCategoria";
                sqlParIdCategoria.SqlDbType = SqlDbType.Int;
                sqlParIdCategoria.Value = categoria.IdCategoria;

                sqlCmd.Parameters.Add(sqlParIdCategoria);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return rpta;
        }

        public DataTable MostrarCategoria()
        {
            DataTable dtResultado = new DataTable("Categoria");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "spMostrarCategoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable BuscarNombreCategoria(DCategoria categoria)
        {
            DataTable dtResultado = new DataTable("Categoria");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "spBuscarNombreCategoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParTextoBuscar = new SqlParameter();
                sqlParTextoBuscar.ParameterName = "@textoBuscar";
                sqlParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                sqlParTextoBuscar.Size = 50;
                sqlParTextoBuscar.Value = categoria.TextoBuscar;
                sqlCmd.Parameters.Add(sqlParTextoBuscar);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }
    }
}
