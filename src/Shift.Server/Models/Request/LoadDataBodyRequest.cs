using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Request
{
    /// <summary>
    /// The Load Data Body Request Data Model for the Shift API
    /// </summary>
    public class LoadDataBodyRequest
    {
        [Required]
        public List<IFormFile> RequestFiles { get; set; }
    }
}