using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BuenosAiresService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuario" in both code and config file together.
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        bool Agregar(Usuario usuario);

        [OperationContract]
        bool Actualizar(Usuario usuario);

        [OperationContract]
        bool Eliminar(string _email);

        [OperationContract]
        bool AgregarDireccion(string direccion, int localidad, int telefono, string alias, string usuario);

        [OperationContract]
        bool AgregarSolicitud(Solicitud solicitud);

        [OperationContract]
        List<Historial> HistorialPedidos(int usuario);

        [OperationContract]
        List<Usuario> Registros();
        
    }
}
