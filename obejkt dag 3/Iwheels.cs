using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obejkt_dag_3
{
    public interface IWheels
    {
        int MaxRimSize { get; set; }
        void SetTireType(bool isWinterTire);

        // Concrete method, that return the text so we can see wich is objekter 
        string Info()
        {
            return "Brug mig for alle objekter som køres på hjul.";
        }
    }
}
