using Shift.Server.Models.Request;
using Shift.Server.Models.Response;

namespace Shift.Server.Controllers
{
    public interface IController
    {



        /// <returns>Given training data Shift specializes a model for the training data. Yeilds more relaisitic results than just an inference though it takes longer.</returns>

        Task<LoadDataResponse> LoadDataAsync(LoadDataHeaderRequest head, LoadDataBodyRequest body);


        /// <param name="body">The uuid of the shift model being inferenced with, the title of the shift that is being trained, whether or not the the PTM is being used, the uuid of the prebuilt shift model if one is being used, the amount of epochs inbetween the training status updates, and the type of trainign to send four pictures or one picture for front end.</param>

        /// <returns>Whether the training has started or not.</returns>

        Task<TrainResponse> TrainAsync(TrainRequest body);


        /// <param name="body">The uuid of the shift model being inferenced with, the title of the shift that is being trained, whether or not the the PTM is being used, the uuid of the prebuilt shift model if one is being used, the amount of epochs inbetween the training status updates, and the type of trainign to send four pictures or one picture for front end.</param>

        /// <returns>Whether the stop train signal was accepted.</returns>

        Task<StopTrainResponse> StopTrainAsync(TrainRequest body);


        /// <param name="body">The uuid of the shift model being inferenced with, the title of the shift that is being trained, whether or not the the PTM is being used, the uuid of the prebuilt shift model if one is being used, the amount of epochs inbetween the training status updates, and the type of trainign to send four pictures or one picture for front end.</param>

        /// <returns>The status of the current shift training, whether the training has stopped, and encoded images to view on the front end.</returns>

        Task<TrainStatusResponse> TrainStatusAsync(TrainRequest body);



        /// <returns>The shifts for the user who is logged in.</returns>

        Task<UserShiftsResponse> UserShiftsAsync(int page, string username);


        /// <returns>The status message pertaing to the delete.</returns>

        Task<IndividualUserDeleteResponse> DeleteIndivdualUserAsync(string username);


        /// <returns>The requested user.</returns>

        Task<IndividualUserGetResponse> GetIndivdualUserAsync(string username);


        /// <param name="body">The field name and updated value to update the queried user.</param>

        /// <returns>The status message pertaing to the patch.</returns>

        Task<IndividualUserPatchResponse> PatchIndivdualUserAsync(string username, IndividualUserPatchRequest body);


        /// <param name="body">The uuid of the shift model being inferenced with, whether or not to use the pre trained model(PTM), and if using a prebuilt shift model the uuid of that shift.</param>

        /// <returns>Whether the shifting/inferencing went according to plan.</returns>

        Task<InferenceResponse> InferenceAsync(InferenceRequest body);


        Task<object> InferenceCDNAsync(string filename);


        /// <param name="body">The uuid of the shift model being inferenced with, whether or not to use the pre trained model(PTM), and if using a prebuilt shift model the uuid of that shift.</param>

        /// <returns>A msg describing the current state of inferencing on the original media, whether or not the inferencing has been stopped or finished, and the image path to pass to the cdn for the shifted media, and the base and the mask previews.</returns>

        Task<InferenceStatusResponse> InferenceStatusAsync(InferenceRequest body);


        /// <returns>The newest shifts.</returns>

        Task<NewShiftsResponse> NewAsync();


        /// <returns>The category names for the requested amount of categories.</returns>

        Task<CategoriesResponse> CategoriesAsync(int page);


        /// <returns>The top 10 most popular shifts.</returns>

        Task<PopularShiftsResponse> PopularAsync();



        /// <returns>The shifts for the queried category.</returns>

        Task<ShiftCategoryResponse> CategoryAsync(int page, string categoryName);


        /// <returns>The status message pertaing to the delete.</returns>

        Task<IndividualShiftDeleteResponse> DeleteIndivdualShiftAsync(string uuid);


        /// <returns>The requested shift.</returns>

        Task<IndividualShiftGetResponse> GetIndivdualShiftAsync(string uuid);


        /// <param name="body">The field name and updated value to update the queried shift.</param>

        /// <returns>The status message pertaing to the update/modify.</returns>

        Task<IndividualShiftPatchResponse> PatchIndivdualShiftAsync(string uuid, IndividualShiftPatchRequest body);

    }


}