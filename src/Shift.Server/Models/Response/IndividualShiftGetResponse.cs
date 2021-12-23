namespace Shift.Server.Models.Response
{
    public class IndividualShiftGetResponse
    {
        public bool Owner { get; set; }
        public SQL.Shift Shift { get; set; }

    }
}