using StudentsRelations.Persistence;

namespace StudentsRelations.Entities
{
    public class Account:BaseEntity
    {
        public string Address { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
