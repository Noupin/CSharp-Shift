namespace Shift.Server.Models.SQL
{
    public class User
    {
        public bool? Admin { get; set; }
        public bool? CanTrain { get; set; }
        public int? Id { get; set; }
        public bool? Verified { get; set; }
    }
}