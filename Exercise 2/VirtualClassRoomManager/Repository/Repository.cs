using System;
using System.Collections.Generic;
using System.Linq;
using VirtualClassroomManager.Models;
using VirtualClassroomManager.Services;

namespace VirtualClassroomManager.Repo
{
    public class Repository
    {
        private readonly Dictionary<string, Classroom> classrooms = new(StringComparer.OrdinalIgnoreCase);

        public void AddClassroom(string name)
        {
            if (classrooms.ContainsKey(name))
                throw new InvalidOperationException($"Classroom {name} already exists.");
            classrooms[name] = new Classroom(name);
            Logger.Info($"Classroom '{name}' has been created.");
        }

        public void RemoveClassroom(string name)
        {
            if (classrooms.Remove(name))
                Logger.Info($"Classroom '{name}' has been removed.");
            else
                Logger.Warn($"Classroom '{name}' not found.");
        }

        public Classroom GetClassroom(string name)
        {
            if (!classrooms.ContainsKey(name))
                throw new InvalidOperationException($"Classroom {name} not found.");
            return classrooms[name];
        }

        public IEnumerable<Classroom> ListClassrooms() => classrooms.Values;
    }
}
