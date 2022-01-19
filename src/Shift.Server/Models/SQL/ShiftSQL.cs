using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.SQL
{
    /// <summary>
    /// The data model for a Shift
    /// </summary>
    public class ShiftSQL
    {
        //Was called Uuid
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public UserSQL Author { get; set; }

        [Required]
        [StringLength(Constants.MaximumShiftTitleLength)]
        public string Title { get; set; }
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(Constants.MaximumFilenameLength)]
        public string MediaFilename { get; set; } = "default.jpg";
        [Required]
        [StringLength(Constants.MaximumFilenameLength)]
        public string BaseMediaFilename { get; set; } = "default.jpg";
        [Required]
        [StringLength(Constants.MaximumFilenameLength)]
        public string MaskMediaFilename { get; set; } = "default.jpg";

        [Required]
        public bool Private { get; set; } = false;
        [Required]
        public bool Verified { get; set; } = false;
        [Required]
        public int Views { get; set; } = 0;

        public ICollection<ShiftCategorySQL> ShiftCategories { get; set; }
    }
}