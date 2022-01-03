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
        public string ExhibitImages
        {
            get { return ExhibitImages; }
            set
            {
                ExhibitImages = $"{ExhibitImages};{value}";
                ExhibitImageArray = ExhibitImages.Split(";");
            }
        }
        [NotMapped]
        public string[] ExhibitImageArray { get; set; }

        [Required]
        public TStatus WorkerStatus { get; set; } = TStatus.Pending;
        [Required]
        public TStatus ClientStatus { get; set; } = TStatus.Pending;
    }
}