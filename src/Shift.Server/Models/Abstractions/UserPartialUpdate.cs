using Shift.Server.Models.Request;

namespace Shift.Server.Models.Abstractions
{
    public class UserPartialUpdate : IndividualUserPatchRequest
    {
        public bool? Admin { get; set; }
        public bool? CanTrain { get; set; }
        public bool? Verified { get; set; }
    }
}
