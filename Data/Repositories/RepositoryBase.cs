using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repositories
{
    internal class RepositoryBase
    {
#if DEBUG
        private const string CONNECTIONSTRING_KEY = "connection_string_teste";
#else
        private const string CONNECTIONSTRING_KEY = "connection_string_producao";
#endif
        
        private IDbConnection connection;
        internal IDbConnection Connection
        {
            get
            {
                return connection;
            }

            set
            {
                connection = value;
            }
        }

        public RepositoryBase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTIONSTRING_KEY].ConnectionString;
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException("Connection string not found");
            }

            Connection = new SqlConnection(connectionString);
        }
    }
}
