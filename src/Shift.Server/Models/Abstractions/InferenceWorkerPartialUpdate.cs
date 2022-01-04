using Shift.Server.Types;

namespace Shift.Server.Models.Abstractions
{
    public class InferenceWorkerPartialUpdate
    {
        public Guid? ShiftId { get; set; }
        public string? MediaFilename { get; set; }
        public string? BaseMediaFilename { get; set; }
        public TStatus? WorkerStatus { get; set; }
        public TStatus? ClientStatus { get; set; }
    }
}
