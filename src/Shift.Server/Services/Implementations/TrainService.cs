using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Services
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