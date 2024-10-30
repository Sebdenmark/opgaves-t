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

                    if (details.Length == 2 && details[0] == "Income")
                    {
                        monthlyIncome = double.Parse(details[1]);
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

                // Display results
                Console.WriteLine($"\nTotal Monthly Income: {monthlyIncome:C}");
                Console.WriteLine($"Total Expenses: {totalExpenses:C}");
                Console.WriteLine($"Remaining Balance After Expenses: {remainingBalance:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //here is a mothd that makes it posible to seach in the text from the month name and then display what you used that month 
        public static void ShowMonthlyIncomeAndBalance(string monthToShow)
        {
            double monthlyIncome = 0;
            double totalExpenses = 0;
            bool incomeFound = false;

            try
            {
                foreach (string line in File.ReadLines(path))
                {
                    string[] details = line.Split(',');

                    if (details.Length == 3 && details[0] == "Income" && details[1].Equals(monthToShow, StringComparison.OrdinalIgnoreCase))
                    {
                        monthlyIncome = double.Parse(details[2]);
                        incomeFound = true; 
                    }
                    else if (details.Length == 3 && details[0] == "Expense" && details[1].Equals(monthToShow, StringComparison.OrdinalIgnoreCase))
                    {
                        double expenseCost = double.Parse(details[2]);
                        totalExpenses += expenseCost;
                    }
                }

                if (incomeFound)
                {
                    double remainingBalance = monthlyIncome - totalExpenses;

                    Console.WriteLine($"\nMonth: {monthToShow}");
                    Console.WriteLine($"Monthly Income: {monthlyIncome:C}");
                    Console.WriteLine($"Total Expenses: {totalExpenses:C}");
                    Console.WriteLine($"Remaining Balance After Expenses: {remainingBalance:C}");
                }
                else
                {
                    Console.WriteLine($"No income record found for the month of {monthToShow}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static void ShowAllMonthsSummary()
        {
            Dictionary<string, double> monthlyIncomes = new Dictionary<string, double>();
            Dictionary<string, double> monthlyExpenses = new Dictionary<string, double>();

            try
            {
                foreach (string line in File.ReadLines(path))
                {
                    string[] details = line.Split(',');

                    if (details.Length == 3 && details[0] == "Income")
                    {
                        string month = details[1];
                        double income = double.Parse(details[2]);

                        if (monthlyIncomes.ContainsKey(month))
                        {
                            monthlyIncomes[month] += income;
                        }
                        else
                        {
                            monthlyIncomes[month] = income;
                        }
                    }

                    else if (details.Length == 3 && details[0] == "Expense")
                    {
                        string month = details[1];
                        double expense = double.Parse(details[2]);

                        if (monthlyExpenses.ContainsKey(month))
                        {
                            monthlyExpenses[month] += expense;
                        }
                        else
                        {
                            monthlyExpenses[month] = expense;
                        }
                    }
                }

                Console.WriteLine("Monthly Summary:");
                foreach (var month in monthlyIncomes.Keys)
                {
                    double income = monthlyIncomes[month];
                    double expenses = monthlyExpenses.ContainsKey(month) ? monthlyExpenses[month] : 0;
                    double remainingBalance = income - expenses;

                    Console.WriteLine($"\nMonth: {month}");
                    Console.WriteLine($"Monthly Income: {income:C}");
                    Console.WriteLine($"Total Expenses: {expenses:C}");
                    Console.WriteLine($"Remaining Balance After Expenses: {remainingBalance:C}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
