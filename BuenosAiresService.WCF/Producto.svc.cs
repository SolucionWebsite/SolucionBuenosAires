using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BuenosAiresService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Producto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Producto.svc or Producto.svc.cs at the Solution Explorer and start debugging.
    public class Producto : IProducto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Proveedor { get; set; }
        public Byte[] Imagen { get; set; }

        DataAccess da = new DataAccess();

        public bool Actualizar(Producto producto)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ActualizarProducto", da.Connection());
                    cmd.CommandText = "ActualizarProducto";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();

                    cmd.Parameters.Add("codigoP", producto.Codigo);
                    cmd.Parameters.Add("nombreP", producto.Nombre);
                    cmd.Parameters.Add("descripcionP", producto.Descripcion);
                    cmd.Parameters.Add("PrecioP", producto.Precio);
                    cmd.Parameters.Add("proveedorP", producto.Proveedor);
                    cmd.Parameters.Add("imagenP", producto.Imagen);

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

        public bool Agregar(Producto producto)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AgregarProducto", da.Connection());
                    cmd.CommandText = "AgregarProducto";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();

                    cmd.Parameters.Add("nombre", producto.Nombre);
                    cmd.Parameters.Add("descripcion", producto.Descripcion);
                    cmd.Parameters.Add("Precio", producto.Precio);
                    cmd.Parameters.Add("Proveedor", producto.Proveedor);
                    cmd.Parameters.Add("imagen", producto.Imagen);


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

        public bool Eliminar(int _codigo)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("EliminarProducto", da.Connection());
                    cmd.CommandText = "EliminarProducto";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();

                    cmd.Parameters.Add("codigo", _codigo);
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

        public DataTable Registros()
        {
            using (da.Connection())
            {
                DataTable tabla = null;

                try
                {
                    OracleCommand cmd = new OracleCommand("ListarProducto", da.Connection());
                    cmd.CommandText = "ListarProducto";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    tabla = table;

                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al encontrar registros: " + ex.Message);
                }

                return tabla;
            }
        }

        public List<Producto> Listar()
        {
            List<Producto> Lista = new List<Producto>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ListarProducto", da.Connection());
                    cmd.CommandText = "ListarProducto";
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
                        Producto producto = new Producto();
                        producto.Codigo = Convert.ToInt32(reader["producto_id"]);
                        producto.Nombre = reader["nombre"].ToString();
                        producto.Descripcion = reader["descripción"].ToString();
                        producto.Precio = Convert.ToInt32(reader["precio"]);
                        producto.Proveedor = Convert.ToInt32(reader["proveedor_proveedor_id"]);

                        byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])(reader["imagen"]);

                        producto.Imagen = byteBLOBData;

                        Lista.Add(producto);
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
    }
    
}
