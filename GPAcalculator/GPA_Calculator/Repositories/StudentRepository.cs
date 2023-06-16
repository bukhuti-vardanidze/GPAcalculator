using GPA_Calculator.DB;
using GPA_Calculator.Models;
using GPA_Calculator.Repositories.Dtos;

namespace GPA_Calculator.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> RegisterStudent(RegisterStudent register);
    }
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<Student> RegisterStudent(RegisterStudent register)
        {
            var student = new Student()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                PersonalNumber = register.PersonalNumber,
                CourseName = register.CourseName
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }


    }


}
