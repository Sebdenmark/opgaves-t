using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dag_1_øvelse_3
{
   // we use a struct here becouse it is the same way we always will calculate bmi 
    public struct Measurement
    {
     
        public double BMI { get; }

        public Measurement(double weight, double height)
        {
            if (height <= 0)
                throw new ArgumentException("Height must be greater than zero.");

            BMI = weight / (height * height);
        }
    }
}
