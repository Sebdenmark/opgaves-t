using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aflslutning_opgave_obejkt
{
    public abstract class Person
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
    }

    public interface IPerson
    {
        string GetFullName();
    }
}
