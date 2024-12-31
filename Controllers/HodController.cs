using System.Collections.Generic;
using HODPoc.Models.BAO;
using HODPoc.Models.DAO;
using HODPoc.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController] // Marks this class as an API Controller
    [Route("api/[controller]")] // Defines the route for the controller (e.g., api/students)
    [Authorize]
    public class HodController : ControllerBase
    {
        private readonly HodBao hodBao;

        public HodController(HodBao hodBao)
        {
            this.hodBao = hodBao;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Hod> s = await hodBao.Get();
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
        public async Task<IActionResult> Insert([FromBody] Hod hod)
        {
            string s = await hodBao.Insert(hod);
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
