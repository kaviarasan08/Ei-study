using System;
using System.Collections.Generic;

namespace VirtualClassroomManager.Models
{
    public class Assignment
    {
        public string Id { get; }
        public string Description { get; }
        public HashSet<string> SubmittedBy { get; } = new();

        public Assignment(string id, string description)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Assignment ID cannot be empty.");
            Id = id;
            Description = description ?? "";
        }

        public void Submit(string studentId) => SubmittedBy.Add(studentId);
    }
}
