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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Trabajador" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Trabajador.svc or Trabajador.svc.cs at the Solution Explorer and start debugging.
    public class Trabajador : ITrabajador
    {
        public int Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cargo { get; set; }
        public string Especialidad { get; set; }
        public string Email { get; set; }

        DataAccess da = new DataAccess();

        public bool Actualizar(Trabajador trabajador)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ActualizarTrabajador", da.Connection());
                    cmd.CommandText = "ActualizarTrabajador";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();

                    cmd.Parameters.Add("codigoT", trabajador.Codigo);
                    cmd.Parameters.Add("nombresT", trabajador.Nombres);
                    cmd.Parameters.Add("apellidosT", trabajador.Apellidos);
                    cmd.Parameters.Add("cargoT", trabajador.Cargo);
                    cmd.Parameters.Add("especialidadT", trabajador.Especialidad);
                    cmd.Parameters.Add("emailT", trabajador.Email);

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

        public bool Agregar(Trabajador trabajador)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AgregarTrabajador", da.Connection());
                    cmd.CommandText = "AgregarTrabajador";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();

                    cmd.Parameters.Add("nombres", trabajador.Nombres);
                    cmd.Parameters.Add("apellidos", trabajador.Apellidos);
                    cmd.Parameters.Add("cargo", trabajador.Cargo);
                    cmd.Parameters.Add("especialidad", trabajador.Especialidad);
                    cmd.Parameters.Add("email", trabajador.Email);

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

        public bool Eliminar(int id)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("EliminarTrabajador", da.Connection());
                    cmd.CommandText = "EliminarTrabajador";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();

                    cmd.Parameters.Add("id_trabajador", id);
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

        public List<Trabajador> Registros()
        {
            List<Trabajador> Lista = new List<Trabajador>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ListaTrabajador", da.Connection());
                    cmd.CommandText = "ListaTrabajador";
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
                        Trabajador trabajador = new Trabajador();
                        trabajador.Codigo = Convert.ToInt32(reader["trabajador_id"]);
                        trabajador.Nombres = reader["nombres"].ToString();
                        trabajador.Apellidos = reader["apellidos"].ToString();
                        trabajador.Cargo = reader["cargo"].ToString();
                        trabajador.Especialidad = reader["especialidad"].ToString();
                        trabajador.Email = reader["email"].ToString();

                        Lista.Add(trabajador);
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

        public List<DetalleSolicitud> Solicitudes(int id)
        {
            List<DetalleSolicitud> Lista = new List<DetalleSolicitud>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("HistorialSolicitudes", da.Connection());
                    cmd.CommandText = "HistorialSolicitudes";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter();
                    prm.OracleDbType = OracleDbType.RefCursor;
                    prm.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("trabajador", id);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        DetalleSolicitud detalle = new DetalleSolicitud();
                        detalle.Id = reader["solicitud_id"].ToString();
                        detalle.Nombre = reader["nombre"].ToString();
                        detalle.Email = reader["email"].ToString();
                        detalle.Telefono = reader["telefono"].ToString();
                        detalle.Direccion = reader["direccion"].ToString();
                        detalle.Comuna = reader["nombre_comuna"].ToString();
                        detalle.Ciudad = reader["nombre_ciudad"].ToString();
                        detalle.Region = reader["nombre_region"].ToString();
                        detalle.Modalidad = reader["modalidad"].ToString();
                        detalle.Requerimiento = reader["requerimiento"].ToString();
                        string fecha = Convert.ToDateTime(reader["fecha_programada"]).ToShortDateString();
                        detalle.Fecha = fecha;

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

        public DataSet Trabajadores(string especialidad)
        {
            using (da.Connection())
            {
                DataSet trabajador = null;

                try
                {
                    OracleCommand cmd = new OracleCommand("ListarTrabajadores", da.Connection());
                    cmd.CommandText = "ListarTrabajadores";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("cargoT", especialidad);

                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet tabla = new DataSet();
                    adapter.Fill(tabla, "datos");

                    trabajador = tabla;

                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al encontrar registros: " + ex.Message);
                }

                return trabajador;
            }
        }
    }
}
