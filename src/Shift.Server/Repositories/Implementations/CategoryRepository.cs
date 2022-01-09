using BaseRepository;
using Shift.Server.Context;
using Shift.Server.Models.SQL;

namespace Shift.Server.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<CategorySQL, ShiftContext>
    {
        public CategoryRepository(ShiftContext context) : base(context, context.Categories)
        {
        }

        public Task<CategorySQL?> ReadWhereAsync(string name)
        {
            return ReadWhereAsync((category) => category.Name.Equals(name));
        }

        public Task<List<CategorySQL>?> ReadOrderByAsync(int page, int pageSize)
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
