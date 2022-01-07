using Shift.Server.Models.Request;
using Shift.Server.Models.Response;
using Shift.Server.Repositories.Implementations;
using Shift.Server.Services.Abstractions;

namespace Shift.Server.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly ShiftRepository _shiftRepository;

        public UserService(UserRepository userRepository, ShiftRepository shiftRepository)
        {
            _userRepository = userRepository;
            _shiftRepository = shiftRepository;
        }

        public async Task<IndividualUserDeleteResponse> DeleteIndivdualUserAsync(string username)
        {
            var user = await _userRepository.ReadWhereAsync(username);
            await _userRepository.DeleteAsync(user);

            return new IndividualUserDeleteResponse
            {
                Msg = "Shift User Deleted."
            };
        }

        public async Task<IndividualUserGetResponse> GetIndivdualUserAsync(string username)
        {
            var user = await _userRepository.ReadWhereAsync(username);

            return new IndividualUserGetResponse
            {
                Owner = false,
                User = user
            };
        }

        public async Task<IndividualUserPatchResponse> PatchIndivdualUserAsync(string username, IndividualUserPatchRequest body)
        {
            await _userRepository.PartialUpdateAsync(username, (Models.Abstractions.UserPartialUpdate)body);

            return new IndividualUserPatchResponse
            {
                Msg = "Shift User Updated."
            };
        }

        public async Task<UserShiftsResponse> UserShiftsAsync(int page, string username)
        {
            var user = await _userRepository.ReadWhereAsync(username);
            var shifts = await _shiftRepository.ReadWhereAsync((shift) => shift.UserId.Equals(user.Id), page, Constants.ItemsPerPage);
            return new UserShiftsResponse
            {
                Shifts = shifts
            };
        }
    }
}