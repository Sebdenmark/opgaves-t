using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aflslutning_opgave_obejkt
{
    public static class DataInitializer
    {
        public static void InitData(List<Lærer> lærere, List<Elev> elever, List<Fag> fag)
        {
            var niels = new Lærer { Fornavn = "Niels", Efternavn = "Olesen", Fag = new List<Fag>() };
            var michael = new Lærer { Fornavn = "Michael", Efternavn = "Gilbert Hansen", Fag = new List<Fag>() };
            var nikolaj = new Lærer { Fornavn = "Nikolaj", Efternavn = "Bo Fredsoe", Fag = new List<Fag>() };
            var henrik = new Lærer { Fornavn = "Henrik", Efternavn = "V. Paulsen", Fag = new List<Fag>() };
            lærere.AddRange(new[] { niels, michael, nikolaj, henrik });

            // Initialisering af elever med deres alder og tomme faglister
            var elev1 = new Elev { Fornavn = "Andreas", Efternavn = "Lorenzen", Alder = 20, Fag = new List<Fag>() };
            var elev2 = new Elev { Fornavn = "Azad", Efternavn = "Akdeniz", Alder = 30, Fag = new List<Fag>() };
            var elev3 = new Elev { Fornavn = "Bertram", Efternavn = "Estrup Axen", Alder = 17, Fag = new List<Fag>() };
            var elev4 = new Elev { Fornavn = "Casper", Efternavn = "Clemmensen", Alder = 26, Fag = new List<Fag>() };
            var elev5 = new Elev { Fornavn = "Daniel", Efternavn = "Bjerre Jensen", Alder = 22, Fag = new List<Fag>() };
            var elev6 = new Elev { Fornavn = "Djonatan", Efternavn = "Gjertsen", Alder = 16, Fag = new List<Fag>() };
            var elev7 = new Elev { Fornavn = "Dylan", Efternavn = "Eric Aghahowa", Alder = 23, Fag = new List<Fag>() };
            var elev8 = new Elev { Fornavn = "Hjalte", Efternavn = "Moesgaard Leth", Alder = 35, Fag = new List<Fag>() };
            var elev9 = new Elev { Fornavn = "Johan", Efternavn = "Milter Jakobsen", Alder = 19, Fag = new List<Fag>() };
            var elev10 = new Elev { Fornavn = "Louis", Efternavn = "Thomas Dao Pedersen", Alder = 26, Fag = new List<Fag>() };
            var elev11 = new Elev { Fornavn = "Lukas", Efternavn = "Haugstad Frederiksen", Alder = 31, Fag = new List<Fag>() };
            var elev12 = new Elev { Fornavn = "Marcus", Efternavn = "Wahlstrøm", Alder = 18, Fag = new List<Fag>() };
            var elev13 = new Elev { Fornavn = "Marcus", Efternavn = "Slot Rohr", Alder = 32, Fag = new List<Fag>() };
            var elev14 = new Elev { Fornavn = "Marius", Efternavn = "Ulslev Fogelgren", Alder = 23, Fag = new List<Fag>() };
            var elev15 = new Elev { Fornavn = "Mathias", Efternavn = "Altenburg", Alder = 17, Fag = new List<Fag>() };
            var elev16 = new Elev { Fornavn = "Patrick", Efternavn = "Gutierrez Fogelstrøm", Alder = 29, Fag = new List<Fag>() };
            var elev17 = new Elev { Fornavn = "Ramtin", Efternavn = "Akbari", Alder = 19, Fag = new List<Fag>() };
            var elev18 = new Elev { Fornavn = "Sebastian", Efternavn = "Nielsen", Alder = 25, Fag = new List<Fag>() };
            var elev19 = new Elev { Fornavn = "Simon", Efternavn = "Heilbuth", Alder = 18, Fag = new List<Fag>() };
            var elev20 = new Elev { Fornavn = "Thobias", Efternavn = "Svarter Hammarkvist", Alder = 17, Fag = new List<Fag>() };
            var elev21 = new Elev { Fornavn = "Yosef", Efternavn = "Kasas", Alder = 21, Fag = new List<Fag>() };
            elever.AddRange(new[] { elev1, elev2, elev3, elev4, elev5, elev6, elev7, elev8, elev9, elev10, elev11, elev12, elev13, elev14, elev15, elev16, elev17, elev18, elev19, elev20, elev21 });

            // Initialisering af fag og tildeling af lærere og elever
            var oop = new Fag { Navn = "OOP", Lærer = niels, Elever = new List<Elev>(elever) };
            var computerteknologi = new Fag { Navn = "Computerteknologi", Lærer = michael, Elever = new List<Elev>(elever) };
            var serversikkerhed = new Fag { Navn = "Serversikkerhed", Lærer = nikolaj, Elever = new List<Elev>(elever) };
            var databaseProgrammering = new Fag { Navn = "Database Programmering", Lærer = michael, Elever = new List<Elev>(elever) };
            var clientsideProgrammering = new Fag { Navn = "Clientside Programmering", Lærer = michael, Elever = new List<Elev>(elever) };
            var grundlaeggendeProgrammering = new Fag { Navn = "Grundlæggende Programmering", Lærer = henrik, Elever = new List<Elev>(elever) };

            // Tildeling af fag til lærere og tilføjelse til faglisten
            niels.Fag.Add(oop);
            michael.Fag.AddRange(new[] { computerteknologi, databaseProgrammering, clientsideProgrammering });
            henrik.Fag.Add(grundlaeggendeProgrammering);
            nikolaj.Fag.Add(serversikkerhed);
            fag.AddRange(new[] { oop, computerteknologi, serversikkerhed, databaseProgrammering, clientsideProgrammering, grundlaeggendeProgrammering });

            // Tilføj fag til elevernes Fag-lister
            foreach (var elev in elever)
            {
                elev.Fag.AddRange(new[] { oop, computerteknologi, serversikkerhed, databaseProgrammering, clientsideProgrammering, grundlaeggendeProgrammering });
            }
        }
    }
}
