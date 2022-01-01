using Shift.Server.Models.Response;

namespace Shift.Server.Services
{
    public class CategoryService : ICategoryService
    {
        Task<NewShiftsResponse> ICategoryService.NewAsync()
        {
            throw new NotImplementedException();
        }

        Task<CategoriesResponse> ICategoryService.CategoriesAsync(int page)
        {
            throw new NotImplementedException();
        }

        Task<PopularShiftsResponse> ICategoryService.PopularAsync()
        {
            throw new NotImplementedException();
        }

        Task<ShiftCategoryResponse> ICategoryService.CategoryAsync(int page, string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}