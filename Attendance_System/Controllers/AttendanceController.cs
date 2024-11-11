using Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Attendance_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceManager _attendanceManager;

        public AttendanceController(IAttendanceManager attendanceManager)
        {
            _attendanceManager = attendanceManager;
        }

        [HttpPost("mark")]
        public async Task<IActionResult> MarkAttendance([FromBody] AttendanceRequest request)
        {
            var result = await _attendanceManager.MarkAttendanceAsync(request);
            return result ? Ok() : BadRequest("Failed to mark attendance.");
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetAttendanceByStudent(int studentId)
        {
            var records = await _attendanceManager.GetAttendanceRecordsByStudentAsync(studentId);
            return Ok(records);
        }

        [HttpGet("class/{classId}")]
        public async Task<IActionResult> GetAttendanceByClass(int classId)
        {
            var records = await _attendanceManager.GetAttendanceRecordsByClassAsync(classId);
            return Ok(records);
        }
    }

}
