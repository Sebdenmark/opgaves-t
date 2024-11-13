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
            // Initialisering af lærere
            var henrik = new Lærer { Fornavn = "Henrik", Efternavn = "Paulsen", Fag = new List<Fag>() };
            var niels = new Lærer { Fornavn = "Niels", Efternavn = "Olsen", Fag = new List<Fag>() };
            lærere.AddRange(new[] { henrik, niels });

            // Initialisering af elever med tomme Fag-lister for at undgå null reference fejl
            var elev1 = new Elev { Fornavn = "Andreas", Efternavn = "Hansen", Alder = 18, Fag = new List<Fag>() };
            var elev2 = new Elev { Fornavn = "Sebastian", Efternavn = "Nielsen", Alder = 25, Fag = new List<Fag>() };
            var elev3 = new Elev { Fornavn = "Johan", Efternavn = "Christensen", Alder = 17, Fag = new List<Fag>() };
            var elev4 = new Elev { Fornavn = "Markus", Efternavn = "Jensen", Alder = 30, Fag = new List<Fag>() };
            elever.AddRange(new[] { elev1, elev2, elev3, elev4 });

            // Initialisering af fag og tildeling af lærere og elever
            var fag1 = new Fag { Navn = "Computerteknologi", Lærer = henrik, Elever = new List<Elev> { elev1, elev2, elev4 } };
            var fag2 = new Fag { Navn = "Serversikkerhed", Lærer = henrik, Elever = new List<Elev> { elev1, elev4 } };
            var fag3 = new Fag { Navn = "Databaseprogrammering", Lærer = henrik, Elever = new List<Elev> { elev3, elev4 } };
            var fag4 = new Fag { Navn = "Objektiv programmering", Lærer = niels, Elever = new List<Elev> { elev2, elev3, elev4 } };
            var fag5 = new Fag { Navn = "Whitehacking", Lærer = niels, Elever = new List<Elev> { elev2, elev3, elev4 } };
            var fag6 = new Fag { Navn = "OS", Lærer = niels, Elever = new List<Elev> { elev4 } };

            // Tildeling af fag til lærere og tilføjelse til faglisten
            henrik.Fag.AddRange(new[] { fag1, fag2, fag3 });
            niels.Fag.AddRange(new[] { fag4, fag5, fag6 });
            fag.AddRange(new[] { fag1, fag2, fag3, fag4, fag5, fag6 });

            // Tilføj fag til elevernes Fag-lister
            elev1.Fag.AddRange(new[] { fag1, fag2 });
            elev2.Fag.AddRange(new[] { fag1, fag4, fag5 });
            elev3.Fag.AddRange(new[] { fag3, fag4, fag5 });
            elev4.Fag.AddRange(new[] { fag1, fag2, fag3, fag4, fag5, fag6 });
        }
    }
}
