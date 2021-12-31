namespace Shift.Server.Models.Response
{
    /// <summary>
    /// The Inference Status Response Data Model for the Shift API
    /// </summary>
    public class InferenceStatusResponse : DefaultResponse
    {
        public string? BaseMediaFilename { get; set; }
        public string? MaskMediaFilename { get; set; }
        public string? MediaFilename { get; set; }
        public bool Stopped { get; set; } = false;

    }


}