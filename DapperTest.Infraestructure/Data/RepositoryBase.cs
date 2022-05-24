using Dapper;
using DapperTest.SharedKernel.Interfaces;
using System.Reflection;

namespace DapperTest.Infraestructure.Data
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly string _nomeTabela;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IDatabaseConnection _connection;

        public RepositoryBase(
            string nomeTabela,
            IDatabaseConnection connection,
            IUnitOfWork unitOfWork)
        {
            _nomeTabela = nomeTabela;
            _connection = connection;
            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(T t, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                await _connection.Connection.ExecuteAsync(
                    $"DELETE FROM {_nomeTabela} WHERE Id = @Id",
                    new { Id = id }, _connection.Transaction);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _connection.Connection.QueryAsync<T>(
                $"SELECT * FROM {_nomeTabela}");
        }

        public async Task<T> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _connection.Connection.QueryFirstOrDefaultAsync<T>(
                $"SELECT * FROM {_nomeTabela} WHERE Id = @Id",
                new { Id = id });
        }

        public async Task<int> SaveRangeAsync(IEnumerable<T> list, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T t, CancellationToken cancellationToken = default)
        {
            try
            {

            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();
    }
}
