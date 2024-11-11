using College_EFCore_Linq_Task.Models;
using College_EFCore_Linq_Task.Repositories;
using System.Text.RegularExpressions;

namespace College_EFCore_Linq_Task
{
    internal class Program
    {
        static string pattern = @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$";
        static void Main(string[] args)
        {
            using var dbContext = new ApplicationDbContext();
            var courseRepo = new CourseRepository(dbContext);
            var deptRepo = new DepartmentRepository(dbContext);
            var examRepo = new ExamRepository(dbContext);
            var facultyRepo = new FacultyRepository(dbContext);
            var hostelRepo = new HostelRepository(dbContext);
            var studentRepo = new StudentRepository(dbContext);
            var subjectRepo = new SubjectRepository(dbContext);
        }

        static void DisplayAllStudents(StudentRepository repository)
        {
            try
            {
                int count = 1;
                var students = repository.GetAllStudents();
                Console.WriteLine("\nStudents:\n");
                foreach (var student in students)
                {
                    Console.WriteLine($"{count}. Name: {student.FName + " " + student.LName} " +
                        $"| Hostel: {student.Hostel.Hostel_Name}" +
                        $"| Teacher: {student.Teacher.FacultyName}");

                    Console.WriteLine("\n Courses: ");
                    foreach (var c in student.StudentCourses)
                    {
                        Console.Write($"{c.Course.CourseName}, ");
                    }

                    Console.WriteLine("\n Exams: ");
                    foreach (var c in student.StudentCourses)
                    {
                        foreach (var e in c.Course.Department.Exams)
                        {
                            Console.Write($"Code: {e.Exam_Code}|Date: {e.Date}, ");
                        }
                    }
                    count++;
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine ("Could not display students... " + ex.Message);
            }
        }

        static void DisplayStudentById(StudentRepository repository)
        {
            Console.WriteLine("Enter the student ID: ");
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1)
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please try again.\n");
                Console.WriteLine("Enter the student ID: ");
            }
            try
            {
                var student = repository.GetStudentById(input);
                Console.Clear();
                Console.WriteLine($"Name: {student.FName + " " + student.LName} " +
                    $"| Hostel: {student.Hostel.Hostel_Name}");
                if (student.StudentCourses != null)
                {
                    Console.WriteLine("\n Courses: ");
                    foreach (var c in student.StudentCourses)
                    {
                        Console.Write($"{c.Course.CourseName}, ");
                    }

                    Console.WriteLine("\n Exams: ");
                    foreach (var c in student.StudentCourses)
                    {
                        foreach (var e in c.Course.Department.Exams)
                        {
                            Console.Write($"Code: {e.Exam_Code}|Date: {e.Date}, ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not display student info... "+ex.Message);
            }
        }

        static void AddNewStudent(StudentRepository repository)
        {
            Console.Write("Enter the first name: ");
            string fname;
            while(string.IsNullOrEmpty(fname = Console.ReadLine()))
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please try again.");
                Console.Write("\nEnter the first name: ");
            }
            Console.Write("\nEnter the last name: ");
            string lname;
            while (string.IsNullOrEmpty(lname = Console.ReadLine()))
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please try again.");
                Console.Write("\nEnter the last name: ");
            }

            Console.Write("\nEnter the city: ");
            var city = Console.ReadLine();

            Console.Write("\nEnter the state: ");
            var state = Console.ReadLine();

            Console.Write("\nEnter the pin code: ");
            var pinCode = Console.ReadLine();

            Console.Write("\nEnter the date of birth e.g (01/01/2000): ");
            string dob;
            while(string.IsNullOrEmpty(dob = Console.ReadLine()) || Regex.IsMatch(pattern, dob))
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please try again.");
                Console.Write("\nEnter the date of birth e.g (01/01/2000): ");
            }
            DateTime birthDate;
            DateTime.TryParse(dob, out birthDate);

            Console.Write("\nEnter the hostel ID: ");
            int HID;
            while (!int.TryParse(Console.ReadLine(), out HID) || HID < 1)
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please try again.");
                Console.Write("\nEnter the hostel ID: ");
            }

            Console.Write("\nEnter the ID of the student's advisor: ");
            int fid;
            while(!int.TryParse(Console.ReadLine(), out fid) || fid < 1)
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please try again.");
                Console.Write("\nEnter the ID of the student's advisor: ");
            }
            try
            {
                var student = new Student
                {
                    FName = fname,
                    LName = lname,
                    City = city,
                    State = state,
                    Pin_code = pinCode,
                    DOB = birthDate,
                    Hostel_Id = HID,
                    FID = fid,
                };

                repository.AddStudent(student);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could no add student... "+ex);
            }
        }
    }
}
