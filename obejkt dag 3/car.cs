using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obejkt_dag_3
{
    public class Car : Vehicle
    {
       //here we check if the car needs to be inspectet
        public override bool InspectionStatus()
        {
            
            var age = DateTime.Now - ProductionDate;
            var lastInspectionAge = DateTime.Now - LastInspection;

            return age.TotalDays / 365 > 4 && lastInspectionAge.TotalDays / 365 > 2;
        }

        public override string DisplayInfo()
        {
            return $"Car: {Brand} {Model}";
        }
    }
}
