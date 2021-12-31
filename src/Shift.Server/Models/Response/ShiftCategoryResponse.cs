using Shift.Server.Models.SQL;
using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Response
{
    /// <summary>
    /// The Shift Category Response Data Model for the Shift API
    /// </summary>
    public class ShiftCategoryResponse
    {
        [Required]
        public List<ShiftSQL> Shifts { get; set; }

    }


}