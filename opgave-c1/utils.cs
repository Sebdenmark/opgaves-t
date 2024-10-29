using System;
using System.Collections.Generic;
using System.IO;

namespace opavers28_10
{
    internal class Utils
    {
        // Define the file path, this is my file path so you will have to put in your own file path, for you txtfile 
        private static string path = @"C:\Users\Sebastian Nielsen\Documents\GitHub\opgaves-t\opavers28-10\liste.txt";
        // Method to insert data into the text file
        public static void SaveDataInTxt(string name, string email, string phoneNumber)
        {
            string formattedData = $"{name},{email},{phoneNumber}";

            try
            {
                if (File.Exists(path) && new FileInfo(path).Length > 0)
                {
                    File.AppendAllText(path, Environment.NewLine + formattedData);
                }
                else
                {
                    File.AppendAllText(path, formattedData);
                }

                Console.WriteLine("Contact saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        // Method to retrieve data from the text file
        public static List<string[]> RetrieveDataFromTxt()
        {
            List<string[]> contacts = new List<string[]>();
            try
            {
                foreach (string line in File.ReadLines(path))
                {
                    string[] details = line.Split(',');

                    if (details.Length == 3)
                    {
                        contacts.Add(details);
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry in file: " + line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return contacts;

        }
        //here is the seach where it check if there is someone with that name and return the line.
        public static string[] SearchContact(string nameToSearch)
        {
            try
            {
                foreach (string line in File.ReadLines(path))
                {
                    string[] details = line.Split(',');
                    if (details.Length == 3 && details[0].Equals(nameToSearch, StringComparison.OrdinalIgnoreCase))
                    {
                        return details; 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null; 
        }
        //method for deleting contact 
        public static void DeleteContact(string nameToDelete)
        {
            List<string> lines = new List<string>();
            try
            {
                lines.AddRange(File.ReadAllLines(path));
                // Find the line that contains the contact with a name 
                int indexToRemove = -1;
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] details = lines[i].Split(',');
                    if (details.Length == 3 && details[0].Equals(nameToDelete, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Are you sure you want to delete this contact? Name: {details[0]}, Email: {details[1]}, Phone: {details[2]} (y/n)");
                        if (Console.ReadKey().KeyChar == 'y')
                        {
                            indexToRemove = i;
                        }
                        Console.WriteLine();
                        break;
                    }
                }

                if (indexToRemove >= 0)
                {
                    lines.RemoveAt(indexToRemove);
                    File.WriteAllLines(path, lines);
                    Console.WriteLine("Contact deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Contact not found or deletion canceled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}