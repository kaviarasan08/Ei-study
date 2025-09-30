using System;
using System.Collections.Generic;
using VirtualClassroomManager.Models;

namespace VirtualClassroomManager.Models
{
    public class Classroom
    {
        public string Name { get; }
        private readonly Dictionary<string, Student> students = new();
        private readonly Dictionary<string, Assignment> assignments = new();

        public Classroom(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Classroom name cannot be empty.");
            Name = name;
        }

        public void EnrollStudent(Student s)
        {
            if (!students.ContainsKey(s.Id))
                students[s.Id] = s;
        }

        public bool HasStudent(string studentId) => students.ContainsKey(studentId);
        public void RemoveStudent(string studentId) => students.Remove(studentId);

        public IEnumerable<Student> Students => students.Values;
        public IEnumerable<Assignment> Assignments => assignments.Values;

        public void ScheduleAssignment(Assignment a)
        {
            if (!assignments.ContainsKey(a.Id))
                assignments[a.Id] = a;
        }

        public void SubmitAssignment(string assignmentId, string studentId)
        {
            if (!students.ContainsKey(studentId))
                throw new InvalidOperationException($"Student {studentId} is not enrolled in {Name}.");
            if (!assignments.ContainsKey(assignmentId))
                throw new InvalidOperationException($"Assignment {assignmentId} not found in {Name}.");
            assignments[assignmentId].Submit(studentId);
        }
    }
}
