namespace Shift.Server.Repositories.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        Task CreateAsync(T item);
        Task DeleteAsync(T item);
        Task PartialUpdateAsync(Func<T, bool> query, Action<T> updateAction);
        Task<T?> ReadAsync(Func<T, bool> query);
        Task UpdateAsync(T item);
    }
}