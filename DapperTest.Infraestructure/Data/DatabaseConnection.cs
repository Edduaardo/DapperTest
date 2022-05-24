using DapperTest.SharedKernel.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;

namespace DapperTest.Infraestructure.Data
{
    public class DatabaseConnection : IDatabaseConnection, IDisposable
    {
        private readonly Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DatabaseConnection(IConfiguration configuration)
        {
            _id = Guid.NewGuid();
            Connection = new SqlConnection(configuration.GetConnectionString("Default"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
