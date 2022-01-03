using Shift.Server.Types;
using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.SQL
{
    /// <summary>
    /// The data model for an Inference Worker
    /// </summary>
    public class InferenceWorkerSQL
    {
        public Guid Id { get; set; }
        [Required]
        public Guid ShiftId { get; set; }
        [Required]
        public DateTimeOffset TimeStarted { get; set; } = DateTimeOffset.UtcNow;
        [Required]
        public string MediaFilename { get; set; } = "";
        [Required]
        public string BaseMediaFilename { get; set; } = "";
        [Required]
        public TStatus WorkerStatus { get; set; } = TStatus.Pending;
        [Required]
        public TStatus ClientStatus { get; set; } = TStatus.Pending;
    }
}