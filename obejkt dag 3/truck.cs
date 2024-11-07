using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obejkt_dag_3
{
    //here we have one of the objekts decent from vehicel
    public class Truck : Vehicle
    {
        private Wheels wheels = new Wheels();

        //here we uses a bool to show if it needs inspection and then it will show true else it will show fales
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

        //here it show the max rim size
        public void SetTireType(bool isWinterTire)
        {
            wheels.MaxRimSize = isWinterTire ? 17 : 20;
            Console.WriteLine($"Truck Tire Type Set: Max Rim Size = {wheels.MaxRimSize}");
        }
    }
}
