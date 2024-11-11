using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dag_6_objek_øvelse_2
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message) : base(message) 
        { 
        
        }

        public InvalidEmailException(string message, Exception inner)
            : base(message, inner) 
        { 
        
        }
    }
}
