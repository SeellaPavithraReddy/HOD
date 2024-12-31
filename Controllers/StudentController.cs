using System.Collections.Generic;
using HODPoc.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController] // Marks this class as an API Controller
    [Route("api/[controller]")] // Defines the route for the controller (e.g., api/students)
    [Authorize(policy: "TeacherRole")]
    public class StudentsController : ControllerBase
    {
        StudentBao studentBao = null;

        public StudentsController(StudentBao studentBao)
        {
            this.studentBao = studentBao;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Student> s = await studentBao.Get();
            if (s != null)
            {
                return Ok(s);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Student student)
        {
            string s = await studentBao.Insert(student);
            if (s.Contains("1"))
            {
                return Ok("Student added");
            }
            else
            {
                return NotFound("No data inserted");
            }
        }
    }
}
