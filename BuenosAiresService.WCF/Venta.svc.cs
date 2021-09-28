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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Venta" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Venta.svc or Venta.svc.cs at the Solution Explorer and start debugging.
    public class Venta : IVenta
    {
        public int N_venta { get; set; }
        public DateTime Fecha { get; set; }
        public string Cupon { get; set; }
        public int Descuento { get; set; }
        public int Total { get; set; }
        public int Entrega { get; set; }
        public int Recibo { get; set; }
        public int Usuario { get; set; }


        DataAccess da = new DataAccess();

        public bool Agregar(Venta venta)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AgregarVenta", da.Connection())
                    {
                        CommandText = "AgregarVenta",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("cupon_nombre", venta.Cupon);
                    cmd.Parameters.Add("usuario", venta.Usuario);
                    cmd.Parameters.Add("entrega", venta.Entrega);
                    cmd.Parameters.Add("recibo", venta.Recibo);

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

        public int UltimaCompra(int _usuario)
        {
            int n_compra = 0;

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("DevolverUltimaCompra", da.Connection())
                    {
                        CommandText = "DevolverUltimaCompra",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    OracleParameter retval = new OracleParameter("orden_compra", OracleDbType.Int32)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    cmd.Parameters.Add(retval);
                    cmd.Parameters.Add(new OracleParameter("usuario", OracleDbType.Int32)).Value = _usuario;
                    cmd.ExecuteNonQuery();
                    n_compra = Int32.Parse(retval.Value.ToString());
                    Console.WriteLine("El n° de compra es {0}", retval.Value);
                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return n_compra;
            }
        }

        public List<DireccionEnvio> DireccionEnvio(int _usuario)
        {
            List<DireccionEnvio> Lista = new List<DireccionEnvio>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("DireccionEnvio", da.Connection())
                    {
                        CommandText = "DireccionEnvio",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter
                    {
                        OracleDbType = OracleDbType.RefCursor,
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("usuario", _usuario);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        DireccionEnvio direccion = new DireccionEnvio
                        {
                            Nombres = reader["nombres"].ToString(),
                            Apellidos = reader["apellidos"].ToString(),
                            Rut = reader["rut"].ToString(),
                            Direccion = reader["direccion"].ToString(),
                            Alias = reader["alias"].ToString(),
                            Telefono = reader["telefono"].ToString(),
                            Comuna = reader["nombre_comuna"].ToString(),
                            Ciudad = reader["nombre_ciudad"].ToString(),
                            Region = reader["nombre_region"].ToString()
                        };

                        Lista.Add(direccion);
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

        public List<DetallePedido> DetallePedido(int n_compra)
        {
            List<DetallePedido> Lista = new List<DetallePedido>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("DetallePedido", da.Connection())
                    {
                        CommandText = "DetallePedido",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter
                    {
                        OracleDbType = OracleDbType.RefCursor,
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("orden_compra", n_compra);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        byte[] byteBLOBData = (Byte[])(reader["imagen"]);
                        
                            DetallePedido detalle = new DetallePedido
                        {
                            Imagen = byteBLOBData.LongLength.ToString(),
                            Producto = reader["producto"].ToString(),
                            Cantidad = reader["cantidad"].ToString(),
                            Precio = reader["precio"].ToString(),
                            Total = reader["total"].ToString()
                        };

                        Lista.Add(detalle);
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

        public List<DetalleVenta> DetalleVenta(int usuario)
        {
            List<DetalleVenta> Lista = new List<DetalleVenta>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("DetalleVenta", da.Connection())
                    {
                        CommandText = "DetalleVenta",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter
                    {
                        OracleDbType = OracleDbType.RefCursor,
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("usuario", usuario);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        DetalleVenta detalle = new DetalleVenta
                        {
                            Orden_compra = reader["n_compra"].ToString(),
                            Nombre = reader["nombre"].ToString(),
                            Subtotal = reader["subtotal"].ToString(),
                            Cupon = reader["cupon"].ToString(),
                            Descuento = reader["descuento"].ToString(),
                            Total = reader["total_venta"].ToString(),
                            Fecha = reader["fecha"].ToString(),
                            Modalidad_entrega = reader["modalidad_entrega"].ToString(),
                            Tipo_comprobante = reader["comprobante"].ToString()
                            
                        };

                        Lista.Add(detalle);
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

        public List<Cupon> ListaCupon(string nombre)
        {
            List<Cupon> Lista = new List<Cupon>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ListaCupon", da.Connection())
                    {
                        CommandText = "ListaCupon",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter
                    {
                        OracleDbType = OracleDbType.RefCursor,
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("nombreC", nombre);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        Cupon cupon = new Cupon
                        {
                            Codigo = Int32.Parse(reader["cupon_id"].ToString()),
                            Nombre = reader["nombre"].ToString(),
                            Descuento = Decimal.Parse(reader["descuento"].ToString())
                        };

                        Lista.Add(cupon);
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

        public List<Cupon> Cupones()
        {
            List<Cupon> Lista = new List<Cupon>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ListaCupones", da.Connection())
                    {
                        CommandText = "ListaCupones",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter
                    {
                        OracleDbType = OracleDbType.RefCursor,
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(prm);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        Cupon cupon = new Cupon
                        {
                            Codigo = Int32.Parse(reader["cupon_id"].ToString()),
                            Nombre = reader["nombre"].ToString(),
                            Descuento = Decimal.Parse(reader["descuento"].ToString())
                        };

                        Lista.Add(cupon);
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

        public List<DetalleCompras> DetalleCompra(int usuario)
        {
            List<DetalleCompras> Lista = new List<DetalleCompras>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("DetalleCompra", da.Connection())
                    {
                        CommandText = "DetalleCompra",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter
                    {
                        OracleDbType = OracleDbType.RefCursor,
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("usuario", usuario);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        DetalleCompras detalle = new DetalleCompras
                        {
                            Orden_compra = reader["orden_compra"].ToString(),
                            Fecha = reader["fecha"].ToString(),
                            Nombre = reader["nombre"].ToString(),
                            Total = reader["total_venta"].ToString(),
                            Estado = reader["estado"].ToString()
                        };

                        Lista.Add(detalle);
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
