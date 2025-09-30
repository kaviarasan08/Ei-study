using System;
using System.Linq;
using VirtualClassroomManager.Repo;
using VirtualClassroomManager.Models;
using VirtualClassroomManager.Services;

namespace VirtualClassroomManager
{
    class Program
    {
        public static void Main(string[] args)
        {
            var repo = new Repository();
            Console.WriteLine("Virtual Classroom Manager. Type 'help' for commands.");

            while (true)
            {
                Console.Write("\n> ");
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;

                var parts = input.Split(' ', 4, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                var cmd = parts[0].ToLower();
                try
                {
                    switch (cmd)
                    {
                        case "add_classroom":
                            if (parts.Length < 2) throw new ArgumentException("Usage: add_classroom [name]");
                            repo.AddClassroom(parts[1]);
                            break;

                        case "remove_classroom":
                            if (parts.Length < 2) throw new ArgumentException("Usage: remove_classroom [name]");
                            repo.RemoveClassroom(parts[1]);
                            break;

                        case "add_student":
                            if (parts.Length < 3) throw new ArgumentException("Usage: add_student [id] [class]");
                            repo.GetClassroom(parts[2]).EnrollStudent(new Student(parts[1]));
                            Logger.Info($"Student '{parts[1]}' has been enrolled in '{parts[2]}'.");
                            break;

                        case "schedule_assignment":
                            if (parts.Length < 4) throw new ArgumentException("Usage: schedule_assignment [class] [id] [desc]");
                            repo.GetClassroom(parts[1]).ScheduleAssignment(new Assignment(parts[2], parts[3]));
                            Logger.Info($"Assignment '{parts[2]}' scheduled in '{parts[1]}'.");
                            break;

                        case "submit_assignment":
                            if (parts.Length < 4) throw new ArgumentException("Usage: submit_assignment [id] [class] [student]");
                            repo.GetClassroom(parts[2]).SubmitAssignment(parts[1], parts[3]);
                            Logger.Info($"Assignment '{parts[1]}' submitted by '{parts[3]}' in '{parts[2]}'.");
                            break;

                        case "list_classrooms":
                            var classes = repo.ListClassrooms().ToList();
                            if (!classes.Any())
                            {
                                Logger.Warn("No classrooms available.");
                                break;
                            }
                            foreach (var c in classes)
                                Console.WriteLine($"- {c.Name} (Students: {c.Students.Count()}, Assignments: {c.Assignments.Count()})");
                            break;

                        case "list_students":
                            if (parts.Length < 2) throw new ArgumentException("Usage: list_students [class]");
                            var students = repo.GetClassroom(parts[1]).Students.ToList();
                            if (!students.Any())
                                Logger.Warn($"No students enrolled in {parts[1]}.");
                            else
                                foreach (var s in students) Console.WriteLine($"- {s.Id}");
                            break;

                        case "list_assignments":
                            if (parts.Length < 2) throw new ArgumentException("Usage: list_assignments [class]");
                            var assignments = repo.GetClassroom(parts[1]).Assignments.ToList();
                            if (!assignments.Any())
                                Logger.Warn($"No assignments scheduled in {parts[1]}.");
                            else
                                foreach (var a in assignments)
                                    Console.WriteLine($"- {a.Id}: {a.Description} (Submitted: {a.SubmittedBy.Count})");
                            break;

                        case "help":
                            Console.WriteLine(@"Commands:
 add_classroom [name]
 remove_classroom [name]
 add_student [id] [class]
 schedule_assignment [class] [id] [desc]
 submit_assignment [id] [class] [student]
 list_classrooms
 list_students [class]
 list_assignments [class]
 help
 exit");
                            break;

                        case "exit":
                            return;

                        default:
                            Logger.Warn("Unknown command. Type 'help'.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }
        }
    }
}
