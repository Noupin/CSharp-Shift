using Shift.Server.Context;
using Shift.Server.Models.Abstractions;
using Shift.Server.Models.SQL;
using Shift.Server.Repositories.Abstractions;

namespace Shift.Server.Repositories.Implementations
{
    public class UserRepository : BaseRepository<UserSQL, ShiftContext>
    {
        private readonly FeryvUserRepository _feryvUserRepository;

        public UserRepository(ShiftContext context, FeryvUserRepository feryvUserRepository) : base(context, context.Users)
        {
            _feryvUserRepository = feryvUserRepository;
        }

        public async Task<UserSQL?> ReadWhereAsync(Guid id)
        {
            var feryvUser = await _feryvUserRepository.ReadWhereAsync(id);
            var user = await ReadWhereAsync((user) => user.Id.Equals(id));
            user.FeryvUser = feryvUser;

            return user;
        }

        public async Task<UserSQL?> ReadWhereAsync(string username)
        {
            var feryvUser = await _feryvUserRepository.ReadWhereAsync(username);
            var user = await ReadWhereAsync((user) => user.Id.Equals(username));
            user.FeryvUser = feryvUser;

            return user;
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
