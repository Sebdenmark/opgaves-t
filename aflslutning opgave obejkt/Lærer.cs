using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aflslutning_opgave_obejkt
{
    public class Lærer : Person, IPerson
    {
        public List<Fag> Fag { get; set; }

        public string GetFullName()
        {
            return $"{Fornavn} {Efternavn}";
        }
    }
}
