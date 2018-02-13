using System;
using System.Collections.Generic;

namespace Problem_3._Test_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var accounts = new Dictionary<int, BankAccount>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var cmdArgs = command.Split();
                var cmdType = cmdArgs[0];

                switch (cmdType)
                {
                    case "Create":
                        Create(cmdArgs, accounts);
                        break;
                    case "Deposit":
                        Deposit(cmdArgs, accounts);
                        break;
                    case "Withdraw":
                        Withdraw(cmdArgs, accounts);
                        break;
                    case "Print":
                        Print(cmdArgs, accounts);
                        break;
                }
            }
        }
        private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount();
                acc.Id = id;
                accounts.Add(id, acc);
            }
        }
        private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            var amount = decimal.Parse(cmdArgs[2]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                accounts[id].Deposit(amount);
            }
        }
        private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            var amount = decimal.Parse(cmdArgs[2]);
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                if (accounts[id].Balance >= amount)
                {
                    accounts[id].Withdraw(amount);
                }
                else
                {
                    Console.WriteLine("Insufficient balance");
                }
                
            }
        }
        private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                Console.WriteLine(accounts[id]);
            }
        }
    }
}
