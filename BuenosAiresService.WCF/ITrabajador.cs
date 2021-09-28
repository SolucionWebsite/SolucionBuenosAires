using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BuenosAiresService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITrabajador" in both code and config file together.
    [ServiceContract]
    public interface ITrabajador
    {
        [OperationContract]
        bool Agregar(Trabajador trabajador);

        [OperationContract]
        bool Actualizar(Trabajador trabajador);

        [OperationContract]
        bool Eliminar(int id);

        [OperationContract]
        List<DetalleSolicitud> Solicitudes(int id);

        [OperationContract]
        List<Trabajador> Registros();

        [OperationContract]
        DataSet Trabajadores(string especialidad);
    }
}
