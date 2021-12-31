namespace Shift.Server.Models.Response
{
    /// <summary>
    /// The Train Status Response Data Model for the Shift API
    /// </summary>
    public class TrainStatusResponse : DefaultResponse
    {
        public List<string> Exhibit { get; set; }
        public bool Stopped { get; set; } = false;

    }
}