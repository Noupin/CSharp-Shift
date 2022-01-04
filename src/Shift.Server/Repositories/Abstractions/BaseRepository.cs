using Microsoft.EntityFrameworkCore;

namespace Shift.Server.Repositories.Abstractions
{
    public abstract class BaseRepository<T, U> : IBaseRepository<T> where T : class where U : DbContext
    {
        protected readonly U _context;
        protected readonly DbSet<T> _table;


        public BaseRepository(U context, DbSet<T> table)
        {
            _context = context;
            _table = table;
        }


        //Create
        public async Task CreateAsync(T item)
        {
            _table.Add(item);
            await _context.SaveChangesAsync();
        }


        //Read
        public async Task<T?> ReadWhereAsync(Func<T, bool> query)
        {
            return await _table
                .Where(query)
                .AsQueryable()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>?> ReadWhereAsync(Func<T, bool> query, int page, int pageSize)
        {
            return await _table
                .Where(query)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsQueryable()
                .ToListAsync();
        }
        public async Task<T?> ReadOrderByAsync<U>(Func<T, U> query)
        {
            return await _table
                .OrderBy(query)
                .AsQueryable()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>?> ReadOrderByAsync<U>(Func<T, U> query, int page, int pageSize)
        {
            return await _table
                .OrderBy(query)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<T?> ReadOrderByDescendingAsync<U>(Func<T, U> query)
        {
            return await _table
                .OrderByDescending(query)
                .AsQueryable()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>?> ReadOrderByDescendingAsync<U>(Func<T, U> query, int page, int pageSize)
        {
            return await _table
                .OrderByDescending(query)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsQueryable()
                .ToListAsync();
        }


        //Update
        public async Task UpdateAsync(T item)
        {
            _table.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task PartialUpdateAsync(Func<T, bool> query, Action<T> updateAction)
        {
            var item = await ReadWhereAsync(query);
            if (item == null) return;

            updateAction(item);
            _table.Update(item);
            await _context.SaveChangesAsync();
        }


        //Delete
        public async Task DeleteAsync(T item)
        {
            _table.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
