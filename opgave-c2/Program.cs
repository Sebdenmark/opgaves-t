namespace opgave_c2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            //this task is made like c1 but with changes, we still uses the switch case, and get the things from our utils
            //but here we also use int and double, and our seach option also calculate the monthly pay before and after taxes
            //i was not sure if you wanted the name of the employ or the name of the work position so i chose to just use the employ name 
            while (continueProgram)
            {
                Console.WriteLine("\nEmploy portal");
                Console.WriteLine("Press 1 to add a employ");
                Console.WriteLine("Press 2 to see all of the employes");
                Console.WriteLine("Press 3 to seach for a person and calulater they monthly pay before and after tax");
                Console.WriteLine("Press 4 to delete a person from the system");

                Console.WriteLine("Press 0 to exit");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.WriteLine("\nEnter name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("enter workhouers:");
                        int arbejdstimer = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter hour pay:");
                        double timeløn = double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter your tax rate as a percentage so if it is 30% write 30:");
                        double skatteprocent = double.Parse(Console.ReadLine()) / 100;

                        utilsc2.SaveDataInworkTxt(name, arbejdstimer, timeløn,skatteprocent);
                        Console.WriteLine("Press Enter to return to menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case '2':
                        Console.WriteLine("\nContacts:");
                        List<string[]> contacts = utilsc2.RetrieveDataFromworkTxt();
                        foreach (var personContact in contacts)
                        {
                            Console.WriteLine($"Name: {personContact[0]}, Work Hours: {personContact[1]}, Hourly pay: {personContact[2]}, Tax Percentage: {personContact[3]}%");
                        }
                        Console.WriteLine("Press Enter to return to menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case '3':
                        Console.WriteLine("\nEnter the name of the contact to calculate monthly pay before and after taxes:");
                        string searchName = Console.ReadLine();
                        utilsc2.SearchAndCalculatePay(searchName);
                        Console.WriteLine("Press Enter to return to menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case '4':
                        Console.WriteLine("\nEnter the name of the employ you want to delete:");
                        string deleteName = Console.ReadLine();
                        utilsc2.DeleteContactc2(deleteName);
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
