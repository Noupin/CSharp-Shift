using Shift.Server.Context;
using Shift.Server.Models.Abstractions;
using Shift.Server.Models.SQL;
using Shift.Server.Repositories.Abstractions;

namespace Shift.Server.Repositories.Implementations
{
    public class ShiftRepository : BaseRepository<ShiftSQL>
    {
        public ShiftRepository(ShiftContext context) : base(context, context.Shifts)
        {
        }

        public Task<ShiftSQL?> ReadAsync(Guid id)
        {
            return ReadAsync((shift) => shift.Id.Equals(id));
        }

        public Task PartialUpdateAsync(Guid id, ShiftPartialUpdate fields)
        {
            return PartialUpdateAsync((shift) => shift.Id.Equals(id),
                (shift) =>
                {
                    shift.Title = fields.Title ?? shift.Title;
                    shift.Private = fields.Private ?? shift.Private;
                    shift.Verified = fields.Verified ?? shift.Verified;
                });
        }
    }
}
