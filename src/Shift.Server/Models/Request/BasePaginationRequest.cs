using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Request
{
    /// <summary>
    /// The Base Pagination Request Data Model for the Shift API
    /// </summary>
    public class BasePaginationRequest
    {
        [Required]
        public int Page { get; set; }
    }
}