using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dag_4_objekt
{
    public abstract class Animal
    {
        public string Name { get; set; }

        // cunstructor for the animals names
        public Animal(string name)
        {
            Name = name;
        }

        // Abstrakt method that will be overwritten by all of the animal objekts 
        public abstract void MakeSound();
    }
}
