using Dapper;
using DapperTest.Core.Aggregates.ProdutoAggregate;
using DapperTest.SharedKernel.Interfaces;

namespace DapperTest.Infraestructure.Data
{
    public class ProductRepository : RepositoryBase<Product>, IProdutoRepository<Product>
    {
        public ProductRepository(
            string nomeTabela,
            IDatabaseConnection connection,
            IUnitOfWork unitOfWork)
                : base(nomeTabela, connection, unitOfWork)
        {
        }
    }
}
