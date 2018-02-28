using System;

namespace _03_Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = GetStudentInput();

                Worker worker = GetWorkerInput();

                PrintResult(student, worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static void PrintResult(Student student, Worker worker)
        {
            Console.WriteLine(student);
            Console.WriteLine(worker);
        }

        private static Worker GetWorkerInput()
        {
            var workerInput = Console.ReadLine().Split();
            var workerFirstName = workerInput[0];
            var workerLastName = workerInput[1];
            var salary = decimal.Parse(workerInput[2]);
            var workingHours = decimal.Parse(workerInput[3]);

            var worker = new Worker(workerFirstName, workerLastName, salary, workingHours);
            return worker;
        }

        private static Student GetStudentInput()
        {
            var studentInput = Console.ReadLine().Split();
            var studentFirstName = studentInput[0];
            var studentLastName = studentInput[1];
            var facultyNumber = studentInput[2];

            var student = new Student(studentFirstName, studentLastName, facultyNumber);
            return student;
        }
    }
}
