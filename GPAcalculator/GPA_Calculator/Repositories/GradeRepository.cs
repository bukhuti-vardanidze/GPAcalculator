using GPA_Calculator.DB;
using GPA_Calculator.Models;
using GPA_Calculator.Repositories.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GPA_Calculator.Repositories
{ 
    public interface IGradeRepository
    {
        Task<Grade> RegisterGrade(RegisterGrade register);
        Task<List<Grade>> GetStudentGrade(int id);
    }
    public class GradeRepository : IGradeRepository
    {
        private readonly DataContext _context;

        public GradeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Grade> RegisterGrade(RegisterGrade register)
        {
            var grade = new Grade()
            {
                StudentId = register.StudentId,
                SubjectId = register.SubjectId,
                Score = register.Score
            };

            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        public async Task<List<Grade>> GetStudentGrade(int id)
        {
            var StudentGrade = await _context.Grades
                            .Where(x => x.StudentId == id)
                            .Include(x=>x.student)
                            .ToListAsync();

            return StudentGrade;
        }

    }


}
