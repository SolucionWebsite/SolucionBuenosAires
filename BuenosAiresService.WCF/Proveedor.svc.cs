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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Proveedor" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Proveedor.svc or Proveedor.svc.cs at the Solution Explorer and start debugging.
    public class Proveedor : IProveedor
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int Localidad { get; set; }

        DataAccess da = new DataAccess();

        public bool Actualizar(Proveedor proveedor)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ActualizarProveedor", da.Connection());
                    cmd.CommandText = "ActualizarProveedor";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    
                    cmd.Parameters.Add("codigoP", proveedor.Codigo);
                    cmd.Parameters.Add("nombreP", proveedor.Nombre);
                    cmd.Parameters.Add("emailP", proveedor.Email);
                    cmd.Parameters.Add("direccionP", proveedor.Direccion);
                    cmd.Parameters.Add("telefonoP", proveedor.Telefono);
                    cmd.Parameters.Add("localidadP", proveedor.Localidad);
                    
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

        public bool Agregar(Proveedor proveedor)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AgregarProveedor", da.Connection());
                    cmd.CommandText = "AgregarProveedor";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    
                    cmd.Parameters.Add("nombre", proveedor.Nombre);
                    cmd.Parameters.Add("email", proveedor.Email);
                    cmd.Parameters.Add("direccion", proveedor.Direccion);
                    cmd.Parameters.Add("telefono", proveedor.Telefono);
                    cmd.Parameters.Add("localidad", proveedor.Localidad);
                    
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
                    OracleCommand cmd = new OracleCommand("EliminarProveedor", da.Connection());
                    cmd.CommandText = "EliminarProveedor";
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
                    OracleCommand cmd = new OracleCommand("ListarProveedor", da.Connection());
                    cmd.CommandText = "ListarProveedor";
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
    }
}
