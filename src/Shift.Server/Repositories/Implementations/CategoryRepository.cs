using Shift.Server.Context;
using Shift.Server.Models.SQL;
using Shift.Server.Repositories.Abstractions;

namespace Shift.Server.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<CategorySQL>
    {
        public CategoryRepository(ShiftContext context) : base(context, context.Categories)
        {
        }

        public Task<CategorySQL?> ReadAsync(string name)
        {
            return ReadAsync((category) => category.Name == name);
        }

        public Task UpdateNameAsync(string name, string newName)
        {
            return PartialUpdateAsync((category) => category.Name == name,
                (category) => category.Name = newName);
        }
    }
}
