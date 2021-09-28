using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BuenosAiresService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILocalidad" in both code and config file together.
    [ServiceContract]
    public interface ILocalidad
    {
        [OperationContract]
        DataSet Regiones();

        [OperationContract]
        DataSet Ciudades(int codigo);

        [OperationContract]
        DataSet Comunas(int codigo);

        [OperationContract]
        bool Buscar(string _comuna);
    }
}
