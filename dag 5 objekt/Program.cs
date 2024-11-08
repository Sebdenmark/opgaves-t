namespace dag_4_objekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // here we are difing new names that will override the hardcode names 
            Animal dog = AnimalFactory.CreateAnimal(enmAnimals.Dog, "Hans");
            Animal cat = AnimalFactory.CreateAnimal(enmAnimals.Cat, "Sniffler");
            Animal sheep = AnimalFactory.CreateAnimal(enmAnimals.Sheep);

            Console.WriteLine($"{dog.Name} makes this sound: ");
            dog.MakeSound();

            Console.WriteLine($"{cat.Name} makes this sound: ");
            cat.MakeSound();

            Console.WriteLine($"{sheep.Name} makes this sound: ");
            sheep.MakeSound();

            Console.ReadLine();
        }
    }
}
