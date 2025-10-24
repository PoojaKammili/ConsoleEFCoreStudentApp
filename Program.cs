using System;

namespace ConsoleApp_With_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService service = new StudentService();

            while (true)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Choose an option 1 - 6");
                Console.WriteLine("1 - Add Student Details");
                Console.WriteLine("2 - Display All Students");
                Console.WriteLine("3 - Display Student by ID");
                Console.WriteLine("4 - Display Student by Name");
                Console.WriteLine("5 - Update Student Details");
                Console.WriteLine("6 - Delete Student");
                Console.WriteLine("7 - Exit");
                Console.WriteLine("----------------------------------");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            //create
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine().Trim();
                            Console.Write("Enter Age: ");
                            int age = int.Parse(Console.ReadLine());
                            Console.Write("Enter Grade: ");
                            string grade = Console.ReadLine().Trim();
                            var student = new Student(name, age, grade);
                            service.AddStudent(student);
                            Console.WriteLine("Student added successfully!");
                            break;

                        case 2:
                            //getallstudents
                            var allStudents = service.GetAllStudents();
                            if (allStudents.Count == 0)
                                Console.WriteLine("No students found!");
                            else
                                foreach (var s in allStudents)
                                    service.Display(s);
                            break;

                        case 3:
                            //getbyid
                            Console.Write("Enter Student ID: ");
                            int id = int.Parse(Console.ReadLine());
                            var studentById = service.GetStudentById(id);
                            if (studentById != null)
                                service.Display(studentById);
                            else
                                Console.WriteLine("Student not found!");
                            break;
                        case 4:
                            //getbyname
                            Console.Write("Enter Name: ");
                            string search_name = Console.ReadLine().Trim();
                            var students = service.GetStudentsByName(search_name);

                            if (students.Count == 0)
                            {
                                Console.WriteLine("No student found with that name.");
                            }
                            else
                            {
                                foreach (var matchingStudents in students)
                                {
                                    service.Display(matchingStudents);
                                }
                            }
                            break;
                        case 5:
                            Console.Write("Enter Student ID to update: ");
                            int updateId = int.Parse(Console.ReadLine());
                            var studentToUpdate = service.GetStudentById(updateId);
                            if (studentToUpdate != null)
                            {
                                Console.WriteLine("What do you want to update?");
                                Console.WriteLine("1. Name");
                                Console.WriteLine("2. Age");
                                Console.WriteLine("3. Grade");
                                Console.Write("Choice: ");
                                int choice = int.Parse(Console.ReadLine());

                                switch (choice)
                                {
                                    case 1:
                                        Console.Write("Enter new Name: ");
                                        studentToUpdate.Name = Console.ReadLine().Trim();
                                        break;
                                    case 2:
                                        Console.Write("Enter new Age: ");
                                        studentToUpdate.Age = int.Parse(Console.ReadLine());
                                        break;
                                    case 3:
                                        Console.Write("Enter new Grade: ");
                                        studentToUpdate.Grade = Console.ReadLine().Trim();
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice!");
                                        continue;
                                }

                                service.UpdateStudent(studentToUpdate);
                                Console.WriteLine("Student updated successfully!");
                            }
                            else
                                Console.WriteLine("Student not found!");
                            break;

                        case 6:
                            Console.Write("Enter Student ID to delete: ");
                            int deleteId = int.Parse(Console.ReadLine());
                            var studentToDelete = service.GetStudentById(deleteId);
                            if (studentToDelete != null)
                            {
                                service.DeleteStudent(deleteId);
                                Console.WriteLine("Student deleted successfully!");
                            }
                            else
                                Console.WriteLine("Student not found!");
                            break;

                        case 7:
                            Console.WriteLine("Exited from the application.");
                            return;

                        default:
                            Console.WriteLine("Wrong option! Choose 1-6.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Enter a number 1-6.");
                }
            }
        }
    }
}
