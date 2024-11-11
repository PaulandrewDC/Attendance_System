using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager
{
    public class AttendanceManager : IAttendanceManager
    {
        private readonly List<AttendanceRecord> _attendanceRecords;

        // Constructor - Initialize in-memory list
        public AttendanceManager()
        {
            _attendanceRecords = new List<AttendanceRecord>(); // Use an in-memory list
        }

        // Mark attendance
        public Task<bool> MarkAttendanceAsync(AttendanceRequest request)
        {
            var existingRecord = _attendanceRecords
                .FirstOrDefault(ar => ar.StudentId == request.StudentId
                                    && ar.ClassId == request.ClassId
                                    && ar.Date.Date == request.Date.Date);

            if (existingRecord != null)
            {
                // Update existing attendance record
                existingRecord.IsPresent = request.IsPresent;
            }
            else
            {
                // Create a new attendance record
                var newRecord = new AttendanceRecord
                {
                    StudentId = request.StudentId,
                    ClassId = request.ClassId,
                    Date = request.Date,
                    IsPresent = request.IsPresent
                };
                _attendanceRecords.Add(newRecord);  // Add to in-memory list
            }

            return Task.FromResult(true);  // Simulate saving changes (just return a completed task)
        }

        // Get attendance records by student
        public Task<List<AttendanceRecord>> GetAttendanceRecordsByStudentAsync(int studentId)
        {
            var records = _attendanceRecords.Where(ar => ar.StudentId == studentId).ToList();
            return Task.FromResult(records);  // Return in-memory data as task
        }

        // Get attendance records by class
        public Task<List<AttendanceRecord>> GetAttendanceRecordsByClassAsync(int classId)
        {
            var records = _attendanceRecords.Where(ar => ar.ClassId == classId).ToList();
            return Task.FromResult(records);  // Return in-memory data as task
        }
    }
}

