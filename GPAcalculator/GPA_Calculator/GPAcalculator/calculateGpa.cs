using GPA_Calculator.CalculorGpa;

namespace GPA_Calculator.GPAcalculator
{
    public class calculateGpa
    {
        public double Calculate(List<StudentGrade> studentGrades)
        {
            if (studentGrades.Count == 0)
            {
                return 0.0;
            }

            var totalCredits = studentGrades.Sum(k => k.SubjectCredits);
            var gpaCredits = 0.0;

            foreach(var stGrade in studentGrades) 
            {
                var gp = CalculateGp(stGrade.Score);
                gpaCredits += gp * stGrade.SubjectCredits;
            }

            return gpaCredits / totalCredits;
        }


        private double CalculateGp(double score)
        {
            if (score < 50) return 0;
            if (score <= 60) return 0.5;
            if (score <= 70) return 1.0;
            if (score <= 80) return 2.0;
            if (score <= 90) return 3.0;
            return 4.0;
        }
    }
}
