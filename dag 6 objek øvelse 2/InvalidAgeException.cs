using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dag_6_objek_øvelse_2
{
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message) 
        { 
        
        }

        public InvalidAgeException(string message, Exception inner)
            : base(message, inner) 
        { 
        
        }
    }

}
