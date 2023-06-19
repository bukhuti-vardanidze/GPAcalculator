using GPA_Calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace GPA_Calculator.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        

    }
}
