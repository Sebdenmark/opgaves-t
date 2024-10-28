using System;
using System.Collections.Generic;

namespace opavers28_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("\nTelefonbog");
                Console.WriteLine("Press 1 to add a person");
                Console.WriteLine("Press 2 to view contacts");
                Console.WriteLine("Press 0 to exit");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.WriteLine("\nEnter name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter email:");
                        string email = Console.ReadLine();
                        while (!email.Contains("@"))
                        {
                            Console.WriteLine("Invalid email. Please enter a valid email with '@':");
                            email = Console.ReadLine();
                        }

                        Console.WriteLine("Enter phone number:");
                        string phoneNumber = Console.ReadLine();

                        Utils.SaveDataInTxt(name, email, phoneNumber);
                        break;

                    case '2':
                        Console.WriteLine("\nContacts:");
                        List<string[]> contacts = Utils.RetrieveDataFromTxt();
                        foreach (var contact in contacts)
                        {
                            Console.WriteLine($"Name: {contact[0]}, Email: {contact[1]}, Phone: {contact[2]}");
                        }
                        Console.WriteLine("Press Enter to return to menu.");
                        Console.ReadLine();
                        break;

                    case '0':
                        continueProgram = false;
                        Console.WriteLine("Exiting program.");
                        break;

                    default:
                        Console.WriteLine("\nInvalid option. Please try again.");
                        break;
                }
            }
        }
    }
}