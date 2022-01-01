using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Services
{
    public interface IUserService
    {
        /// <returns>The shifts for the user who is logged in.</returns>

        Task<UserShiftsResponse> UserShiftsAsync(int page, string username);


        /// <returns>The status message pertaing to the delete.</returns>

        Task<IndividualUserDeleteResponse> DeleteIndivdualUserAsync(string username);


        /// <returns>The requested user.</returns>

        Task<IndividualUserGetResponse> GetIndivdualUserAsync(string username);


        /// <param name="body">The field name and updated value to update the queried user.</param>

        /// <returns>The status message pertaing to the patch.</returns>

        Task<IndividualUserPatchResponse> PatchIndivdualUserAsync(string username, IndividualUserPatchRequest body);
    }
}