namespace opgave_c3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("\nBudget helper");
                Console.WriteLine("Press 1 Enter your monthly income");
                Console.WriteLine("Press 2 Enter expenses");
                Console.WriteLine("Press 3 to se how much you used this month on expenses and how much you have left");
                Console.WriteLine("Press 4 to see all of the months");
                Console.WriteLine("Press 0 to exit");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.WriteLine("\nEnter the month for this income (e.g., January):");
                        string month = Console.ReadLine();
                        Console.WriteLine("Enter your monthly income:");
                        double income = double.Parse(Console.ReadLine());
                        utilsc3.SaveIncomeInTxt(month, income);
                        Console.WriteLine("Press Enter to return to menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case '2':
                        Console.WriteLine("\nEnter the name of the expense:");
                        string expenseName = Console.ReadLine();

                        Console.WriteLine("Enter the monthly cost of the expense:");
                        double expenseCost = double.Parse(Console.ReadLine());

                        utilsc3.SaveExpenseInTxt(expenseName, expenseCost);
                        Console.WriteLine("Expense saved. Press Enter to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case '3':
                        utilsc3.CalculateExpensesAndBalance();
                        Console.WriteLine("Press Enter to return to menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case '4':
                        utilsc3.ShowAllMonthsSummary();
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
