using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Request
{
    /// <summary>
    /// The Individual Shift Patch Request Data Model for the Shift API
    /// </summary>
    public class IndividualShiftPatchRequest
    {
        [Required]
        public IDictionary<string, string> Data { get; set; } = new Dictionary<string, string>();

    }


}