using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Response
{
    /// <summary>
    /// The Load Response Data Model for the Shift API
    /// </summary>
    public class LoadDataResponse : DefaultResponse
    {
        [Required]
        public string ShiftUUID { get; set; } = "";

    }
}