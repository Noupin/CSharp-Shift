﻿using Shift.Server.Context;
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

        public Task<ShiftSQL?> ReadWhereAsync(Guid id)
        {
            return ReadWhereAsync((shift) => shift.Id.Equals(id));
        }

        public Task<ShiftSQL?> ReadWhereAsync(Func<ShiftSQL, bool> query, int page, int pageSize)
        {
            return ReadWhereAsync(query, page, pageSize);
        }

        public Task<IEnumerable<ShiftSQL>?> ReadNewAsync(int page)
        {
            return ReadOrderByAsync((shift) => shift.DateCreated, page, Constants.NumberOfNewShifts);
        }

        public Task<IEnumerable<ShiftSQL>?> ReadPopularAsync(int page)
        {
            return ReadOrderByDescendingAsync((shift) => shift.Views, page, Constants.NumberOfPopularShifts);
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
