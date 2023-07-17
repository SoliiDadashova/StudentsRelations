using StudentsRelations.Persistence;

namespace StudentsRelations.DTOs
{
    public class StudentsUpdateUIDTO:BaseEntity
    { 
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
