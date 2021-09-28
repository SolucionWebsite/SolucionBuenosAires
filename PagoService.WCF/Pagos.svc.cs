using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PagoService.WCF
{
    public class Pagos : IPagos
    {
        public int N_tarjeta { get; set; }
        public string Fecha_vencimiento { get; set; }
        public int Codigo_seguridad { get; set; }
        public string Banco { get; set; }
        public string Rut { get; set; }
        public int Clave { get; set; }
        public int C_1 { get; set; }
        public int C_2 { get; set; }
        public int C_3 { get; set; }
        public int Total_pago { get; set; }
        public int Usuario { get; set; }
        public int Orden_compra { get; set;}

        DataAccess da = new DataAccess();

        public DataTable FormaPago()
        {
            using (da.Connection())
            {
                DataTable tabla = null;

                try
                {
                    OracleCommand cmd = new OracleCommand("Listar", da.Connection())
                    {
                        CommandText = "Listar",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataAdapter adapter = new OracleDataAdapter
                    {
                        SelectCommand = cmd
                    };
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


        public bool PagoCredito(Pagos pagos)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AgregarPagoCredito", da.Connection())
                    {
                        CommandText = "AgregarPagoCredito",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("n_tarjeta", pagos.N_tarjeta);
                    cmd.Parameters.Add("fecha", pagos.Fecha_vencimiento);
                    cmd.Parameters.Add("codigo", pagos.Codigo_seguridad);
                    cmd.Parameters.Add("total", pagos.Total_pago);
                    cmd.Parameters.Add("usuario", pagos.Usuario);

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

        public bool PagoDebito(Pagos pagos)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AgregarPagoDebito", da.Connection())
                    {
                        CommandText = "AgregarPagoDebito",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("banco", pagos.Banco);
                    cmd.Parameters.Add("rut", pagos.Rut);
                    cmd.Parameters.Add("clave", pagos.Clave);
                    cmd.Parameters.Add("c_1", pagos.C_1);
                    cmd.Parameters.Add("c_2", pagos.C_2);
                    cmd.Parameters.Add("c_3", pagos.C_3);
                    cmd.Parameters.Add("total", pagos.Total_pago);
                    cmd.Parameters.Add("usuario", pagos.Usuario);

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

        public bool AsociarCompra(int n_compra, int usuario)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AsociarCompra", da.Connection())
                    {
                        CommandText = "AsociarCompra",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("n_compra", n_compra);
                    cmd.Parameters.Add("usuario_id", usuario);

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

        public List<Pago> DetallePago(int n_compra)
        {
            List<Pago> Lista = new List<Pago>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("DetallePago", da.Connection())
                    {
                        CommandText = "DetallePago",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter
                    {
                        OracleDbType = OracleDbType.RefCursor,
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("n_compra", n_compra);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        Pago pago = new Pago
                        {
                            Medio_pago = reader["metodo_pago"].ToString(),
                            Orden_compra = reader["orden_compra"].ToString()
                        };

                        Lista.Add(pago);
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
