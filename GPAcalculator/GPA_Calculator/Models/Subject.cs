using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPA_Calculator.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student student { get; set; }

        public virtual ICollection<Grade> Grade { get; set; }
    }
}
