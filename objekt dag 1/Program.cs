
namespace objekt_dag_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
 
            string text = @"The common type system (CTS) is a standard that specifies how types are defined and managed in the .NET runtime. 
                            It defines rules for type visibility, inheritance, and conversion between types. All types in C# are derived from the base type object.
                            By using the CTS, .NET can ensure that data types defined in one language can be used in another language.";

            string wordToCount = "type";


            //here we are using the class by making a new instance and using the method 
            WordCounter counter = new WordCounter();
            int occurrences = counter.CountOccurrences(text, wordToCount);
            Console.WriteLine($"Ordet '{wordToCount}' forekommer i alt {occurrences} gange.");

            Console.ReadLine();
        }
    }
}
