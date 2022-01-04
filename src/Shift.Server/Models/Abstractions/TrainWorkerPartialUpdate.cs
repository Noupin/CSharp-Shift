using Shift.Server.Types;

namespace Shift.Server.Models.Abstractions
{
    public class TrainWorkerPartialUpdate
    {
        public Guid? ShiftId { get; set; }
        public bool? Training { get; set; }
        public bool? Inferencing { get; set; }
        public bool? ImagesUpdated { get; set; }
        public string? ExhibitImages { get; set; }
        public TStatus? WorkerStatus { get; set; }
        public TStatus? ClientStatus { get; set; }
    }
}
