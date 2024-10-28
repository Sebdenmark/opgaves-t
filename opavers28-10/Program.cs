using System;
using System.Collections.Generic;

namespace opavers28_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Switch case as a menu so that you can choose what you want to do. 
            Console.WriteLine("Telefonbog \nPress 1 to add a person, Press 2 to view contacts");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.WriteLine("\nEnter name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter email:");
                    string email = Console.ReadLine();
                    while (!email.Contains("@"))
                    {
                        Console.WriteLine("Invalid email");
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
                        Console.ReadLine();
                    }
                    break;

                default:
                    Console.WriteLine("\nInvalid option.");
                    break;
            }
        }
    }
}