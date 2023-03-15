using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;

namespace DanielsMoneyManagerApi.Data
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevDatabase");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
