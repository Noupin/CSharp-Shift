using Microsoft.AspNetCore.Mvc;
using Shift.Server.Models.Response;

namespace Shift.Server.Controllers
{

    [Route("api")]

    public class CategoryController : ControllerBase
    {
        private ICategoryService _implementation;

        public CategoryController(ICategoryService implementation)
        {
            _implementation = implementation;
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
    }
}