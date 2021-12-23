namespace Shift.Server.Models
{
    public class FeryvUser
    {
        public bool Admin { get; set; }
        public bool Confirmed { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public List<Schema> Licenses { get; set; }
        public string MediaFilename { get; set; }
        public string Username { get; set; }
        public bool Verified { get; set; }

    }


}