using GPA_Calculator.DB;
using GPA_Calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace GPA_Calculator.CalculorGpa
{
    public interface ICalculateGPARepository
    {
        Task<List<StudentGrade>> GetStudentGrade(int studentId);
    }

    public class CalculateGPARepository : ICalculateGPARepository
    {
        private readonly DataContext _context;

        public CalculateGPARepository(DataContext context)
        {
            _context = context;
        }


        public async Task<List<StudentGrade>> GetStudentGrade(int studentId)
        {
            var studentGrade = await _context.Grades
                                .Where(g => g.StudentId == studentId)
                                .Select(g => new StudentGrade
                                {
                                    StudentId = g.StudentId,
                                    SubjectCredits = g.Subject.Credits,
                                    Score = g.Score
                                })
                                .ToListAsync();

            return studentGrade;
        }
    }


}
