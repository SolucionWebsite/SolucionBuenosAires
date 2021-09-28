using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PagoService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPagos" in both code and config file together.
    [ServiceContract]
    public interface IPagos
    {
        [OperationContract]
        DataTable FormaPago();

        [OperationContract]
        bool PagoDebito(Pagos pagos);

        [OperationContract]
        bool PagoCredito(Pagos pagos);

        [OperationContract]
        bool AsociarCompra(int n_compra, int usuario);

        [OperationContract]
        List<Pago> DetallePago(int n_compra);
    }
}
