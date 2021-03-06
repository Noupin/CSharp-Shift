using BaseRepository;
using Shift.Server.Context;
using Shift.Server.Models.SQL;

namespace Shift.Server.Repositories.Implementations
{
    public class ShiftCategoryRepository : BaseRepository<ShiftCategorySQL, ShiftContext>
    {
        public ShiftCategoryRepository(ShiftContext context) : base(context, context.ShiftCategories)
        {
        }

        public Task<ShiftCategorySQL?> ReadWhereAsync(string name)
        {
            return ReadWhereAsync((shiftCategory) => shiftCategory.CategoryName.Equals(name));
        }

        public Task<List<ShiftCategorySQL>?> ReadWhereAsync(string name, int page, int pageSize)
        {
            return ReadWhereAsync((shiftCategory) => shiftCategory.CategoryName.Equals(name), page, pageSize);
        }

        public Task<List<ShiftCategorySQL>?> ReadWhereAsync(Guid id, int page, int pageSize)
        {
            return ReadWhereAsync((shiftCategory) => shiftCategory.ShiftId.Equals(id), page, pageSize);
        }

        //Doesn't Need Partial Update Implemented
    }
}
