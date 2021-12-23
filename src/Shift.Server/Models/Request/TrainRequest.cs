namespace Shift.Server.Models.Request
{
    /// <summary>
    /// The Train Request Data Model for the Shift API
    /// </summary>
    public class TrainRequest
    {
        public string PrebuiltShiftModel { get; set; } = "";
        public string ShiftTitle { get; set; } = "New Shift";
        public string ShiftUUID { get; set; }
        public string TrainType { get; set; } = "basic";
        public bool? UsePTM { get; set; } = false;

    }


}