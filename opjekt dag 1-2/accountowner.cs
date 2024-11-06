using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opjekt_dag_1
{
    internal class Accountowner : Account
    {
        private decimal balance;
        public Accountowner(string fullname) : base(fullname)
        {
        }
        
    }
}
