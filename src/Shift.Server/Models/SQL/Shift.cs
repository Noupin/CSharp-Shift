namespace Shift.Server.Models.SQL
{
    public class Shift
    {
        public User Author { get; set; } = new User();
        public string BaseMediaFilename { get; set; }
        public List<Category> Categories { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        //Changed from Uuid to Id
        public Guid Id { get; set; }
        public string MaskMediaFilename { get; set; }
        public string MediaFilename { get; set; }
        public bool? Private { get; set; }
        public string Title { get; set; }
        public bool? Verified { get; set; }
        public int? Views { get; set; }
    }
}