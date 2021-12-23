namespace Shift.Server.Models.Response
{
    /// <summary>
    /// The Individual User Get Response Data Model for the Shift API
    /// </summary>
    public class IndividualUserGetResponse
    {
        public bool Owner { get; set; }
        public User User { get; set; }

    }
}