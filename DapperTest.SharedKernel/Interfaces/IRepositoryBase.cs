namespace DapperTest.SharedKernel.Interfaces;

public interface IRepositoryBase<T>
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<T> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<int> SaveRangeAsync(IEnumerable<T> list, CancellationToken cancellationToken = default);
    Task UpdateAsync(T t, CancellationToken cancellationToken = default);
    Task AddAsync(T t, CancellationToken cancellationToken = default);
}
