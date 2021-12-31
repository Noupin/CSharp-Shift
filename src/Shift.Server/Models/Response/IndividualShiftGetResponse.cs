using Shift.Server.Models.SQL;
using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Response
{
    public class IndividualShiftGetResponse
    {
        [Required]
        public bool Owner { get; set; } = false;
        [Required]
        public ShiftSQL Shift { get; set; }

    }
}