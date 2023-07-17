using StudentsRelations.Persistence;
using System.Collections.Generic;
using System.Security.Permissions;

namespace StudentsRelations.Entities
{
    public class Student:BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Grade> Grades { get; set; }
     
    }
}
