using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dag_6_objek_øvelse_2
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string message) : base(message) 
        {
        
        }

        public InvalidNameException(string message, Exception inner)
            : base(message, inner) 
        { 
        
        }
    }
}
