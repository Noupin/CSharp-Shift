using Microsoft.EntityFrameworkCore;
using Shift.Server.Context;

namespace Shift.Server.Repositories.Abstractions
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ShiftContext _context;
        protected readonly DbSet<T> _table;

        public BaseRepository(ShiftContext context, DbSet<T> table)
        {
            _context = context;
            _table = table;
        }

        public async Task CreateAsync(T item)
        {
            _table.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> ReadAsync(Func<T, bool> query)
        {
            return await _table
                .Where(query)
                .AsQueryable()
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T item)
        {
            _table.Update(item);
            await _context.SaveChangesAsync();
        }

        //For Shift Would Take In Individual Shift Patch Request
        public async Task PartialUpdateAsync(Func<T, bool> query, Action<T> updateAction)
        {
            var item = await ReadAsync(query);
            if (item == null) return;

            updateAction(item);
            _table.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            _table.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
