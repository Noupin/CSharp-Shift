using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.Server.Models.SQL
{
    /// <summary>
    /// The data model for a Shift User
    /// </summary>
    public class UserSQL
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool Admin { get; set; }
        [Required]
        public bool CanTrain { get; set; }
        [Required]
        public bool Verified { get; set; }
        public List<ShiftSQL> Shifts { get; set; }

        [NotMapped]
        public FeryvUserSQL FeryvUser { get; set; }
    }
}