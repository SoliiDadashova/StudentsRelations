using StudentsRelations.Persistence;

namespace StudentsRelations.DTOs
{
    public class GradeUpdateUIDTO:BaseEntity
    {
        public int Score { get; set; }
        public int StudentID { get; set; }
    }
}
