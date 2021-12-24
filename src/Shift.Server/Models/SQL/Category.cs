namespace Shift.Server.Models.SQL
{
    public class Category
    {
        public string name { get; set; }
        public List<Shift> shifts { get; set; }
    }
}