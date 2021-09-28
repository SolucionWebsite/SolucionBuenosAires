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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BolsaCompra" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BolsaCompra.svc or BolsaCompra.svc.cs at the Solution Explorer and start debugging.
    public class BolsaCompra : IBolsaCompra
    {
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }
        public string Usuario { get; set; }
        public string Imagen { get; set; }

        DataAccess da = new DataAccess();

        public bool Agregar(int producto, int cantidad, string usuario)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AgregarBolsa", da.Connection())
                    {
                        CommandText = "AgregarBolsa",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("producto", producto);
                    cmd.Parameters.Add("cantidad", cantidad);
                    cmd.Parameters.Add("usuario", usuario);

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

        public bool Eliminar(int _producto, string _usuario)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("EliminarProductoBolsa", da.Connection())
                    {
                        CommandText = "EliminarProductoBolsa",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("producto", _producto);
                    cmd.Parameters.Add("usuario", _usuario);
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

        public List<BolsaCompra> Listar(string _usuario)
        {
            List<BolsaCompra> Lista = new List<BolsaCompra>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ListaBolsa", da.Connection())
                    {
                        CommandText = "ListaBolsa",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter
                    {
                        OracleDbType = OracleDbType.RefCursor,
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("usuario",_usuario);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        byte[] byteBLOBData = (Byte[])(reader["IMAGEN"]);
                        
                        BolsaCompra bolsa = new BolsaCompra
                        {
                            Imagen = byteBLOBData.LongLength.ToString(),
                            Producto = reader["nombre"].ToString(),
                            Codigo = reader["producto_producto_id"].ToString(),
                            Cantidad = reader["cantidad"].ToString(),
                            Total = reader["precio_total"].ToString()
                    };

                        Lista.Add(bolsa);
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

        public bool Actualizar(string _usuario, int _producto, int _cantidad)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ActualizarCompra", da.Connection())
                    {
                        CommandText = "ActualizarCompra",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("producto", _producto);
                    cmd.Parameters.Add("cantidad", _cantidad);
                    cmd.Parameters.Add("usuario", _usuario);

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
