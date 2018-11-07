using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using laboratorio_11.Models;

namespace laboratorio_11.Repository
{
    public class ProductoRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["Tecsup"].ToString();
            con = new SqlConnection(constr);
        }

        // Agregar Producto
        public bool AddProducto(ProductoModel obj)
        {
            connection();

            SqlCommand com = new SqlCommand("AddNewProducto", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IdProducto", obj.IdProducto);
            com.Parameters.AddWithValue("@NombreProducto", obj.NombreProducto);
            com.Parameters.AddWithValue("@IdProv", obj.IdProveedor);
            com.Parameters.AddWithValue("@IdCat", obj.IdCategoria);
            com.Parameters.AddWithValue("@CantidadUni", obj.CantidadPorUnidad);
            com.Parameters.AddWithValue("@PrecioUni", obj.PrecioUnidad);
            com.Parameters.AddWithValue("@UniExistencia", obj.UnidadesEnExistencia);
            com.Parameters.AddWithValue("@UniPedido", obj.UnidadesEnPedido);
            com.Parameters.AddWithValue("@NivelNuevoPedido", obj.NivelNuevoPedido);
            com.Parameters.AddWithValue("@Suspendido", obj.Suspendido);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Lista de datos  de Productos
        public List<ProductoModel> GetAllProductos()
        {
            connection();

            List<ProductoModel> ProdList = new List<ProductoModel>();
            SqlCommand com = new SqlCommand("GetProductos", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            // Recorrrer los datos del datatable dt
            foreach (DataRow dr in dt.Rows)
            {
                ProdList.Add(new ProductoModel
                {
                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                    NombreProducto = Convert.ToString(dr["NombreProducto"]),
                    IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                    IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                    CantidadPorUnidad = Convert.ToString(dr["CantidadPorUnidad"]),
                    PrecioUnidad = Convert.ToDecimal(dr["PrecioUnidad"]),
                    UnidadesEnExistencia = Convert.ToInt32(dr["UnidadesEnExistencia"]),
                    UnidadesEnPedido = Convert.ToInt32(dr["UnidadesEnPedido"]),
                    NivelNuevoPedido = Convert.ToInt32(dr["NivelNuevoPedido"]),
                    Suspendido = Convert.ToBoolean(dr["Suspendido"])
                });
            }

            return ProdList;
        }


        // Editar Producto
        public bool UpdateProducto(ProductoModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateProducto", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IdProducto", obj.IdProducto);
            com.Parameters.AddWithValue("@NombreProducto", obj.NombreProducto);
            com.Parameters.AddWithValue("@IdProv", obj.IdProveedor);
            com.Parameters.AddWithValue("@IdCat", obj.IdCategoria);
            com.Parameters.AddWithValue("@CantidadUni", obj.CantidadPorUnidad);
            com.Parameters.AddWithValue("@PrecioUni", obj.PrecioUnidad);
            com.Parameters.AddWithValue("@UniExistencia", obj.UnidadesEnExistencia);
            com.Parameters.AddWithValue("@UniPedido", obj.UnidadesEnPedido);
            com.Parameters.AddWithValue("@NivelNuevoPedido", obj.NivelNuevoPedido);
            com.Parameters.AddWithValue("@Suspendido", obj.Suspendido);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Eliminar Producto
        public bool DeleteProducto(int id)
        {
            connection();

            SqlCommand com = new SqlCommand("DeleteProducto", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IdProducto", id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}