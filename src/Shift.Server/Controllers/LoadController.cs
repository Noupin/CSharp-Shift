using Microsoft.AspNetCore.Mvc;
using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Controllers
{

    [Route("api")]

    public class LoadController : ControllerBase
    {
        private ILoadService _implementation;

        public LoadController(ILoadService implementation)
        {
            _implementation = implementation;
        }

        /// <returns>Given training data Shift specializes a model for the training data. Yeilds more relaisitic results than just an inference though it takes longer.</returns>
        [HttpPost, Route("loadData", Name = "loadData")]
        public Task<LoadDataResponse> LoadData([FromHeader] LoadDataHeaderRequest head, LoadDataBodyRequest body)
        {

            return _implementation.LoadDataAsync(head, body);
        }
    }
}