namespace Shift.Server.Models.Request
{
    /// <summary>
    /// The Inference Request Data Model for the Shift API
    /// </summary>
    public class InferenceRequest
    {
        public string PrebuiltShiftModel { get; set; } = "";
        public string ShiftUUID { get; set; }
        public bool? Training { get; set; } = false;
        public bool? UsePTM { get; set; } = false;

    }


}