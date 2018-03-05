using System;

namespace _04_Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine().Split();
            var webSites = Console.ReadLine().Split();
            var phone = new Smartphone();

            CallPhones(phoneNumbers, phone);

            BrowseWeb(webSites, phone);
        }

        private static void BrowseWeb(string[] webSites, Smartphone phone)
        {
            foreach (var site in webSites)
            {
                try
                {
                    Console.WriteLine(phone.Browse(site));
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void CallPhones(string[] phoneNumbers, Smartphone phone)
        {
            foreach (var number in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(phone.Call(number));
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
