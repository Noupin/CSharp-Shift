using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Services
{
    public class LoadService : ILoadService
    {
        public Task<LoadDataResponse> LoadDataAsync(LoadDataHeaderRequest head, LoadDataBodyRequest body)
        {
            throw new NotImplementedException();
        }
    }
}