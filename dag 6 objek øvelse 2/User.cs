using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dag_6_objek_øvelse_2
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public int CompareTo(User other)
        {
            if (other == null) return 1;

            int lastNameComparison = LastName.CompareTo(other.LastName);

            if (lastNameComparison == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }

            return lastNameComparison;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}, Age: {Age}, Email: {Email}";
        }
    }
}
