using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BuenosAiresService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVenta" in both code and config file together.
    [ServiceContract]
    public interface IVenta
    {
        [OperationContract]
        bool Agregar(Venta venta);

        [OperationContract]
        int UltimaCompra(int _usuario);

        [OperationContract]
        List<DireccionEnvio> DireccionEnvio(int usuario);

        [OperationContract]
        List<DetallePedido> DetallePedido(int n_compra);

        [OperationContract]
        List<DetalleVenta> DetalleVenta(int usuario);

        [OperationContract]
        List<DetalleCompras> DetalleCompra(int n_compra);

        [OperationContract]
        List<Cupon> ListaCupon(string nombre);

        [OperationContract]
        List<Cupon> Cupones();
    }
}
