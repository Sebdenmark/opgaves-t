using System;
using System.Collections.Generic;
using System.IO;

namespace opavers28_10
{
    internal class Utils
    {
        // Define the file path
        private static string path = @"C:\Users\Sebastian Nielsen\Documents\GitHub\opgaves-t\opavers28-10\liste.txt";

        // Method to insert data into the text file
        public static void SaveDataInTxt(string name, string email, string phoneNumber)
        {
            string formattedData = $"{name},{email},{phoneNumber}";
            try
            {
                File.AppendAllText(path, formattedData + Environment.NewLine);
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
    }
}