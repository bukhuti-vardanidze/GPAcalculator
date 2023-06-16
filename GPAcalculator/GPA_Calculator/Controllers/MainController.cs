using GPA_Calculator.Repositories;
using GPA_Calculator.Repositories.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPA_Calculator.Controllers
{
    [Route("/")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public MainController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost("student")]
        public async Task<IActionResult> RegisterStudent([FromQuery]RegisterStudent register)
        {
            var result = await _studentRepository.RegisterStudent(register);
            if(register == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
