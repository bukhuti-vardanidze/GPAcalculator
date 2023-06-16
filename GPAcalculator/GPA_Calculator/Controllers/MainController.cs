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

        public MainController(
            IStudentRepository studentRepository,
            ISubjectRepository subjectRepository
            )
        {
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
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

    }
}
