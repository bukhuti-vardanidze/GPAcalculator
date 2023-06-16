using GPA_Calculator.DB;
using GPA_Calculator.Models;
using GPA_Calculator.Repositories.Dtos;

namespace GPA_Calculator.Repositories
{ 
    public interface IGradeRepository
    {
        Task<Grade> RegisterGrade(RegisterGrade register);
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
    }


}
