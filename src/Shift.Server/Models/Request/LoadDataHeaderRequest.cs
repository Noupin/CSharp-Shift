using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Request
{
    /// <summary>
    /// The Load Data Header Request Data Model for the Shift API
    /// </summary>
    public class LoadDataHeaderRequest
    {
        [Required]
        public List<string> TrainingDataTypes { get; set; }
    }
}