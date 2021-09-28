using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BuenosAiresService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBodega" in both code and config file together.
    [ServiceContract]
    public interface IBodega
    {
        [OperationContract]
        bool AgregarStock(int _codigo, int _cantidad);

        [OperationContract]
        int ConsultarStock(int _codigo);
    }
}
