using Shift.Server.Models.Request;

namespace Shift.Server.Models.Abstractions
{
    public class ShiftPartialUpdate : IndividualShiftPatchRequest
    {
        public bool? Verified { get; set; }
    }
}
