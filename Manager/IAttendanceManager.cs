using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public interface IAttendanceManager
    {
        Task<bool> MarkAttendanceAsync(AttendanceRequest request);
        Task<List<AttendanceRecord>> GetAttendanceRecordsByStudentAsync(int studentId);
        Task<List<AttendanceRecord>> GetAttendanceRecordsByClassAsync(int classId);
    }

}
