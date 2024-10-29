using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgave_c2
{
    internal class utilsc2
    {
        // Define the file path, this is my file path so you will have to put in your own file path, for you txtfile 
        private static string path = @"C:\Users\Sebastian Nielsen\Documents\GitHub\opgaves-t\opgave-c2\virksomhedoplysninger.txt";
        // Method to insert data into the text file
        public static void SaveDataInworkTxt(string name, int arbejdstimer, double timeløn, double skatteprocent)
        {
            string formattedData = $"{name},{arbejdstimer},{timeløn},{skatteprocent * 100}%";
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
                Console.WriteLine("Data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //method to retrive the data from the file and display it 
        public static List<string[]> RetrieveDataFromworkTxt()
        {
            List<string[]> contacts = new List<string[]>();
            try
            {
                foreach (string line in File.ReadLines(path))
                {
                    string[] details = line.Split(',');
                    if (details.Length == 4)
                    {
                        details[3] = details[3].Replace("%", "").Trim();
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

        //method where you can seach for the person that you want to see the monthly pay of, and it calluclate it before and after taxes 
        public static void SearchAndCalculatePay(string nameToSearch)
        {
            try
            {
                foreach (string line in File.ReadLines(path))
                {
                    string[] details = line.Split(',');
                    if (details.Length == 4 && details[0].Equals(nameToSearch, StringComparison.OrdinalIgnoreCase))
                    {
                        string name = details[0];
                        int arbejdstimer = int.Parse(details[1]); 
                        double timeløn = double.Parse(details[2]); 
                        double skatteprocent = double.Parse(details[3].Replace("%", "")) / 100; 
                        double monthlyPayBeforeTax = arbejdstimer * timeløn * 4; //this is formel is made with the 4 week month but you can change it, you could also make it dynamik so that, you have another method that calulate how many days there is in a month, and what month we are in. ore use a libay that can find the correct month and how many weeks in it. 
                        double monthlyPayAfterTax = monthlyPayBeforeTax * (1 - skatteprocent);

                        Console.WriteLine($"Name: {name}");
                        Console.WriteLine($"Monthly Pay Before Tax: {monthlyPayBeforeTax:C}");
                        Console.WriteLine($"Monthly Pay After Tax: {monthlyPayAfterTax:C}");
                        return;
                    }
                }

                Console.WriteLine("Contact not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //this is the delete employ method, it is almost the same as in the task c1, the only relly diffrense is that it now checks for 4 line insted of 3. 
        public static void DeleteContactc2(string nameToDelete)
        {
            List<string> lines = new List<string>();
            try
            {
                lines.AddRange(File.ReadAllLines(path));
                int indexToRemove = -1;
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] details = lines[i].Split(',');

                    if (details.Length == 4 && details[0].Equals(nameToDelete, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Are you sure you want to delete this contact?");
                        Console.WriteLine($"Name: {details[0]}, Work Hours: {details[1]}, Hourly Wage: {details[2]}, Tax Percentage: {details[3]}% (y/n)");
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
