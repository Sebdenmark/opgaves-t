using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgave_c3
{
    internal class utilsc3
    {
        // Define the file path, this is my file path so you will have to put in your own file path, for you txtfile 
        private static string path = @"C:\Users\Sebastian Nielsen\Documents\GitHub\opgaves-t\opgave-c3\budget.txt";
        //the first method to save the income data, the reson i have split it up is so that when you but in income it will calculate from that, and the you can but a ne incom in and it wil calulate from that and only the things add after that
        public static void SaveIncomeInTxt(string month, double income)
        {
            string formattedData = $"Income,{month},{income}";

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

                Console.WriteLine("Income saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        //second method to save data in the txt, here you save the numbers we are going to use later for the formel 
        public static void SaveExpenseInTxt(string expenseName, double expenseCost)
        {
            string formattedData = $"Expense,{expenseName},{expenseCost}";

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

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //in this method we caluclate how much the spend on expenses and how much is left. it also save it so it only uses the expenses add after the monthly income will be used to callculate
        // that can also give a proble becouse if you add the expenses first it will not work.
        public static void CalculateExpensesAndBalance()
        {
            double totalExpenses = 0;
            double monthlyIncome = 0;
            int lastIncomeIndex = -1;
            List<string> lines = new List<string>();

            try
            {
                lines.AddRange(File.ReadAllLines(path));

                for (int i = 0; i < lines.Count; i++)
                {
                    string[] details = lines[i].Split(',');

                    if (details.Length == 3 && details[0] == "Income")
                    {
                        monthlyIncome = double.Parse(details[2]);  
                        lastIncomeIndex = i;  
                    }
                }

                for (int i = lastIncomeIndex + 1; i < lines.Count; i++)
                {
                    string[] details = lines[i].Split(',');

                    if (details.Length == 3 && details[0] == "Expense")
                    {
                        double expenseCost = double.Parse(details[2]);
                        totalExpenses += expenseCost;
                    }
                }

                double remainingBalance = monthlyIncome - totalExpenses;

                Console.WriteLine($"\nTotal Monthly Income: {monthlyIncome:C}");
                Console.WriteLine($"Total Expenses: {totalExpenses:C}");
                Console.WriteLine($"Remaining Balance After Expenses: {remainingBalance:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        //in this method i use the same logic as in CalculateExpensesAndBalance the resoan i do this is to make an easy way to retrive all of the data from the txt and caluclate the things again an show all data together, with out saving more things in the txt. so now it just take the income and all the expenses after that and calculate that. and then start a new calculation when a new income 
        public static void ShowAllMonthsSummary()
        {
            double monthlyIncome = 0;
            double totalExpenses = 0;
            string currentMonth = "";
            bool incomeFound = false;

            try
            {
                foreach (string line in File.ReadLines(path))
                {
                    string[] details = line.Split(',');

                    if (details.Length == 3 && details[0] == "Income")
                    {
                        if (incomeFound)
                        {
                            double remainingBalance = monthlyIncome - totalExpenses;
                            Console.WriteLine($"\nMonth: {currentMonth}");
                            Console.WriteLine($"Monthly Income: {monthlyIncome:C}");
                            Console.WriteLine($"Total Expenses: {totalExpenses:C}");
                            Console.WriteLine($"Remaining Balance After Expenses: {remainingBalance:C}");
                            Console.WriteLine("-------------------------------------------------------");


                            totalExpenses = 0;
                        }

                        currentMonth = details[1];
                        monthlyIncome = double.Parse(details[2]);
                        incomeFound = true;
                    }
                    else if (details.Length == 3 && details[0] == "Expense")
                    {
                        double expenseCost = double.Parse(details[2]);
                        totalExpenses += expenseCost;
                    }
                }

                if (incomeFound)
                {
                    double remainingBalance = monthlyIncome - totalExpenses;
                    Console.WriteLine($"\nMonth: {currentMonth}");
                    Console.WriteLine($"Monthly Income: {monthlyIncome:C}");
                    Console.WriteLine($"Total Expenses: {totalExpenses:C}");
                    Console.WriteLine($"Remaining Balance After Expenses: {remainingBalance:C}");
                    Console.WriteLine("-------------------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
