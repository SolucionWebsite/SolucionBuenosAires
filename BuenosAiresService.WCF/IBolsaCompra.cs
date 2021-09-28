using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BuenosAiresService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBolsaCompra" in both code and config file together.
    [ServiceContract]
    public interface IBolsaCompra
    {
        [OperationContract]
        bool Agregar(int producto, int cantidad, string usuario);
        
        [OperationContract]
        bool Actualizar(string _usuario, int _producto, int _cantidad);

        [OperationContract]
        bool Eliminar(int _producto, string _usuario);

        [OperationContract]
        List<BolsaCompra> Listar(string _usuario);
    }
}
