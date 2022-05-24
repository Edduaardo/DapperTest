namespace DapperTest.SharedKernel.Interfaces
{
    public interface IProdutoRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}
