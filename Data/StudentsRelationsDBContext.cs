using Microsoft.EntityFrameworkCore;
using StudentsRelations.Entities;

namespace StudentsRelations.Data
{
    public class StudentsRelationsDBContext:DbContext
    {
        public StudentsRelationsDBContext(DbContextOptions<StudentsRelationsDBContext> options):base(options)
        {
            
        }
      public   DbSet<Student> Students { get; set; }
      public  DbSet<Account> Accounts { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
