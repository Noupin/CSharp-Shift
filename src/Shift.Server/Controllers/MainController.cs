using Microsoft.AspNetCore.Mvc;
using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Controllers
{

    [Route("api")]

    public class Controller : ControllerBase
    {
        private IController _implementation;

        public Controller(IController implementation)
        {
            _implementation = implementation;
        }

        /// <returns>Given training data Shift specializes a model for the training data. Yeilds more relaisitic results than just an inference though it takes longer.</returns>
        [HttpPost, Route("loadData", Name = "loadData")]
        public Task<LoadDataResponse> LoadData([FromHeader] LoadDataHeaderRequest head, LoadDataBodyRequest body)
        {

            return _implementation.LoadDataAsync(head, body);
        }

        /// <param name="body">The uuid of the shift model being inferenced with, the title of the shift that is being trained, whether or not the the PTM is being used, the uuid of the prebuilt shift model if one is being used, the amount of epochs inbetween the training status updates, and the type of trainign to send four pictures or one picture for front end.</param>
        /// <returns>Whether the training has started or not.</returns>
        [HttpPost, Route("train", Name = "train")]
        public Task<TrainResponse> Train([FromBody] TrainRequest body)
        {

            return _implementation.TrainAsync(body);
        }

        /// <param name="body">The uuid of the shift model being inferenced with, the title of the shift that is being trained, whether or not the the PTM is being used, the uuid of the prebuilt shift model if one is being used, the amount of epochs inbetween the training status updates, and the type of trainign to send four pictures or one picture for front end.</param>
        /// <returns>Whether the stop train signal was accepted.</returns>
        [HttpPost, Route("stopTraining", Name = "stopTrain")]
        public Task<StopTrainResponse> StopTrain([FromBody] TrainRequest body)
        {

            return _implementation.StopTrainAsync(body);
        }

        /// <param name="body">The uuid of the shift model being inferenced with, the title of the shift that is being trained, whether or not the the PTM is being used, the uuid of the prebuilt shift model if one is being used, the amount of epochs inbetween the training status updates, and the type of trainign to send four pictures or one picture for front end.</param>
        /// <returns>The status of the current shift training, whether the training has stopped, and encoded images to view on the front end.</returns>
        [HttpPost, Route("trainStatus", Name = "trainStatus")]
        public Task<TrainStatusResponse> TrainStatus([FromBody] TrainRequest body)
        {

            return _implementation.TrainStatusAsync(body);
        }

        /// <returns>The shifts for the user who is logged in.</returns>
        [HttpGet, Route("user/{username}/shifts", Name = "userShifts")]
        public Task<UserShiftsResponse> UserShifts([FromQuery] int page, string username)
        {

            return _implementation.UserShiftsAsync(page, username);
        }

        /// <returns>The status message pertaing to the delete.</returns>
        [HttpDelete, Route("user/{username}", Name = "deleteIndivdualUser")]
        public Task<IndividualUserDeleteResponse> DeleteIndivdualUser(string username)
        {

            return _implementation.DeleteIndivdualUserAsync(username);
        }

        /// <returns>The requested user.</returns>
        [HttpGet, Route("user/{username}", Name = "getIndivdualUser")]
        public Task<IndividualUserGetResponse> GetIndivdualUser(string username)
        {

            return _implementation.GetIndivdualUserAsync(username);
        }

        /// <param name="body">The field name and updated value to update the queried user.</param>
        /// <returns>The status message pertaing to the patch.</returns>
        [HttpPatch, Route("user/{username}", Name = "patchIndivdualUser")]
        public Task<IndividualUserPatchResponse> PatchIndivdualUser(string username, [FromBody] IndividualUserPatchRequest body)
        {

            return _implementation.PatchIndivdualUserAsync(username, body);
        }

        /// <param name="body">The uuid of the shift model being inferenced with, whether or not to use the pre trained model(PTM), and if using a prebuilt shift model the uuid of that shift.</param>
        /// <returns>Whether the shifting/inferencing went according to plan.</returns>
        [HttpPost, Route("inference", Name = "inference")]
        public Task<InferenceResponse> Inference([FromBody] InferenceRequest body)
        {

            return _implementation.InferenceAsync(body);
        }

        [HttpGet, Route("inference/content/{filename}", Name = "inferenceCDN")]
        public Task<object> InferenceCDN(string filename)
        {

            return _implementation.InferenceCDNAsync(filename);
        }

        /// <param name="body">The uuid of the shift model being inferenced with, whether or not to use the pre trained model(PTM), and if using a prebuilt shift model the uuid of that shift.</param>
        /// <returns>A msg describing the current state of inferencing on the original media, whether or not the inferencing has been stopped or finished, and the image path to pass to the cdn for the shifted media, and the base and the mask previews.</returns>
        [HttpPost, Route("inferenceStatus", Name = "inferenceStatus")]
        public Task<InferenceStatusResponse> InferenceStatus([FromBody] InferenceRequest body)
        {

            return _implementation.InferenceStatusAsync(body);
        }

        /// <returns>The newest shifts.</returns>
        [HttpGet, Route("shift/category/new", Name = "new")]
        public Task<NewShiftsResponse> New()
        {

            return _implementation.NewAsync();
        }

        /// <returns>The category names for the requested amount of categories.</returns>
        [HttpGet, Route("shift/category/categories", Name = "Categories")]
        public Task<CategoriesResponse> Categories([FromQuery] int page)
        {

            return _implementation.CategoriesAsync(page);
        }

        /// <returns>The top 10 most popular shifts.</returns>
        [HttpGet, Route("shift/category/popular", Name = "popular")]
        public Task<PopularShiftsResponse> Popular()
        {

            return _implementation.PopularAsync();
        }

        /// <returns>The shifts for the queried category.</returns>
        [HttpGet, Route("shift/category/{categoryName}", Name = "Category")]
        public Task<ShiftCategoryResponse> Category([FromQuery] int page, string categoryName)
        {

            return _implementation.CategoryAsync(page, categoryName);
        }

        /// <returns>The status message pertaing to the delete.</returns>
        [HttpDelete, Route("shift/{uuid}", Name = "deleteIndivdualShift")]
        public Task<IndividualShiftDeleteResponse> DeleteIndivdualShift(string uuid)
        {

            return _implementation.DeleteIndivdualShiftAsync(uuid);
        }

        /// <returns>The requested shift.</returns>
        [HttpGet, Route("shift/{uuid}", Name = "getIndivdualShift")]
        public Task<IndividualShiftGetResponse> GetIndivdualShift(string uuid)
        {

            return _implementation.GetIndivdualShiftAsync(uuid);
        }

        /// <param name="body">The field name and updated value to update the queried shift.</param>
        /// <returns>The status message pertaing to the update/modify.</returns>
        [HttpPatch, Route("shift/{uuid}", Name = "patchIndivdualShift")]
        public Task<IndividualShiftPatchResponse> PatchIndivdualShift(string uuid, [FromBody] IndividualShiftPatchRequest body)
        {

            return _implementation.PatchIndivdualShiftAsync(uuid, body);
        }

    }


}