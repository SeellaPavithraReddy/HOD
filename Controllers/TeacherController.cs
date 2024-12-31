using System.Collections.Generic;
using HODPoc.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController] // Marks this class as an API Controller
    [Route("api/[controller]")] // Defines the route for the controller (e.g., api/students)
    [Authorize(policy: "HodRole")]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherBao teacherBao;

        public TeacherController(TeacherBao teacherBao)
        {
            this.teacherBao = teacherBao;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Teacher> s = await teacherBao.Get();
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
        public async Task<IActionResult> Insert([FromBody] Teacher teacher)
        {
            string s = await teacherBao.Insert(teacher);
            if (s.Contains("1"))
            {
                return Ok("Teacher added");
            }
            else
            {
                return NotFound("No data inserted");
            }
        }
    }
}
