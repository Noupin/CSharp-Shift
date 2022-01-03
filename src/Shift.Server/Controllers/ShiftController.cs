using Microsoft.AspNetCore.Mvc;
using Shift.Server.Models.Request;
using Shift.Server.Models.Response;
using Shift.Server.Services.Interfaces;

namespace Shift.Server.Controllers
{

    [Route("api")]

    public class ShiftController : ControllerBase
    {
        private IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        /// <returns>The status message pertaing to the delete.</returns>
        [HttpDelete, Route("shift/{uuid}", Name = "deleteIndivdualShift")]
        public Task<IndividualShiftDeleteResponse> DeleteIndivdualShift(string uuid)
        {

            return _shiftService.DeleteIndivdualShiftAsync(uuid);
        }

        /// <returns>The requested shift.</returns>
        [HttpGet, Route("shift/{uuid}", Name = "getIndivdualShift")]
        public Task<IndividualShiftGetResponse> GetIndivdualShift(string uuid)
        {

            return _shiftService.GetIndivdualShiftAsync(uuid);
        }

        /// <param name="body">The field name and updated value to update the queried shift.</param>
        /// <returns>The status message pertaing to the update/modify.</returns>
        [HttpPatch, Route("shift/{uuid}", Name = "patchIndivdualShift")]
        public Task<IndividualShiftPatchResponse> PatchIndivdualShift(string uuid, [FromBody] IndividualShiftPatchRequest body)
        {

            return _shiftService.PatchIndivdualShiftAsync(uuid, body);
        }
    }
}