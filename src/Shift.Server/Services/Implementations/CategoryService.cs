using Shift.Server.Models.Response;
using Shift.Server.Models.SQL;
using Shift.Server.Repositories.Abstractions;
using Shift.Server.Services.Abstractions;

namespace Shift.Server.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<CategorySQL> _categoryRepository;

        public CategoryService(IBaseRepository<CategorySQL> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<NewShiftsResponse> NewAsync()
        {
            /* Creating Using Repositories
            var category = new CategorySQL
            {
                Name = "Hi"
            };

            await _categoryRepository.CreateAsync(category);

            return new NewShiftsResponse
            {
                Shifts = category.Shifts,
            };
            */
            throw new NotImplementedException();
        }

        public Task<CategoriesResponse> CategoriesAsync(int page)
        {
            throw new NotImplementedException();
        }

        public Task<PopularShiftsResponse> PopularAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ShiftCategoryResponse> CategoryAsync(int page, string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}