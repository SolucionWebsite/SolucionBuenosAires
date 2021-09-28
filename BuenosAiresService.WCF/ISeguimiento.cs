using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BuenosAiresService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISeguimiento" in both code and config file together.
    [ServiceContract]
    public interface ISeguimiento
    {
        [OperationContract]
        List<Seguimiento> SolicitarSeguimiento(int n_compra);
    }
}
