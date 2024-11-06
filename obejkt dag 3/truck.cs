using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obejkt_dag_3
{
    public class Truck : Vehicle
    {
        //here we checks if the truck needs to be inspectet 
        public override bool InspectionStatus()
        {
          
            var age = DateTime.Now - ProductionDate;
            var lastInspectionAge = DateTime.Now - LastInspection;

            return age.TotalDays / 365 > 1 && lastInspectionAge.TotalDays / 365 > 1;
        }

       
        public override string DisplayInfo()
        {
            return $"Truck: {Brand} {Model}";
        }
    }
}
