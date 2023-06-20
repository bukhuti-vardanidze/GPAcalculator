using GPA_Calculator.CalculorGpa;
using GPA_Calculator.GPAcalculator;
using GPA_Calculator.Models;
using GPA_Calculator.Repositories;
using GPA_Calculator.Repositories.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPA_Calculator.Controllers
{
    [Route("")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly ICalculateGPARepository _calculateGPARepository;
        private readonly IStatisticRepository  _statisticRepository;                  

        public MainController(
            IStudentRepository studentRepository,
            ISubjectRepository subjectRepository,
            IGradeRepository gradeRepository,
            ICalculateGPARepository calculateGPARepository,
            IStatisticRepository statisticRepository   
            )
        {
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _gradeRepository = gradeRepository;
            _calculateGPARepository = calculateGPARepository;
            _statisticRepository = statisticRepository;
        }

        [HttpPost("student")]
        public async Task<IActionResult> RegisterStudent([FromQuery]RegisterStudent register)
        {
            var result = await _studentRepository.RegisterStudent(register);

            if(result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("subject")]
        public async Task<IActionResult> RegisterSubject([FromQuery] RegisterSubject register)
        {
            var result =await _subjectRepository.RegisterSubject(register);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("grade")]
        public async Task<IActionResult> RegisterGrade([FromQuery]RegisterGrade register)
        {
            var result = await _gradeRepository.RegisterGrade(register);
            
            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("/student/{Id}/grades")]
        public async Task<IActionResult> GetStudentGrade([FromRoute] int Id)
        {
            var result =await _gradeRepository.GetStudentGrade(Id);
            
            if (result == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpGet("/student/{studentId}/gpa")]
        public async Task<IActionResult> CalulateGpa([FromRoute]int studentId)
        {
            var studentGrades = await _calculateGPARepository.GetStudentGrade(studentId);
            var calculateGPA = new calculateGpa();
            var StudentGPA = calculateGPA.Calculate(studentGrades);
            return Ok(StudentGPA);

        }

        [HttpGet("/Top3")]
        public async Task<IActionResult> getTop3Subject()
        {
            var subject = await _statisticRepository.GetTop3Subject();

            if(subject == null)
            {
                return NotFound("Subject Not Found");
            }

            return Ok(subject);
        }

    }
}
