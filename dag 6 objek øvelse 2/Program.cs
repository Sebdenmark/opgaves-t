namespace dag_6_objek_øvelse_2
{
    internal class Program
    {
        private static readonly string filePath = @"C:\Users\Sebastian Nielsen\Documents\GitHub\opgaves-t\dag 6 objek øvelse 2\file\Users.txt";

        static void Main(string[] args)
        {
            List<User> users = LoadUsersFromFile(); // Indlæs brugere fra filen ved programstart
            Console.WriteLine("Eksisterende registrerede brugere:");
            DisplayUserList(users);

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

                    // Validering af brugeroplysninger
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

                    // Tilføj bruger til liste og skriv til fil
                    users.Add(user);

                    try
                    {
                        FileHandler.WriteUserToFile(user);
                        Console.WriteLine("Bruger registreret med succes!");
                    }
                    catch (FileLoadException ex)
                    {
                        Console.WriteLine($"Filfejl: {ex.Message}. Inner exception: {ex.InnerException?.Message}");
                    }

                    // Sorter listen
                    users.Sort();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input-fejl: Sørg for, at alder er et gyldigt tal.");
                }
                finally
                {
                    Console.WriteLine("Registrerede Brugere:");
                    foreach (User user in users)
                    {
                        Console.WriteLine($"Name: {user.FirstName},Lastname: {user.LastName}, Age: {user.Age}, Email: {user.Email}");
                    }
                    Console.WriteLine("Tryk på Enter for at starte en ny registrering.");
                    Console.ReadLine();
                }
            }
        }

        public static List<User> LoadUsersFromFile()
        {
            List<User> users = new List<User>();
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Filen blev ikke fundet. Sørg for, at stien er korrekt.");
                    return users; // Returnerer en tom liste, hvis filen ikke findes
                }

                string[] lines = File.ReadAllLines(filePath);
                

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',',' ');
                    if (parts.Length == 4) // Tjekker, om linjen har præcis 4 værdier
                    {
                        try
                        {
                            User user = new User
                            {
                                FirstName = parts[0].Trim(),
                                LastName = parts[1].Trim(),
                                Age = int.Parse(parts[2].Trim()),
                                Email = parts[3].Trim()
                            };
                            users.Add(user);
                        }
                        catch (FormatException fe)
                        {
                            Console.WriteLine($"Format fejl på linje: '{line}'. Kunne ikke konvertere alder. {fe.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($": '{line}'.");
                    }
                }
                Console.WriteLine($"Antal brugere tilføjet fra fil: {users.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl ved indlæsning af filen: {ex.Message}");
            }
            return users;
        }
    
        public static void DisplayUserList(List<User> users)
        {
            Console.WriteLine("\nRegistrerede Brugere:");
            foreach (User user in users)
            {
                Console.WriteLine($"Name: {user.FirstName},Lastname: {user.LastName}, Age: {user.Age}, Email: {user.Email}");
            }
        }
    }
}