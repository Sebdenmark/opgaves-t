using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dag_1_øvelse_3
{
    public class Person
    {
        // Properties for Personens data
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        
        public double BMI
        {
            get
            {
                Measurement measurement = new Measurement(Weight, Height);
                return measurement.BMI;
            }
        }
    }
}
