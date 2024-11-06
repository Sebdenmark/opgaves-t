using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opjekt_dag_1
{
    internal class Account
    {
     
        public string name;
        public int customerid;

        public Account(string fullname)
        {
            name = fullname;
            Random random = new Random();
            customerid = random.Next(100000, 1000000);

        }
        
    }
}
