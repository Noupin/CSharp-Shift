using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.SQL
{
    /// <summary>
    /// The data model for a Category
    /// </summary>
    public class CategorySQL
    {
        [Required]
        [StringLength(Constants.MaximumShiftCategoryTitleLength)]
        public string Name { get; set; }
        public List<ShiftSQL> Shifts { get; set; }
    }
}