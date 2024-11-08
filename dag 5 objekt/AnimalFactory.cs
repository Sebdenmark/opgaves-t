using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dag_4_objekt
{
    public static class AnimalFactory
    {
        public static Animal CreateAnimal(enmAnimals animalType, string name)
        {
            return animalType switch
            {
                enmAnimals.Dog => new Dog(name),
                enmAnimals.Cat => new Cat(name),
                enmAnimals.Sheep => new Sheep(name),
                _ => throw new ArgumentException("Invalid animal type")
            };
        }

        // Overload-method to give the hardcoded names
        public static Animal CreateAnimal(enmAnimals animalType)
        {
            string defaultName = animalType switch
            {
                enmAnimals.Dog => "ALBA",
                enmAnimals.Cat => "Luna",
                enmAnimals.Sheep => "LISE",
                _ => "Unknown"
            };

            return CreateAnimal(animalType, defaultName);
        }
    }
}
