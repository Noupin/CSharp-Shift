using Shift.Server.Models.Response;
using Shift.Server.Models.SQL;
using Shift.Server.Repositories.Implementations;
using Shift.Server.Services.Abstractions;

namespace Shift.Server.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly ShiftRepository _shiftRepository;
        private readonly ShiftCategoryRepository _shiftCategoryRepository;

        public CategoryService(CategoryRepository categoryRepository, ShiftRepository shiftRepository, ShiftCategoryRepository shiftCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _shiftRepository = shiftRepository;
            _shiftCategoryRepository = shiftCategoryRepository;
        }

        public async Task<NewShiftsResponse> NewAsync()
        {
            var shifts = await _shiftRepository.ReadNewAsync();
            return new NewShiftsResponse
            {
                Shifts = shifts
            };
        }

        public async Task<CategoriesResponse> CategoriesAsync(int page)
        {
            var categories = await _categoryRepository.ReadAllAsync(page, Constants.ItemsPerPage);
            List<string> categoryNames = new List<string>();

            foreach (var category in categories)
            {
                categoryNames.Add(category.Name);
            }

            return new CategoriesResponse
            {
                Categories = categoryNames
            };
        }

        public async Task<PopularShiftsResponse> PopularAsync()
        {
            var shifts = await _shiftRepository.ReadPopularAsync();
            return new PopularShiftsResponse
            {
                Shifts = shifts
            };
        }

        public async Task<ShiftCategoryResponse> CategoryAsync(int page, string categoryName)
        {
            var shiftCategories = await _shiftCategoryRepository.ReadWhereAsync(categoryName, page, Constants.ItemsPerPage);
            var shifts = new List<ShiftSQL>();

            foreach (var shiftCategory in shiftCategories)
            {
                shifts.Add(shiftCategory.Shift);
            }

            return new ShiftCategoryResponse
            {
                Shifts = shifts
            };
        }
    }
}