using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BuenosAiresService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProveedor" in both code and config file together.
    [ServiceContract]
    public interface IProveedor
    {
        [OperationContract]
        bool Agregar(Proveedor proveedor);

        [OperationContract]
        bool Actualizar(Proveedor proveedor);

        [OperationContract]
        bool Eliminar(int _codigo);

        [OperationContract]
        DataTable Registros();

    }
}
