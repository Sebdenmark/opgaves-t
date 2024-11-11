using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dag_6_objek_øvelse_2
{
    public static class FileHandler
    {
        private static readonly string filePath = @"Files\Users.txt";

        // Validering af brugerinput
        public static void ValidateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            {
                throw new InvalidNameException("Navnet må ikke være tomt.", new ArgumentNullException("Navn er tomt"));
            }

            if ((user.Age < 18 && user.Age > 50) )
            {
                throw new InvalidAgeException("Alderen skal være mellem 18 og 50.", new ArgumentOutOfRangeException("Alder er uden for det tilladte interval"));
            }

            if (!Regex.IsMatch(user.Email, @"@.*\."))
            {
                throw new InvalidEmailException("E-mailen er ugyldig.", new FormatException("E-mail skal indeholde '@' og '.'"));
            }
        }

        // Opret filen, hvis den ikke eksisterer
        public static void EnsureFileExists()
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory("Files");
                File.Create(filePath).Dispose();
            }
        }

        // Skriv brugeren til filen
        public static void WriteUserToFile(User user)
        {
            try
            {
                EnsureFileExists();
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine($"{user.FirstName} {user.LastName}, {user.Age}, {user.Email}");
                }
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Kunne ikke skrive til filen.", ex);
            }
        }

        // Læs brugere fra filen
        public static void DisplayUsers()
        {
            try
            {
                EnsureFileExists();
                string[] lines = File.ReadAllLines(filePath);
                Console.WriteLine("Registrerede Brugere:");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Kunne ikke læse fra filen.", ex);
            }
        }
      }

    }
