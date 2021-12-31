using Shift.Server.Models.SQL;
using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Response
{
    /// <summary>
    /// The Individual User Get Response Data Model for the Shift API
    /// </summary>
    public class IndividualUserGetResponse
    {
        public bool Owner { get; set; } = false;
        [Required]
        public UserSQL User { get; set; }

    }
}