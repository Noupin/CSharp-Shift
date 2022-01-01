using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Services
{
    public interface ITrainService
    {
        /// <param name="body">The uuid of the shift model being inferenced with, the title of the shift that is being trained, whether or not the the PTM is being used, the uuid of the prebuilt shift model if one is being used, the amount of epochs inbetween the training status updates, and the type of trainign to send four pictures or one picture for front end.</param>

        /// <returns>Whether the training has started or not.</returns>

        Task<TrainResponse> TrainAsync(TrainRequest body);


        /// <param name="body">The uuid of the shift model being inferenced with, the title of the shift that is being trained, whether or not the the PTM is being used, the uuid of the prebuilt shift model if one is being used, the amount of epochs inbetween the training status updates, and the type of trainign to send four pictures or one picture for front end.</param>

        /// <returns>Whether the stop train signal was accepted.</returns>

        Task<StopTrainResponse> StopTrainAsync(TrainRequest body);


        /// <param name="body">The uuid of the shift model being inferenced with, the title of the shift that is being trained, whether or not the the PTM is being used, the uuid of the prebuilt shift model if one is being used, the amount of epochs inbetween the training status updates, and the type of trainign to send four pictures or one picture for front end.</param>

        /// <returns>The status of the current shift training, whether the training has stopped, and encoded images to view on the front end.</returns>

        Task<TrainStatusResponse> TrainStatusAsync(TrainRequest body);
    }
}