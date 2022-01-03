using Shift.Server.Context;
using Shift.Server.Models.Abstractions;
using Shift.Server.Models.SQL;
using Shift.Server.Repositories.Abstractions;

namespace Shift.Server.Repositories.Implementations
{
    public class UserRepository : BaseRepository<UserSQL>
    {
        public UserRepository(ShiftContext context) : base(context, context.Users)
        {
        }

        public Task<UserSQL?> ReadWhereAsync(Guid id)
        {
            return ReadWhereAsync((user) => user.Id.Equals(id));
        }

        public Task PartialUpdateAsync(Guid id, UserPartialUpdate fields)
        {
            return PartialUpdateAsync((user) => user.Id.Equals(id),
                (user) =>
                {
                    user.Admin = fields.Admin ?? user.Admin;
                    user.CanTrain = fields.CanTrain ?? user.CanTrain;
                    user.Verified = fields.Verified ?? user.Verified;
                });
        }
    }
}
