namespace Joole_BackEnd.Core.Domain
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}