using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BuenosAiresService.WCF
{
    public class Bodega : IBodega
    {
        DataAccess da = new DataAccess();

        public bool AgregarStock(int _codigo, int _cantidad)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AgregarStock", da.Connection())
                    {
                        CommandText = "AgregarStock",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("cantidad", _cantidad);
                    cmd.Parameters.Add("producto", _codigo);

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

        public int ConsultarStock(int _codigo)
        {
            int stock = 0;

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ConsultarStock", da.Connection())
                    {
                        CommandText = "ConsultarStock",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    OracleParameter retval = new OracleParameter("stock", OracleDbType.Int32)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
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
    }
}
