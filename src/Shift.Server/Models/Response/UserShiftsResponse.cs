namespace Shift.Server.Models.Response
{
    /// <summary>
    /// The User Shifts Response Data Model for the Shift API
    /// </summary>
    public class UserShiftsResponse
    {
        public List<SQL.Shift> Shifts { get; set; }

    }


}