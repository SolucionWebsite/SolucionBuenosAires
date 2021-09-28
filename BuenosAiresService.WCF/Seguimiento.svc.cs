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
      public class Seguimiento : ISeguimiento
    {
        public string Orden_compra { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }

        DataAccess da = new DataAccess();

        public List<Seguimiento> SolicitarSeguimiento(int n_compra)
        {
            List<Seguimiento> Lista = new List<Seguimiento>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("SolicitarSeguimiento", da.Connection());
                    cmd.CommandText = "SolicitarSeguimiento";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter();
                    prm.OracleDbType = OracleDbType.RefCursor;
                    prm.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("n_compra", n_compra);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        Seguimiento seguimiento = new Seguimiento();
                        seguimiento.Orden_compra = reader["orden_compra"].ToString();
                        seguimiento.Estado = reader["estado"].ToString();
                        seguimiento.Fecha = reader["fecha"].ToString();

                        Lista.Add(seguimiento);
                    }
                    cmd.Connection.Close();

                }
                catch (Exception)
                {
                    Console.WriteLine("No se encuentran registros");
                }

                return Lista;
            }
        }
    }
    
}
