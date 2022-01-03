using Shift.Server.Models.Request;
using Shift.Server.Models.Response;
using Shift.Server.Services.Abstractions;

namespace Shift.Server.Services.Implementations
{
    public class TrainService : ITrainService
    {
        public Task<StopTrainResponse> StopTrainAsync(TrainRequest body)
        {
            throw new NotImplementedException();
        }

        public Task<TrainResponse> TrainAsync(TrainRequest body)
        {
            throw new NotImplementedException();
        }

        public Task<TrainStatusResponse> TrainStatusAsync(TrainRequest body)
        {
            throw new NotImplementedException();
        }
    }
}