using System;
using System.Linq;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var draftManager = new DraftManager();
            while ((input = Console.ReadLine()) != "Shutdown")
            {
                var tokens = input.Split();
                var command = tokens[0];
                var arguments = tokens.Skip(1).ToList();
                try
                {
                    switch (command)
                    {
                        case "RegisterHarvester":
                            Console.WriteLine(draftManager.RegisterHarvester(arguments));
                            break;
                        case "RegisterProvider":
                            Console.WriteLine(draftManager.RegisterProvider(arguments));
                            break;
                        case "Day":
                            Console.WriteLine(draftManager.Day());
                            break;
                        case "Mode":
                            Console.WriteLine(draftManager.Mode(arguments));
                            break;
                        case "Check":
                            Console.WriteLine(draftManager.Check(arguments));
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
             
            }
            Console.WriteLine(draftManager.ShutDown());
        }
    }
}
