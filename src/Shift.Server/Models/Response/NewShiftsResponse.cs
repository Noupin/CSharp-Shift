namespace Shift.Server.Models.Response
{
    /// <summary>
    /// The New Shifts Response Data Model for the Shift API
    /// </summary>
    public class NewShiftsResponse
    {
        public List<SQL.Shift> Shifts { get; set; }
    }
}