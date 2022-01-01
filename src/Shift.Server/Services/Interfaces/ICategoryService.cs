using Shift.Server.Models.Response;

namespace Shift.Server.Services
{
    public interface ICategoryService
    {
        /// <returns>The newest shifts.</returns>

        Task<NewShiftsResponse> NewAsync();


        /// <returns>The category names for the requested amount of categories.</returns>

        Task<CategoriesResponse> CategoriesAsync(int page);


        /// <returns>The top 10 most popular shifts.</returns>

        Task<PopularShiftsResponse> PopularAsync();



        /// <returns>The shifts for the queried category.</returns>

        Task<ShiftCategoryResponse> CategoryAsync(int page, string categoryName);
    }
}