using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPA_Calculator.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Score must be between 0 and 100")]
        public double Score { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student student { get; set; }
    }
}
