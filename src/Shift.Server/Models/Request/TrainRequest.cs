using Shift.Server.Types;
using System.ComponentModel.DataAnnotations;

namespace Shift.Server.Models.Request
{
    /// <summary>
    /// The Train Request Data Model for the Shift API
    /// </summary>
    public class TrainRequest
    {
        public string PrebuiltShiftModel { get; set; } = "";
        public string ShiftTitle { get; set; } = "New Shift";
        [Required]
        //Was string
        public Guid ShiftUUID { get; set; }
        public TTrain TrainType { get; set; } = TTrain.Basic;
        public bool UsePTM { get; set; } = false;

    }


}