using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace opjekt_dag_1
{
    internal class AccountAdmin : Account
    {
        //here we get the name aswell as an custome id from the other classe 
        public AccountAdmin(string fullname) : base(fullname)
        {
            
            Console.WriteLine($"AccountAdmin initialized for {name} with Customer ID: {customerid}");
        }

        public void DisplayAccountInfo()
        {

            Console.WriteLine($"Admin: {name}");
            Console.WriteLine($"Customer ID: {customerid}");
        }
    }
}
