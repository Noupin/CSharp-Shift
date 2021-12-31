using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Request
{
    /// <summary>
    /// The Inference Request Data Model for the Shift API
    /// </summary>
    public class InferenceRequest
    {
        public string PrebuiltShiftModel { get; set; } = "";
        //Was string
        [Required]
        public Guid ShiftUUID { get; set; }
        public bool Training { get; set; } = false;
        public bool UsePTM { get; set; } = false;

    }


}