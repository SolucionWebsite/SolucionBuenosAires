using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AMWOService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductos" in both code and config file together.
    [ServiceContract]
    public interface IProductos
    {
        [OperationContract]
        int ConsultarStock(int _codigo);

        [OperationContract]
        List<Productos> ListarProductos();

        [OperationContract]
        bool ActualizarProducto(int codigo, byte[] imagen);
    }
}
