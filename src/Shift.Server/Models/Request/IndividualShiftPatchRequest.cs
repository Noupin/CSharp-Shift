namespace Shift.Server.Models.Request
{
    /// <summary>
    /// The Individual Shift Patch Request Data Model for the Shift API
    /// </summary>
    public class IndividualShiftPatchRequest
    {
        public string? Title { get; set; }
        public bool? Private { get; set; }
    }
}