using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {
        public static string InsertarCategoria(string nombre, string descripcion)
        {
            DCategoria dCategoria = new DCategoria();
            dCategoria.Nombre = nombre;
            dCategoria.Descripcion = descripcion;

            return dCategoria.InsertarCategoria(dCategoria);
        }

        public static string EditarCategoria(int idCategoria, string nombre, string descripcion)
        {
            DCategoria dCategoria = new DCategoria();
            dCategoria.IdCategoria = idCategoria;
            dCategoria.Nombre = nombre;
            dCategoria.Descripcion = descripcion;

            return dCategoria.EditarCategoria(dCategoria);
        }

        public static string EliminarCategoria(int idCategoria)
        {
            DCategoria dCategoria = new DCategoria();
            dCategoria.IdCategoria = idCategoria;

            return dCategoria.EliminarCategoria(dCategoria);
        }

        public static DataTable MostrarCategoria()
        {
            return new DCategoria().MostrarCategoria();
        }

        public static DataTable BuscarNombre(string textoBuscar)
        {
            DCategoria dCategoria = new DCategoria();
            dCategoria.TextoBuscar = textoBuscar;

            return dCategoria.BuscarNombreCategoria(dCategoria);
        }
    }
}
