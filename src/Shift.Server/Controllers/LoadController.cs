using Microsoft.AspNetCore.Mvc;
using Shift.Server.Models.Request;
using Shift.Server.Models.Response;
using Shift.Server.Services.Abstractions;

namespace Shift.Server.Controllers
{

    [Route("api")]

    public class LoadController : ControllerBase
    {
        private ILoadService _loadService;

        public LoadController(ILoadService loadService)
        {
            _loadService = loadService;
        }

        /// <returns>Given training data Shift specializes a model for the training data. Yeilds more relaisitic results than just an inference though it takes longer.</returns>
        [HttpPost, Route("loadData", Name = "loadData")]
        public Task<LoadDataResponse> LoadData([FromHeader] LoadDataHeaderRequest head, LoadDataBodyRequest body)
        {

            return _loadService.LoadDataAsync(head, body);
        }
    }
}