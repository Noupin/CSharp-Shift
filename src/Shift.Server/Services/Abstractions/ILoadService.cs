using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Services.Abstractions
{
    public interface ILoadService
    {
        /// <returns>Given training data Shift specializes a model for the training data. Yeilds more relaisitic results than just an inference though it takes longer.</returns>

        Task<LoadDataResponse> LoadDataAsync(LoadDataHeaderRequest head, LoadDataBodyRequest body);
    }
}