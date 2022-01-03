using Shift.Server.Context;
using Shift.Server.Models.SQL;
using Shift.Server.Repositories.Abstractions;

namespace Shift.Server.Repositories.Implementations
{
    public class ShiftCategoryRepository : BaseRepository<ShiftCategorySQL>
    {
        public ShiftCategoryRepository(ShiftContext context) : base(context, context.ShiftCategories)
        {
        }

        public Task<ShiftCategorySQL?> ReadAsync(Guid id)
        {
            return ReadAsync((shiftCategory) => shiftCategory.Id.Equals(id));
        }

        //Doesn't Need Partial Update Implemented
    }
}
