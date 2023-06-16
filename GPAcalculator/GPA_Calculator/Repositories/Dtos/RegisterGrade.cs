using System.ComponentModel.DataAnnotations;

namespace GPA_Calculator.Repositories.Dtos
{
    public class RegisterGrade
    {
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Score must be between 0 and 100")]
        public double Score { get; set; }
    }
}
