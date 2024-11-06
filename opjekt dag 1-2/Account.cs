using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opjekt_dag_1
{
    internal class Account
    {
        // the calss it private so that if you want to changes thing in it, you have to go through the public mehods 
        private decimal balance;
        public string name;
        public int customerid;

        // Constructor,to insert the 100kr 
        public Account(string fullname)
        {
            name = fullname;
            balance = 100;
            Console.WriteLine($"Hello {name} Konto made with a startamount of 100 kr.");
            Random random = new Random();
            customerid = random.Next(100000, 1000000);

        }
        

        //here is the public methodes that we use to call or change things in the class
        public decimal GetBalance()
        {
            return balance;
        }
        
        // here we get the name
        public string GetName()
        { 
            return name;
        }

        // here we get the customer id 
        public int GetCustomerid()
        {  
            return customerid;
        }

        // here is the method ti insert money in the account, for it to work it has to be over 0 kr 
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Indsat {amount} kr. New saldo: {balance} kr.");
            }
            else
            {
                Console.WriteLine("amount has to be bigger then 0.");
            }
        }

        // here is the method that makes sure that 
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"withdraw {amount} kr. New saldo: {balance} kr.");
            }
            else
            {
                Console.WriteLine("Ugyldigt amount.");
            }
        }
    }
}
