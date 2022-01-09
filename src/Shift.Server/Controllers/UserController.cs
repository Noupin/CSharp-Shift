using Microsoft.AspNetCore.Mvc;
using Shift.Server.Models.Request;
using Shift.Server.Models.Response;
using Shift.Server.Services.Abstractions;

namespace Shift.Server.Controllers
{

    [Route("api")]

    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <returns>The shifts for the user who is logged in.</returns>
        [HttpGet, Route("user/{username}/shifts", Name = "userShifts")]
        public Task<UserShiftsResponse> UserShifts([FromQuery] int page, string username)
        {

            return _userService.UserShiftsAsync(page, username);
        }

        /// <returns>The status message pertaing to the delete.</returns>
        [HttpDelete, Route("user/{username}", Name = "deleteIndivdualUser")]
        public Task<IndividualUserDeleteResponse> DeleteIndivdualUser(string username)
        {

            return _userService.DeleteIndivdualUserAsync(username);
        }

        /// <returns>The requested user.</returns>
        [HttpGet, Route("user/{username}", Name = "getIndivdualUser")]
        public Task<IndividualUserGetResponse> GetIndivdualUser(string username)
        {

            return _userService.GetIndivdualUserAsync(username);
        }

        /// <param name="body">The field name and updated value to update the queried user.</param>
        /// <returns>The status message pertaing to the patch.</returns>
        [HttpPatch, Route("user/{username}", Name = "patchIndivdualUser")]
        public Task<IndividualUserPatchResponse> PatchIndivdualUser(string username, [FromBody] IndividualUserPatchRequest body)
        {

            return _userService.PatchIndivdualUserAsync(username, body);
        }
    }
}