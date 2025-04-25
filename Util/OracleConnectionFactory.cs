using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace ATBM_HTTT_PH1.Util
{
    public class OracleConnectionFactory
    {
        private readonly string connectionString;

        public OracleConnectionFactory(string _connectionString)
        {
            connectionString = _connectionString;
        }
        public OracleConnection createConnection()
        {
            try
            {
                var connection = new OracleConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch(Exception e)
            {
                throw new InvalidOperationException("Could not establish connection to the Oracle database.", e);
            }
        }

    }
}
