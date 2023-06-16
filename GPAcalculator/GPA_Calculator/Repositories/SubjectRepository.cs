using GPA_Calculator.DB;
using GPA_Calculator.Models;
using GPA_Calculator.Repositories.Dtos;

namespace GPA_Calculator.Repositories
{
    public interface ISubjectRepository
    {
        Task<Subject> RegisterSubject(RegisterSubject register);
    }
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DataContext _context;

        public SubjectRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Subject> RegisterSubject(RegisterSubject register)
        {
            var subject = new Subject()
            {
              //  StudentId = register.StudentId,
                SubjectName = register.SubjectName,
                Credits = register.Credits
            };

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }
    }


}
