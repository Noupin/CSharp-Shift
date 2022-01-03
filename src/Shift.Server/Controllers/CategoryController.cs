using Microsoft.AspNetCore.Mvc;
using Shift.Server.Models.Response;
using Shift.Server.Services.Interfaces;

namespace Shift.Server.Controllers
{

    [Route("api")]

    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <returns>The newest shifts.</returns>
        [HttpGet, Route("shift/category/new", Name = "new")]
        public Task<NewShiftsResponse> New()
        {

            return _categoryService.NewAsync();
        }

        /// <returns>The category names for the requested amount of categories.</returns>
        [HttpGet, Route("shift/category/categories", Name = "Categories")]
        public Task<CategoriesResponse> Categories([FromQuery] int page)
        {

            return _categoryService.CategoriesAsync(page);
        }

        /// <returns>The top 10 most popular shifts.</returns>
        [HttpGet, Route("shift/category/popular", Name = "popular")]
        public Task<PopularShiftsResponse> Popular()
        {

            return _categoryService.PopularAsync();
        }

        /// <returns>The shifts for the queried category.</returns>
        [HttpGet, Route("shift/category/{categoryName}", Name = "Category")]
        public Task<ShiftCategoryResponse> Category([FromQuery] int page, string categoryName)
        {

            return _categoryService.CategoryAsync(page, categoryName);
        }
    }
}