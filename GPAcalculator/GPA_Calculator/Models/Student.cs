using System.ComponentModel.DataAnnotations;

namespace GPA_Calculator.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<Subject> subject { get; set;}
    }
}
