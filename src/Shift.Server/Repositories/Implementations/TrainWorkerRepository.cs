using BaseRepository;
using Shift.Server.Context;
using Shift.Server.Models.Abstractions;
using Shift.Server.Models.SQL;

namespace Shift.Server.Repositories.Implementations
{
    public class TrainWorkerRepository : BaseRepository<TrainWorkerSQL, ShiftContext>
    {
        public TrainWorkerRepository(ShiftContext context) : base(context, context.TrainWorkers)
        {
        }

        public Task<TrainWorkerSQL?> ReadWhereAsync(Guid id)
        {
            return ReadWhereAsync((worker) => worker.ShiftId.Equals(id));
        }

        public Task UpdateNameAsync(Guid id, TrainWorkerPartialUpdate fields)
        {
            return PartialUpdateAsync((worker) => worker.ShiftId.Equals(id),
                (worker) =>
                {
                    worker.Training = fields.Training ?? worker.Training;
                    worker.Inferencing = fields.Inferencing ?? worker.Inferencing;
                    worker.ImagesUpdated = fields.ImagesUpdated ?? worker.ImagesUpdated;
                    worker.ExhibitImages = fields.ExhibitImages ?? worker.ExhibitImages;
                    worker.WorkerStatus = fields.WorkerStatus ?? worker.WorkerStatus;
                    worker.ClientStatus = fields.ClientStatus ?? worker.ClientStatus;
                });
        }
    }
}
