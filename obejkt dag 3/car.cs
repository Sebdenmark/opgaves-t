using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obejkt_dag_3
{
    //here we have the other objekt that is decendet from vichels, it does the same as the truck it just is another objekt 
    public class Car : Vehicle
    {
        private Wheels wheels = new Wheels();

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

        public void SetTireType(bool isWinterTire)
        {
            wheels.MaxRimSize = isWinterTire ? 16 : 22;
            Console.WriteLine($"Car Tire Type Set: Max Rim Size = {wheels.MaxRimSize}");
        }
    }
}
