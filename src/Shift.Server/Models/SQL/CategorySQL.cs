using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.SQL
{
    /// <summary>
    /// The data model for a Category
    /// </summary>
    public class CategorySQL
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(Constants.MaximumShiftCategoryTitleLength)]
        public string Name { get; set; }
        public ICollection<ShiftCategorySQL> ShiftCategories { get; set; }
    }
}