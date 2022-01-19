using BaseRepository;
using Shift.Server.Context;
using Shift.Server.Models.Abstractions;
using Shift.Server.Models.SQL;

namespace Shift.Server.Repositories.Implementations
{
    public class ShiftRepository : BaseRepository<ShiftSQL, ShiftContext>
    {
        private readonly FeryvUserRepository _feryvUserRepository;

        public ShiftRepository(ShiftContext context, FeryvUserRepository feryvUserRepository) : base(context, context.Shifts)
        {
            _feryvUserRepository = feryvUserRepository;
        }

        public Task<ShiftSQL?> ReadWhereAsync(Guid id)
        {
            return ReadWhereAsync((shift) => shift.Id.Equals(id));
        }

        public async Task<List<ShiftSQL>?> ReadWhereAsync(string username, int page, int pageSize)
        {
            var feryvUser = await _feryvUserRepository.ReadWhereAsync(username);
            return await ReadWhereAsync((shift) => shift.Author.Id.Equals(feryvUser.Id),
                page, pageSize);
        }

        public Task<List<ShiftSQL>?> ReadNewAsync(int page = 0)
        {
            return ReadOrderByAsync((shift) => shift.DateCreated, page, Constants.NumberOfNewShifts);
        }

        public Task<List<ShiftSQL>?> ReadPopularAsync(int page = 0)
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
