using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace PagoService.WCF
{
    public class DataAccess
    {
        public OracleConnection Connection()
        {
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id=BD_PAGO;Password=123;";

            return new OracleConnection(connectionString);
        }
    }
}