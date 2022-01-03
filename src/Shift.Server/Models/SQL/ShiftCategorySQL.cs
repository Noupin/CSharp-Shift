using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.SQL
{
    /// <summary>
    /// The data model for a Shift Category
    /// </summary>
    public class ShiftCategorySQL
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ShiftId { get; set; }
        [Required]
        public ShiftSQL Shift { get; set; }

        [Required]
        public string CategoryName { get; set; }
        [Required]
        public CategorySQL Category { get; set; }
    }
}