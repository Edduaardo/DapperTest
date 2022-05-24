using System.Data;

namespace DapperTest.SharedKernel.Interfaces
{
    public interface IDatabaseConnection
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; set; }
    }
}
