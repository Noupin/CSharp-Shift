namespace Shift.Server.Models.SQL
{
    public class ShiftCategory
    {
        public int Id { get; set; }
        public Guid ShiftId { get; set; }
        public string CategoryName { get; set; }
        public List<Shift> shift { get; set; }
        public List<Category> category { get; set; }
    }
}