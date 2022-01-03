using Shift.Server.Models.Request;
using Shift.Server.Models.Response;
using Shift.Server.Services.Abstractions;

namespace Shift.Server.Services.Implementations
{
    public class UserService : IUserService
    {
        public Task<IndividualUserDeleteResponse> DeleteIndivdualUserAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IndividualUserGetResponse> GetIndivdualUserAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IndividualUserPatchResponse> PatchIndivdualUserAsync(string username, IndividualUserPatchRequest body)
        {
            throw new NotImplementedException();
        }

        public Task<UserShiftsResponse> UserShiftsAsync(int page, string username)
        {
            throw new NotImplementedException();
        }
    }
}