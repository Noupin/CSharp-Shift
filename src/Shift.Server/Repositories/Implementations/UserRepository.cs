using BaseRepository;
using Shift.Server.Context;
using Shift.Server.Models.Abstractions;
using Shift.Server.Models.SQL;

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
            var user = await ReadWhereAsync((user) => user.Id.Equals(id));
            var feryvUser = await _feryvUserRepository.ReadWhereAsync(user.Id);
            user.FeryvUser = feryvUser;

            return user;
        }

        public async Task<UserSQL?> ReadWhereAsync(string username)
        {
            var feryvUser = await _feryvUserRepository.ReadWhereAsync(username);
            var user = await ReadWhereAsync((user) => user.Id.Equals(feryvUser.Id));
            user.FeryvUser = feryvUser;

            return user;
        }

        public async Task<Task> PartialUpdateAsync(string username, UserPartialUpdate fields)
        {
            var feryvUser = await _feryvUserRepository.ReadWhereAsync(username);
            return PartialUpdateAsync((user) => user.Id.Equals(feryvUser.Id),
                (user) =>
                {
                    user.Admin = fields.Admin ?? user.Admin;
                    user.CanTrain = fields.CanTrain ?? user.CanTrain;
                    user.Verified = fields.Verified ?? user.Verified;
                });
        }
    }
}
