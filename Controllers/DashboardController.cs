// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// [Route("api/[controller]")]
// [ApiController]
// public class DashboardController : ControllerBase
// {
//     // Accessible to all authenticated users
//     [HttpGet("user")]
//     [Authorize]
//     public IActionResult GetUserDashboard()
//     {
//         return Ok("User Dashboard - Accessible to all authenticated users.");
//     }

//     // Accessible only to Admin
//     [HttpGet("Hod")]
//     [Authorize(Policy = "HodRole")]
//     public IActionResult GetAdminDashboard()
//     {
//         return Ok("Admin Dashboard - Accessible only to Admins.");
//     }

//     // Accessible only to Teacher
//     [HttpGet("teacher")]
//     [Authorize(Policy = "HodRole")]
//     public IActionResult GetTeacherDashboard()
//     {
//         return Ok("Teacher Dashboard - Accessible only to Teachers.");
//     }

//     // Accessible only to Student
//     [HttpGet("student")]
//     [Authorize(Policy = "StudentRole")]
//     public IActionResult GetStudentDashboard()
//     {
//         return Ok("Student Dashboard - Accessible only to Students.");
//     }
// }
