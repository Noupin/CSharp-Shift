using Shift.Server.Context;
using Shift.Server.Models.SQL;
using Shift.Server.Repositories.Abstractions;

namespace Shift.Server.Repositories.Implementations
{
    public class FeryvUserRepository : BaseRepository<FeryvUserSQL, FeryvContext>
    {
        public FeryvUserRepository(FeryvContext context) : base(context, context.Users)
        {
        }

        public Task<FeryvUserSQL?> ReadWhereAsync(Guid id)
        {
            return ReadWhereAsync((user) => user.Id.Equals(id));
        }

        public Task<FeryvUserSQL?> ReadWhereAsync(string name)
        {
            return ReadWhereAsync((user) => user.Username.Equals(name));
        }
    }
}