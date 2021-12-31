using Microsoft.AspNetCore.Mvc;
using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Controllers
{

    [Route("api")]

    public class UserController : ControllerBase
    {
        private IUserService _implementation;

        public UserController(IUserService implementation)
        {
            _implementation = implementation;
        }

        /// <returns>The shifts for the user who is logged in.</returns>
        [HttpGet, Route("user/{username}/shifts", Name = "userShifts")]
        public Task<UserShiftsResponse> UserShifts([FromQuery] int page, string username)
        {

            return _implementation.UserShiftsAsync(page, username);
        }

        /// <returns>The status message pertaing to the delete.</returns>
        [HttpDelete, Route("user/{username}", Name = "deleteIndivdualUser")]
        public Task<IndividualUserDeleteResponse> DeleteIndivdualUser(string username)
        {

            return _implementation.DeleteIndivdualUserAsync(username);
        }

        /// <returns>The requested user.</returns>
        [HttpGet, Route("user/{username}", Name = "getIndivdualUser")]
        public Task<IndividualUserGetResponse> GetIndivdualUser(string username)
        {

            return _implementation.GetIndivdualUserAsync(username);
        }

        /// <param name="body">The field name and updated value to update the queried user.</param>
        /// <returns>The status message pertaing to the patch.</returns>
        [HttpPatch, Route("user/{username}", Name = "patchIndivdualUser")]
        public Task<IndividualUserPatchResponse> PatchIndivdualUser(string username, [FromBody] IndividualUserPatchRequest body)
        {

            return _implementation.PatchIndivdualUserAsync(username, body);
        }
    }
}