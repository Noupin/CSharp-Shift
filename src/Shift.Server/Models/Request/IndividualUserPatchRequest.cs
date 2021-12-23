namespace Shift.Server.Models.Request
{
    /// <summary>
    /// The Individual User Patch Request Data Model for the Shift API
    /// </summary>
    public class IndividualUserPatchRequest
    {
        public IDictionary<string, string> Data { get; set; } = new Dictionary<string, string>();

    }


}