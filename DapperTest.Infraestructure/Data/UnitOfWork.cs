using DapperTest.SharedKernel.Interfaces;

namespace DapperTest.Infraestructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseConnection _dbConnection;

        public UnitOfWork(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void BeginTransaction()
        {
            _dbConnection.Transaction = _dbConnection.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _dbConnection.Transaction?.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _dbConnection.Transaction?.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            _dbConnection.Transaction?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
