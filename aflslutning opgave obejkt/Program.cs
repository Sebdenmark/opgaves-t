namespace aflslutning_opgave_obejkt
{
    internal class Program
    {
        private static List<Lærer> lærere = new List<Lærer>();
        private static List<Elev> elever = new List<Elev>();
        private static List<Fag> fag = new List<Fag>();

        static void Main(string[] args)
        {
            // Kald DataInitializer for at initialisere data
            DataInitializer.InitData(lærere, elever, fag);

            while (true)
            {
                Console.WriteLine("Vælg søgekriterie: ");
                Console.WriteLine("1: Lærer");
                Console.WriteLine("2: Elev");
                Console.WriteLine("3: Fag");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Ingen match fundet.");
                    continue;
                }
                switch ((Søgekriterier)(choice - 1))
                {
                    case Søgekriterier.Lærer:
                        SøgLærer();
                        break;
                    case Søgekriterier.Elev:
                        SøgElev();
                        break;
                    case Søgekriterier.Fag:
                        SøgFag();
                        break;
                    default:
                        Console.WriteLine("Ingen match fundet.");
                        break;
                }
            }
        }

        

        static void SøgLærer()
        {
            Console.WriteLine("Indtast Lærer ID:");
            foreach (var lærer in lærere)
                Console.WriteLine($"{lærere.IndexOf(lærer) + 1}: {lærer.GetFullName()}");

            if (int.TryParse(Console.ReadLine(), out int id) && id > 0 && id <= lærere.Count)
            {
                var lærer = lærere[id - 1];
                Console.WriteLine($"{lærer.GetFullName()} underviser i:");
                foreach (var fag in lærer.Fag)
                {
                    Console.WriteLine($"- {fag.Navn} ({fag.Elever.Count} elever)");
                    foreach (var elev in fag.Elever)
                    {
                        var farve = elev.Alder < 20 ? ConsoleColor.Red : ConsoleColor.Gray;
                        Console.ForegroundColor = farve;
                        Console.WriteLine($"  - {elev.GetFullName()} (Alder: {elev.Alder})");
                        Console.ResetColor();
                    }
                }
            }
            else Console.WriteLine("Ingen match fundet.");
        }

        static void SøgElev()
        {
            Console.WriteLine("Indtast elevens fulde navn:");
            string navn = Console.ReadLine();
            var elev = elever.FirstOrDefault(e => e.GetFullName().Equals(navn, StringComparison.OrdinalIgnoreCase));
            if (elev != null)
            {
                Console.WriteLine($"{elev.GetFullName()} deltager i:");
                foreach (var fag in elev.Fag)
                    Console.WriteLine($"- {fag.Navn} (Lærer: {fag.Lærer.GetFullName()})");
            }
            else Console.WriteLine("Ingen match fundet.");
        }

        static void SøgFag()
        {
            Console.WriteLine("Indtast Fag ID:");
            foreach (var f in fag)
                Console.WriteLine($"{fag.IndexOf(f) + 1}: {f.Navn}");

            if (int.TryParse(Console.ReadLine(), out int id) && id > 0 && id <= fag.Count)
            {
                var valgtFag = fag[id - 1];
                Console.WriteLine($"Fag: {valgtFag.Navn} (Lærer: {valgtFag.Lærer.GetFullName()})");
                Console.WriteLine($"Antal elever: {valgtFag.Elever.Count}");
                foreach (var elev in valgtFag.Elever)
                {
                    var farve = elev.Alder < 20 ? ConsoleColor.Red : ConsoleColor.Gray;
                    Console.ForegroundColor = farve;
                    Console.WriteLine($"- {elev.GetFullName()} (Alder: {elev.Alder})");
                    Console.ResetColor();
                }
            }
            else Console.WriteLine("Ingen match fundet.");
        }
    }
}
