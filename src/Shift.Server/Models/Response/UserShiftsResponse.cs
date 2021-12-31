using Shift.Server.Models.SQL;
using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Response
{
    /// <summary>
    /// The User Shifts Response Data Model for the Shift API
    /// </summary>
    public class UserShiftsResponse
    {
        [Required]
        public List<ShiftSQL> Shifts { get; set; }

    }


}