namespace Shift.Server.Models.Request
{
    /// <summary>
    /// The Load Data Body Request Data Model for the Shift API
    /// </summary>
    public class LoadDataBodyRequest
    {
        public IEnumerable<IFormFile> RequestFiles { get; set; }
    }
}