using System.Collections.Generic;
using HODPoc.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController] // Marks this class as an API Controller
    [Route("api/[controller]")] // Defines the route for the controller (e.g., api/students)
    [Authorize(policy: "SubjectRole")]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectBao subjectBao;

        public SubjectController(SubjectBao subjectBao)
        {
            this.subjectBao = subjectBao;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Subject> s = await subjectBao.Get();
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
        public async Task<IActionResult> Insert([FromBody] Subject subject)
        {
            string s = await subjectBao.Insert(subject);
            if (s.Contains("1"))
            {
                return Ok("Subject added");
            }
            else
            {
                return NotFound("No data inserted");
            }
        }
    }
}
