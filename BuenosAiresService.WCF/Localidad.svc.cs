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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Localidad" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Localidad.svc or Localidad.svc.cs at the Solution Explorer and start debugging.
    public class Localidad : ILocalidad
    {
        public int Locacion { get; set; }
        public string Region { get; set; }
        public string Ciudad { get; set; }
        public string Comuna { get; set; }

        DataAccess da = new DataAccess();

        public bool Buscar(string _comuna)
        {
            throw new NotImplementedException();
        }

        public DataSet Ciudades(int codigo)
        {
            using (da.Connection())
            {
                DataSet ciudad = null;

                try
                {
                    OracleCommand cmd = new OracleCommand("ListarCiudad", da.Connection());
                    cmd.CommandText = "ListarCiudad";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("codigo", codigo);

                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet tabla = new DataSet();
                    adapter.Fill(tabla, "datos");

                    ciudad = tabla;

                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al encontrar registros: " + ex.Message);
                }

                return ciudad;
            }
        }

        public DataSet Comunas(int codigo)
        {
            using (da.Connection())
            {
                DataSet comuna = null;

                try
                {
                    OracleCommand cmd = new OracleCommand("ListarComuna", da.Connection());
                    cmd.CommandText = "ListarComuna";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("codigo", codigo);

                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet tabla = new DataSet();
                    adapter.Fill(tabla, "datos");

                    comuna = tabla;

                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al encontrar registros: " + ex.Message);
                }

                return comuna;
            }
        }

        public DataSet Regiones()
        {
            using (da.Connection())
            {
                DataSet region = null;

                try
                {
                    OracleCommand cmd = new OracleCommand("ListarRegion", da.Connection());
                    cmd.CommandText = "ListarRegion";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet tabla = new DataSet();
                    adapter.Fill(tabla, "datos");

                    region = tabla;

                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al encontrar registros: " + ex.Message);
                }

                return region;
            }
        }
    }
}
