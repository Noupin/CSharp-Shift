using Shift.Server.Models.Abstractions;
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

        public async Task<IndividualShiftDeleteResponse> DeleteIndivdualShiftAsync(Guid id)
        {
            var shift = await _shiftRepository.ReadWhereAsync(id);
            await _shiftRepository.DeleteAsync(shift);

            return new IndividualShiftDeleteResponse
            {
                Msg = "Shift Deleted."
            };
        }

        public async Task<IndividualShiftGetResponse> GetIndivdualShiftAsync(Guid id)
        {
            var shift = await _shiftRepository.ReadWhereAsync(id);

            return new IndividualShiftGetResponse
            {
                Owner = false,
                Shift = shift
            };
        }

        //May parse Guid from string automatically
        public async Task<IndividualShiftPatchResponse> PatchIndivdualShiftAsync(Guid id, IndividualShiftPatchRequest body)
        {
            await _shiftRepository.PartialUpdateAsync(id, (ShiftPartialUpdate)body);

            return new IndividualShiftPatchResponse
            {
                Msg = "Shift Updated."
            };
        }
    }
}