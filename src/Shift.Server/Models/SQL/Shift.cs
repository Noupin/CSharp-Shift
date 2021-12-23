namespace Shift.Server.Models.SQL
{
    public class Shift
    {
        public User Author { get; set; } = new User();
        public string BaseMediaFilename { get; set; }
        public List<object> Categories { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        public string MaskMediaFilename { get; set; }
        public string MediaFilename { get; set; }
        public bool? Private { get; set; }
        public List<object> ShiftCategories { get; set; }
        public string Title { get; set; }
        public Guid Uuid { get; set; }
        public bool? Verified { get; set; }
        public int? Views { get; set; }

    }


}