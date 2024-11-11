namespace dag_6_objek_øvelse_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string fullname = "";

                // Første del: Indhent brugerens input
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

                    // Anden del: Validering af brugeroplysninger i separat try-catch
                    try
                    {
                        FileHandler.ValidateUser(user);
                    }
                    catch (InvalidNameException ex)
                    {
                        Console.WriteLine($"Navnefejl: {ex.Message}. Inner exception: {ex.InnerException?.Message}");
                        continue; // Spring til næste iteration af while-loopet
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

                    // Tredje del: Skriv bruger til fil og vis registrerede brugere
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
