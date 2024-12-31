using System.Collections.Generic;
using HODPoc.Models.BAO;
using HODPoc.Models.DAO;
using HODPoc.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController] // Marks this class as an API Controller
    [Route("api/[controller]")] // Defines the route for the controller (e.g., api/students)
    public class LoginController : ControllerBase
    {
        private readonly LoginBao loginBao;

        public LoginController(LoginBao loginBao)
        {
            this.loginBao = loginBao;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Login> s = await loginBao.Get();
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
        public async Task<IActionResult> Insert([FromBody] Login login)
        {
            string s = await loginBao.Insert(login);
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
