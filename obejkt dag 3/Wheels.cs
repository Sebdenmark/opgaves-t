using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obejkt_dag_3
{
    public class Wheels : IWheels
    {
        public int MaxRimSize { get; set; }

        public void SetTireType(bool isWinterTire)
        {
            //this method will be overwritten in car or truck to find the right size of the tire and make us able to use it with out writing it more times 
        }
    }
}
