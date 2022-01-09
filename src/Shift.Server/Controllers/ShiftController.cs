using Microsoft.AspNetCore.Mvc;
using Shift.Server.Models.Request;
using Shift.Server.Models.Response;
using Shift.Server.Services.Abstractions;

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
        public Task<IndividualShiftDeleteResponse> DeleteIndivdualShift(Guid uuid)
        {

            return _shiftService.DeleteIndivdualShiftAsync(uuid);
        }

        /// <returns>The requested shift.</returns>
        [HttpGet, Route("shift/{uuid}", Name = "getIndivdualShift")]
        public Task<IndividualShiftGetResponse> GetIndivdualShift(Guid uuid)
        {

            return _shiftService.GetIndivdualShiftAsync(uuid);
        }

        /// <param name="body">The field name and updated value to update the queried shift.</param>
        /// <returns>The status message pertaing to the update/modify.</returns>
        [HttpPatch, Route("shift/{uuid}", Name = "patchIndivdualShift")]
        //uuid used to be string C# may automatically parse to Guid
        public Task<IndividualShiftPatchResponse> PatchIndivdualShift(Guid uuid, [FromBody] IndividualShiftPatchRequest body)
        {

            return _shiftService.PatchIndivdualShiftAsync(uuid, body);
        }
    }
}