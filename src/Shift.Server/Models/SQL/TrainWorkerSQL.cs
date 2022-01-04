using Shift.Server.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.Server.Models.SQL
{
    /// <summary>
    /// The data model for a Train Worker
    /// </summary>
    public class TrainWorkerSQL
    {
        public Guid Id { get; set; }
        [Required]
        public Guid ShiftId { get; set; }

        [Required]
        public DateTimeOffset TimeStarted { get; set; } = DateTimeOffset.UtcNow;

        [Required]
        public bool Training { get; set; } = false;
        [Required]
        public bool Inferencing { get; set; } = false;
        [Required]
        public bool ImagesUpdated { get; set; } = false;

        [Required]
        public string ExhibitImages { get; set; } = "";
        [NotMapped]
        public string[] ExhibitImageArray
        {
            get
            {
                return ExhibitImages.Split(';');
            }
        }

        [Required]
        public TStatus WorkerStatus { get; set; } = TStatus.Pending;
        [Required]
        public TStatus ClientStatus { get; set; } = TStatus.Pending;
    }
}