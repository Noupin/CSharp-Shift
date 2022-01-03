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

        public Task<CategorySQL?> ReadWhereAsync(string name)
        {
            return ReadWhereAsync((category) => category.Name.Equals(name));
        }

        public Task<IEnumerable<CategorySQL>?> ReadOrderByAsync(int page, int pageSize)
        {
            return ReadOrderByAsync((category) => category.Name, page, pageSize);
        }

        public Task UpdateNameAsync(string name, string newName)
        {
            return PartialUpdateAsync((category) => category.Name.Equals(name),
                (category) => category.Name = newName);
        }
    }
}
