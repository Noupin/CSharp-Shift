using Shift.Server.Models.SQL;
using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Response
{
    /// <summary>
    /// The Popular Shifts Response Data Model for the Shift API
    /// </summary>
    public class PopularShiftsResponse
    {
        [Required]
        public List<ShiftSQL> Shifts { get; set; }
    }
}