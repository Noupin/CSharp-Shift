namespace Shift.Server.Models.Response
{
    /// <summary>
    /// The Categories Response Data Model for the Shift API
    /// </summary>
    public class CategoriesResponse
    {
        public List<string> Categories { get; set; } = new List<string>();
    }

}