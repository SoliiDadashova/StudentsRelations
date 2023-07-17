using StudentsRelations.Persistence;

namespace StudentsRelations.Entities
{
    public class Grade:BaseEntity
    {
        public int Score { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
