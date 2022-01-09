using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.SQL
{
    /// <summary>
    /// The data model for a Feryv User
    /// </summary>
    public class LicenseSQL
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid FeryvUserId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}