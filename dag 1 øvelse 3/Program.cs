namespace dag_1_øvelse_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //here we make a new instance of person
            Person person = new Person
            {
                FirstName = "Sebastian",
                LastName = "nielsen",
                Weight = 80, 
                Height = 1.89 
            };

          
            Console.WriteLine($"Person: {person.FirstName} {person.LastName}");
            Console.WriteLine($"BMI: {person.BMI:F2}");
            Console.ReadLine();
        }
    }
}
