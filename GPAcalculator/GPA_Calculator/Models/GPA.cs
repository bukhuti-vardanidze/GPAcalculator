using System.ComponentModel.DataAnnotations;

namespace GPA_Calculator.Models
{
    public class GPA
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public double Value { get; set; }
        public DateTime CalculateTime { get; set; }
    }
}
