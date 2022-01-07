namespace Shift.Server.Repositories.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        Task CreateAsync(T item);
        Task DeleteAsync(T item);
        Task PartialUpdateAsync(Func<T, bool> query, Action<T> updateAction);
        Task<List<T>?> ReadAllAsync(int page, int pageSize);
        Task<T?> ReadOrderByAsync<U>(Func<T, U> query);
        Task<List<T>?> ReadOrderByAsync<U>(Func<T, U> query, int page, int pageSize);
        Task<T?> ReadOrderByDescendingAsync<U>(Func<T, U> query);
        Task<List<T>?> ReadOrderByDescendingAsync<U>(Func<T, U> query, int page, int pageSize);
        Task<T?> ReadWhereAsync(Func<T, bool> query);
        Task<List<T>?> ReadWhereAsync(Func<T, bool> query, int page, int pageSize);
        Task UpdateAsync(T item);
    }
}