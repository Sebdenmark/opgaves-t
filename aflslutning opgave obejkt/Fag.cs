using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aflslutning_opgave_obejkt
{
    public class Fag
    {
        public string Navn { get; set; }
        public Lærer Lærer { get; set; }
        public List<Elev> Elever { get; set; }
    }
}
