using Shift.Server.Models.Request;
using Shift.Server.Models.Response;
using Shift.Server.Services.Abstractions;

namespace Shift.Server.Services.Implementations
{
    public class LoadService : ILoadService
    {
        public Task<LoadDataResponse> LoadDataAsync(LoadDataHeaderRequest head, LoadDataBodyRequest body)
        {
            throw new NotImplementedException();
        }
    }
}