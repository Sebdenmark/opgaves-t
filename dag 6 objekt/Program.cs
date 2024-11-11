namespace dag_6_objekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int beløb = 0;
            int konto = 100;

            try
            {
                Console.WriteLine("write amount");
                beløb = int.Parse(Console.ReadLine());
                konto = konto + beløb;
                Console.WriteLine("Hvor meget vil du hæve? Du har en startsaldo på 100 kr.");
                int withdraw = int.Parse(Console.ReadLine());

                if (withdraw > konto)
                {
                    throw new InvalidOperationException("Saldoen er for lav til at gennemføre hævningen.");
                }

                konto -= withdraw; 

                Console.WriteLine($"Du har hævet {withdraw} kr. Ny saldo: {konto} kr.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ugyldigt input. Indtast venligst et gyldigt tal.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"here is the final acount {konto}");
                Console.ReadLine(); 
            }


        }
    }
}
