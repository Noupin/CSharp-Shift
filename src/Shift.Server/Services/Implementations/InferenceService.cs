using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Services
{
    public class InferenceService : IInferenceService
    {
        public Task<InferenceResponse> InferenceAsync(InferenceRequest body)
        {
            throw new NotImplementedException();
        }

        public Task<object> InferenceCDNAsync(string filename)
        {
            throw new NotImplementedException();
        }

        public Task<InferenceStatusResponse> InferenceStatusAsync(InferenceRequest body)
        {
            throw new NotImplementedException();
        }
    }
}