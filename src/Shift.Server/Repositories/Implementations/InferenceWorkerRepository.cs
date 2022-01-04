using Shift.Server.Context;
using Shift.Server.Models.Abstractions;
using Shift.Server.Models.SQL;
using Shift.Server.Repositories.Abstractions;

namespace Shift.Server.Repositories.Implementations
{
    public class InferenceWorkerRepository : BaseRepository<InferenceWorkerSQL>
    {
        public InferenceWorkerRepository(ShiftContext context) : base(context, context.InferenceWorkers)
        {
        }

        public Task<InferenceWorkerSQL?> ReadWhereAsync(Guid id)
        {
            return ReadWhereAsync((worker) => worker.ShiftId.Equals(id));
        }

        public Task UpdateNameAsync(Guid id, InferenceWorkerPartialUpdate fields)
        {
            return PartialUpdateAsync((worker) => worker.ShiftId.Equals(id),
                (worker) =>
                {
                    worker.ShiftId = fields.ShiftId ?? worker.ShiftId;
                    worker.MediaFilename = fields.MediaFilename ?? worker.MediaFilename;
                    worker.BaseMediaFilename = fields.BaseMediaFilename ?? worker.BaseMediaFilename;
                    worker.WorkerStatus = fields.WorkerStatus ?? worker.WorkerStatus;
                    worker.ClientStatus = fields.ClientStatus ?? worker.ClientStatus;
                });
        }
    }
}
