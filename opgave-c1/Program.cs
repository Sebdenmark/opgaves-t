using System;
using System.Collections.Generic;

namespace opavers28_10
{
    internal class Program
    {
        //here is the main where there a made a switch case so that the use have a menue to chose what the user want to use.
        //it is inside a while loop so you have the option to go back to the menue and the program does not close when you finsih one of the options
        // each options is not definde in the main but in utils, and the it is made as a mehod in utils so that you can call it in the main
        static void Main(string[] args)
        {
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("\nTelefonbog");
                Console.WriteLine("Press 1 to add a person");
                Console.WriteLine("Press 2 to view contacts");
                Console.WriteLine("Press 3 to search for a contact");
                Console.WriteLine("Press 4 to delete contact");
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
                        Console.WriteLine("Press Enter to return to menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case '2':
                        Console.WriteLine("\nContacts:");
                        List<string[]> contacts = Utils.RetrieveDataFromTxt();
                        foreach (var personContact in contacts)
                        {
                            Console.WriteLine($"Name: {personContact[0]}, Email: {personContact[1]}, Phone: {personContact[2]}");
                        }
                        Console.WriteLine("Press Enter to return to menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case '3':
                        Console.WriteLine("\nEnter the name to search:");
                        string searchName = Console.ReadLine();
                        string[] foundContact = Utils.SearchContact(searchName);

                        if (foundContact != null)
                        {
                            Console.WriteLine($"Name: {foundContact[0]}, Email: {foundContact[1]}, Phone: {foundContact[2]}");
                        }
                        else
                        {
                            Console.WriteLine("Contact not found.");
                        }
                        Console.WriteLine("Press Enter to return to menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case '4':
                        Console.WriteLine("\nEnter the name of the contact you want to delete:");
                        string deleteName = Console.ReadLine();
                        Utils.DeleteContact(deleteName);
                        Console.WriteLine("Press Enter to return to menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case '0':
                        continueProgram = false;
                        Console.WriteLine("Exiting program.");
                        break;

                    default:
                        Console.WriteLine("\nInvalid option. Please try again.");
                        Console.WriteLine("Press Enter to return to menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}