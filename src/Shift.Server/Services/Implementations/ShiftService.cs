using Shift.Server.Models.Request;
using Shift.Server.Models.Response;
using Shift.Server.Repositories.Implementations;
using Shift.Server.Services.Abstractions;

namespace Shift.Server.Services.Implementations
{
    public class ShiftService : IShiftService
    {
        private readonly ShiftRepository _shiftRepository;

        public ShiftService(ShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        public async Task<IndividualShiftDeleteResponse> DeleteIndivdualShiftAsync(string uuid)
        {
            var shift = await _shiftRepository.ReadWhereAsync(Guid.Parse(uuid));
            await _shiftRepository.DeleteAsync(shift);

            return new IndividualShiftDeleteResponse
            {
                Msg = "Shift Deleted."
            };
        }

        public async Task<IndividualShiftGetResponse> GetIndivdualShiftAsync(string uuid)
        {
            var shift = await _shiftRepository.ReadWhereAsync(Guid.Parse(uuid));

            return new IndividualShiftGetResponse
            {
                Owner = false,
                Shift = shift
            };
        }

        public async Task<IndividualShiftPatchResponse> PatchIndivdualShiftAsync(string uuid, IndividualShiftPatchRequest body)
        {
            await _shiftRepository.PartialUpdateAsync(Guid.Parse(uuid), (Models.Abstractions.ShiftPartialUpdate)body);

            return new IndividualShiftPatchResponse
            {
                Msg = "Shift Updated."
            };
        }
    }
}