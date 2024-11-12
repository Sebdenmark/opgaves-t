namespace dag_6_objek_øvelse_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                List<User> users = new List<User>();

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Indtast brugerens fornavn:");
                        string firstName = Console.ReadLine();

                        Console.WriteLine("Indtast brugerens efternavn:");
                        string lastName = Console.ReadLine();

                        Console.WriteLine("Indtast brugerens alder:");
                        int age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Indtast brugerens e-mail:");
                        string email = Console.ReadLine();

                        // Opret User-objekt
                        User user = new User
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Age = age,
                            Email = email
                        };

                        // Anden del: Validering af brugeroplysninger
                        try
                        {
                            FileHandler.ValidateUser(user);
                        }
                        catch (InvalidNameException ex)
                        {
                            Console.WriteLine($"Navnefejl: {ex.Message}. Inner exception: {ex.InnerException?.Message}");
                            continue; 
                        }
                        catch (InvalidAgeException ex) when (firstName != "Niels" && lastName != "Olsen")
                        {
                            Console.WriteLine($"Alderfejl: {ex.Message}. Inner exception: {ex.InnerException?.Message}");
                            continue;
                        }
                        catch (InvalidEmailException ex)
                        {
                            Console.WriteLine($"E-mail fejl: {ex.Message}. Inner exception: {ex.InnerException?.Message}");
                            continue;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.ToString()}");
                        }

                        // Tilføj bruger til liste, skriv til fil og vis registrerede brugere
                        users.Add(user); 

                        try
                        {
                            FileHandler.WriteUserToFile(user);
                            Console.WriteLine("Bruger registreret med succes!");
                            FileHandler.DisplayUsers(); 
                        }
                        catch (FileLoadException ex)
                        {
                            Console.WriteLine($"Filfejl: {ex.Message}. Inner exception: {ex.InnerException?.Message}");
                        }

                        // Sorter og vis alle brugere i listen
                        users.Sort();
                        FileHandler.DisplayUserlist(users);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Input-fejl: Sørg for, at alder er et gyldigt tal.");
                    }
                    finally
                    {
                        Console.WriteLine("Programmet afsluttes korrekt.");
                        Console.WriteLine("Tryk på Enter for at starte en ny registrering.");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
