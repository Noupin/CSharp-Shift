using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.SQL
{
    /// <summary>
    /// The data model for a Feryv User
    /// </summary>
    public class FeryvUserSQL
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(15)]
        public string Username { get; set; }
        [Required]
        [StringLength(25)]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        public string MediaFilename { get; set; }

        [Required]
        public bool Verified { get; set; }
        [Required]
        public bool Admin { get; set; }
        [Required]
        public bool Confirmed { get; set; }

        public List<LicenseSQL> Licenses { get; set; }
    }
}