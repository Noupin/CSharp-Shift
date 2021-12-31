using Shift.Server.Models.SQL;
using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Response
{
    /// <summary>
    /// The New Shifts Response Data Model for the Shift API
    /// </summary>
    public class NewShiftsResponse
    {
        [Required]
        public List<ShiftSQL> Shifts { get; set; }
    }
}