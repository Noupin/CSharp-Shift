using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Services.Abstractions
{
    public interface IInferenceService
    {
        /// <param name="body">The uuid of the shift model being inferenced with, whether or not to use the pre trained model(PTM), and if using a prebuilt shift model the uuid of that shift.</param>

        /// <returns>Whether the shifting/inferencing went according to plan.</returns>

        Task<InferenceResponse> InferenceAsync(InferenceRequest body);


        Task<object> InferenceCDNAsync(string filename);


        /// <param name="body">The uuid of the shift model being inferenced with, whether or not to use the pre trained model(PTM), and if using a prebuilt shift model the uuid of that shift.</param>

        /// <returns>A msg describing the current state of inferencing on the original media, whether or not the inferencing has been stopped or finished, and the image path to pass to the cdn for the shifted media, and the base and the mask previews.</returns>

        Task<InferenceStatusResponse> InferenceStatusAsync(InferenceRequest body);
    }
}