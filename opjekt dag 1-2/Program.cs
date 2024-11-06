namespace opjekt_dag_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("put in your full name");

            string fullname = Console.ReadLine();
            //here we make an instance of the bankaccount 
            Account myAccount = new Account(fullname);

            Console.WriteLine($"Saldo: {myAccount.GetBalance()} kr");


            Console.WriteLine("how much do you want to deposit");
            decimal newDeposit = decimal.Parse( Console.ReadLine() );
            
            myAccount.Deposit(newDeposit);


            Console.WriteLine("how muc do you want to withdraw");
            decimal newwithdraw = decimal.Parse( Console.ReadLine() );
   
            myAccount.Withdraw(newwithdraw);

    
            Console.WriteLine($"{myAccount.GetName()} customer id: {myAccount.GetCustomerid()} Saldo: {myAccount.GetBalance()} kr");

            Console.ReadLine();
        }
    }
}
