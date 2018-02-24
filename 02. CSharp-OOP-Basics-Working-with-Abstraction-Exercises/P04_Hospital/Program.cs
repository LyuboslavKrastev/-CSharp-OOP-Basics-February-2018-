using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            var doctors = new Dictionary<string, List<string>>();
            var hospital = new Hospital();


            string command;

            while ((command = Console.ReadLine()) != "Output")
            {
                var tokens = command.Split();
                var departament = tokens[0];

                var patient = tokens[3];
                var fullName = $"{tokens[1]} {tokens[2]}";

                if (!doctors.ContainsKey(fullName))
                {
                    CreateNewDoctor(doctors, fullName);
                }

                if (!hospital.Departments.Any(d => d.Name == departament))
                {
                    hospital.CreateNewDepartment(departament);
                }
                var freeRoom = hospital.FindRoom(departament);
                if (freeRoom != null)
                {
                    AddPatientToDoctor(doctors, patient, fullName);
                    hospital.AddPatient(departament, freeRoom, patient);
                }
            }

            while ((command = Console.ReadLine()) != "End")
            {
                var args = command.Split();

                Print(doctors, hospital, args);
            }
        }     

        private static void Print(Dictionary<string, List<string>> doctors, Hospital hospital, string[] args)
        {
            if (args.Length == 1)
            {
                PrintToConsole(hospital.FindDepartmentPatients(args));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int roomNumber))
            {
                PrintToConsole(hospital.FindRoomPatients(args, roomNumber));
            }
            else
            {
                PrintDoctorPatients(doctors, args);
            }
        }

        private static void AddPatientToDoctor(Dictionary<string, List<string>> doctors, string patient, string fullName)
        {
            doctors[fullName].Add(patient);
        }

        private static void CreateNewDoctor(Dictionary<string, List<string>> doctors, string fullName)
        {
            doctors[fullName] = new List<string>();
        }

        private static void PrintDoctorPatients(Dictionary<string, List<string>> doctors, string[] args)
        {
            var fullName = $"{args[0]} {args[1]}";
            var patients = doctors.FirstOrDefault(d => d.Key == fullName).Value.OrderBy(x => x).ToArray();

            PrintToConsole(patients);
        }      

        private static void PrintToConsole(string[] patients)
        {
            Console.WriteLine(string.Join(Environment.NewLine, patients));
        }
    }
}
