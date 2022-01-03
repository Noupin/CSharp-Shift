namespace Shift.Server.Models.Abstractions
{
    public class UserPartialUpdate
    {
        public bool? Admin { get; set; }
        public bool? CanTrain { get; set; }
        public bool? Verified { get; set; }
    }
}
