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
    public class Usuario : IUsuario
    {
        public int Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Rut { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public int Direccion { get; set; }

        DataAccess da = new DataAccess();

        public bool Actualizar(Usuario usuario)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ActualizarUsuario", da.Connection())
                    {
                        CommandText = "ActualizarUsuario",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    
                    cmd.Parameters.Add("nombresU", usuario.Nombres);
                    cmd.Parameters.Add("apellidosU", usuario.Apellidos);
                    cmd.Parameters.Add("rutU", usuario.Rut);
                    cmd.Parameters.Add("emailU", usuario.Email);
                    cmd.Parameters.Add("contrasenaU", usuario.Contrasena);
                    
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

        public bool Agregar(Usuario usuario)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AgregarUsuario", da.Connection())
                    {
                        CommandText = "AgregarUsuario",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("nombres", usuario.Nombres);
                    cmd.Parameters.Add("apellidos", usuario.Apellidos);
                    cmd.Parameters.Add("rut", usuario.Rut);
                    cmd.Parameters.Add("email", usuario.Email);
                    cmd.Parameters.Add("contrasena", usuario.Contrasena);

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

        public bool Eliminar(string _email)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("EliminarUsuario", da.Connection())
                    {
                        CommandText = "EliminarUsuario",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("email_id", _email);
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

        public List<Usuario> Registros()
        {
            List<Usuario> Lista = new List<Usuario>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ListaUsuario", da.Connection())
                    {
                        CommandText = "ListaUsuario",
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
                        Usuario usuario = new Usuario
                        {
                            Codigo = Convert.ToInt32(reader["usuario_id"]),
                            Nombres = reader["nombres"].ToString(),
                            Apellidos = reader["apellidos"].ToString(),
                            Rut = reader["rut"].ToString(),
                            Email = reader["email"].ToString(),
                            Contrasena = reader["contrasena"].ToString()
                        };

                        Lista.Add(usuario);
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

        public bool AgregarDireccion(string direccion, int localidad, int telefono, string alias, string usuario)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AgregarDireccion", da.Connection())
                    {
                        CommandText = "AgregarDireccion",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("direccion", direccion);
                    cmd.Parameters.Add("localidad", localidad);
                    cmd.Parameters.Add("telefono", telefono);
                    cmd.Parameters.Add("alias_domicilio", alias);
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

        public List<Historial> HistorialPedidos(int usuario)
        {
            List<Historial> Lista = new List<Historial>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ConsultarHistorialPedidos", da.Connection())
                    {
                        CommandText = "ConsultarHistorialPedidos",
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
                        Historial historial = new Historial
                        {
                            Orden_compra = reader["orden_compra"].ToString(),
                            Fecha_compra = reader["fecha_compra"].ToString(),
                            Estado = reader["estado"].ToString(),
                            Fecha = reader["fecha"].ToString()
                        };

                        Lista.Add(historial);
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

        public bool AgregarSolicitud(Solicitud solicitud)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("AgregarSolicitud", da.Connection())
                    {
                        CommandText = "AgregarSolicitud",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("usuario", solicitud.Usuario);
                    cmd.Parameters.Add("servicio", solicitud.Tipo_servicio);
                    cmd.Parameters.Add("trabajador", solicitud.Trabajador);
                    cmd.Parameters.Add("fecha", solicitud.Fecha);
                    cmd.Parameters.Add("requerimiento", solicitud.Requerimiento);

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
