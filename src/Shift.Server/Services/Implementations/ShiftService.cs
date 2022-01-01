using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Services
{
    public class ShiftService : IShiftService
    {
        public Task<IndividualShiftDeleteResponse> DeleteIndivdualShiftAsync(string uuid)
        {
            throw new NotImplementedException();
        }

        public Task<IndividualShiftGetResponse> GetIndivdualShiftAsync(string uuid)
        {
            throw new NotImplementedException();
        }

        public Task<IndividualShiftPatchResponse> PatchIndivdualShiftAsync(string uuid, IndividualShiftPatchRequest body)
        {
            throw new NotImplementedException();
        }
    }
}