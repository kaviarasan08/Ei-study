using System;

namespace VirtualClassroomManager.Models
{
    public class Student
    {
        public string Id { get; }

        public Student(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Student ID cannot be empty.");
            Id = id;
        }
    }
}
