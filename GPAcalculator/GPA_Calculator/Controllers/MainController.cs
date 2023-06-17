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

        public MainController(
            IStudentRepository studentRepository,
            ISubjectRepository subjectRepository,
            IGradeRepository gradeRepository
            )
        {
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _gradeRepository = gradeRepository;
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

    }
}
