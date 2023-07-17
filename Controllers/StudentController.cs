using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsRelations.Data;
using StudentsRelations.DTOs;
using StudentsRelations.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsRelations.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentsRelationsDBContext Context { get; }
        public StudentController(StudentsRelationsDBContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<List<Student>> GetStudents()
        {
            return await Context.Students.ToListAsync();
        }
        [HttpGet("StudentID")]
        public async Task<ActionResult> GetAverageGrade(int id)
        {
            var student = await Context.Students.Include(m=>m.Grades).Where(m=>m.Id==id).FirstOrDefaultAsync();
            var avg = student.Grades.Average(m => m.Score);
            return Ok(avg);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudents(StudentAddUIDTO student)
        {
            Student studentdEntitiy = new()
            {
                Name = student.Name,
                Age = student.Age,
            };
            await Context.AddAsync(studentdEntitiy);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudents(StudentsUpdateUIDTO student)
        {
            Student studentEntity = new()
            {
                Id=student.Id,
                Name = student.Name,
                Age = student.Age,
            };
            studentEntity.Name = student.Name;
            studentEntity.Age = student.Age;
            var updatedStudent = await Context.Students.FindAsync(studentEntity.Id);
            Context.Students.Update(updatedStudent);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudents(int id)
        {
            var deletedStudent = await Context.Students.FindAsync(id);
            Context.Students.Remove(deletedStudent);
            return Ok();    
        
        }
    }   
}