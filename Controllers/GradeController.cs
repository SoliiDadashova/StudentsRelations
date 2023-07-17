using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsRelations.Data;
using StudentsRelations.DTOs;
using StudentsRelations.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace StudentsRelations.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        public StudentsRelationsDBContext _context { get; }
        public GradeController(StudentsRelationsDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Grade>> GetAll()
        {
            var allGrades=await _context.Grades.Include(m=>m.Student).ToListAsync();
            return allGrades;
        }
        [HttpPost]
        public async Task<IActionResult> AddGrade(GradeAddUIDTO grade)
        {
            Grade gradeEntity = new()
            {
                Score=grade.Score,
                StudentID=grade.StudentID
            };
            await _context.Grades.AddAsync(gradeEntity);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UptadeGrade(GradeUpdateUIDTO grade)
        {
            Grade gradeEntity = new()
            {
                Id=grade.Id,
                StudentID = grade.StudentID,
                Score = grade.Score,
            };
            var uptadtedGrade= await _context.Grades.FindAsync(gradeEntity.Id);
            if(uptadtedGrade == null)
            {
                return BadRequest();

            }
            uptadtedGrade.Score=grade.Score;    
            uptadtedGrade.StudentID=grade.StudentID;
            _context.Grades.Update(uptadtedGrade);
           await  _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteGrades(int id)
        {
             var deletedGrade= await _context.Grades.FindAsync(id);
            _context.Grades.Remove(deletedGrade);
            await _context.SaveChangesAsync();  
            return Ok();

        }
    }
}
