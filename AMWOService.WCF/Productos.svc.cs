using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AMWOService.WCF
{
    public class Productos : IProductos
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public Byte[] Imagen { get; set; }


        DataAccess da = new DataAccess();

        public int ConsultarStock(int _codigo)
        {
            int stock = 0;

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ConsultarStock", da.Connection());
                    cmd.CommandText = "ConsultarStock";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    OracleParameter retval = new OracleParameter("stock", OracleDbType.Int32);
                    retval.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(retval);
                    cmd.Parameters.Add(new OracleParameter("codigo", OracleDbType.Int32)).Value = _codigo;
                    cmd.ExecuteNonQuery();
                    stock = Int32.Parse(retval.Value.ToString());
                    Console.WriteLine("El stock es {0}", retval.Value);
                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return stock;
            }
        }

        public List<Productos> ListarProductos()
        {
            List<Productos> Lista = new List<Productos>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ListarProductos", da.Connection());
                    cmd.CommandText = "ListarProductos";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter();
                    prm.OracleDbType = OracleDbType.RefCursor;
                    prm.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(prm);
                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        Productos productos = new Productos();
                        productos.Codigo = Convert.ToInt32(reader["codigo_producto"]);
                        productos.Nombre = reader["nombre"].ToString();
                        productos.Descripcion = reader["descripcion"].ToString();
                        productos.Precio = Convert.ToInt32(reader["precio"]);
                        productos.Stock = Convert.ToInt32(reader["cantidad"]);
                        byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])(reader["imagen"]);
                        productos.Imagen = byteBLOBData;

                        Lista.Add(productos);
                    }
                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return Lista;
            }

        }

        public bool ActualizarProducto(int codigo, byte[] imagen)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AgregarImagen", da.Connection());
                    cmd.CommandText = "AgregarImagen";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();

                    cmd.Parameters.Add("codigo", codigo);
                    cmd.Parameters.Add("imagen_p", imagen);

                    cmd.ExecuteNonQuery();

                    cmd.Connection.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
