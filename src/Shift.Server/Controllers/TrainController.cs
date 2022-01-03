using Microsoft.AspNetCore.Mvc;
using Shift.Server.Models.Request;
using Shift.Server.Models.Response;
using Shift.Server.Services.Interfaces;

namespace Shift.Server.Controllers
{

    [Route("api")]

    public class TrainController : ControllerBase
    {
        private ITrainService _trainService;

        public TrainController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        /// <param name="body">The uuid of the shift model being inferenced with, the title of the shift that is being trained, whether or not the the PTM is being used, the uuid of the prebuilt shift model if one is being used, the amount of epochs inbetween the training status updates, and the type of trainign to send four pictures or one picture for front end.</param>
        /// <returns>Whether the training has started or not.</returns>
        [HttpPost, Route("train", Name = "train")]
        public Task<TrainResponse> Train([FromBody] TrainRequest body)
        {

            return _trainService.TrainAsync(body);
        }

        /// <param name="body">The uuid of the shift model being inferenced with, the title of the shift that is being trained, whether or not the the PTM is being used, the uuid of the prebuilt shift model if one is being used, the amount of epochs inbetween the training status updates, and the type of trainign to send four pictures or one picture for front end.</param>
        /// <returns>Whether the stop train signal was accepted.</returns>
        [HttpPost, Route("stopTraining", Name = "stopTrain")]
        public Task<StopTrainResponse> StopTrain([FromBody] TrainRequest body)
        {

            return _trainService.StopTrainAsync(body);
        }

        /// <param name="body">The uuid of the shift model being inferenced with, the title of the shift that is being trained, whether or not the the PTM is being used, the uuid of the prebuilt shift model if one is being used, the amount of epochs inbetween the training status updates, and the type of trainign to send four pictures or one picture for front end.</param>
        /// <returns>The status of the current shift training, whether the training has stopped, and encoded images to view on the front end.</returns>
        [HttpPost, Route("trainStatus", Name = "trainStatus")]
        public Task<TrainStatusResponse> TrainStatus([FromBody] TrainRequest body)
        {

            return _trainService.TrainStatusAsync(body);
        }
    }
}