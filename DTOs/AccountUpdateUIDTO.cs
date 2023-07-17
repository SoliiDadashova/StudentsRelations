using StudentsRelations.Persistence;
using System.Buffers.Text;

namespace StudentsRelations.DTOs
{
    public class AccountUpdateUIDTO:BaseEntity
    {
        public string Address { get; set; }
        public int StudentID { get; set; }
    }
}
