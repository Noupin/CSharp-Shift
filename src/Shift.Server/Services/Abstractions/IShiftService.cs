using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Services.Abstractions
{
    public interface IShiftService
    {
        /// <returns>The status message pertaing to the delete.</returns>

        Task<IndividualShiftDeleteResponse> DeleteIndivdualShiftAsync(Guid id);


        /// <returns>The requested shift.</returns>

        Task<IndividualShiftGetResponse> GetIndivdualShiftAsync(Guid id);


        /// <param name="body">The field name and updated value to update the queried shift.</param>

        /// <returns>The status message pertaing to the update/modify.</returns>

        Task<IndividualShiftPatchResponse> PatchIndivdualShiftAsync(Guid id, IndividualShiftPatchRequest body);
    }
}