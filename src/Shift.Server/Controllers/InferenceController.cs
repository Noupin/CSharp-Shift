using Microsoft.AspNetCore.Mvc;
using Shift.Server.Models.Request;
using Shift.Server.Models.Response;
using Shift.Server.Services.Interfaces;

namespace Shift.Server.Controllers
{

    [Route("api")]

    public class InferenceController : ControllerBase
    {
        private IInferenceService _inferenceService;

        public InferenceController(IInferenceService inferenceService)
        {
            _inferenceService = inferenceService;
        }

        /// <param name="body">The uuid of the shift model being inferenced with, whether or not to use the pre trained model(PTM), and if using a prebuilt shift model the uuid of that shift.</param>
        /// <returns>Whether the shifting/inferencing went according to plan.</returns>
        [HttpPost, Route("inference", Name = "inference")]
        public Task<InferenceResponse> Inference([FromBody] InferenceRequest body)
        {

            return _inferenceService.InferenceAsync(body);
        }

        [HttpGet, Route("inference/content/{filename}", Name = "inferenceCDN")]
        public Task<object> InferenceCDN(string filename)
        {

            return _inferenceService.InferenceCDNAsync(filename);
        }

        /// <param name="body">The uuid of the shift model being inferenced with, whether or not to use the pre trained model(PTM), and if using a prebuilt shift model the uuid of that shift.</param>
        /// <returns>A msg describing the current state of inferencing on the original media, whether or not the inferencing has been stopped or finished, and the image path to pass to the cdn for the shifted media, and the base and the mask previews.</returns>
        [HttpPost, Route("inferenceStatus", Name = "inferenceStatus")]
        public Task<InferenceStatusResponse> InferenceStatus([FromBody] InferenceRequest body)
        {

            return _inferenceService.InferenceStatusAsync(body);
        }
    }
}