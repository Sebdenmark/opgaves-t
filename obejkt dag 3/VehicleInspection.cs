using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obejkt_dag_3
{

    //here we have the vehicle where the truck and car is descend from
    public abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime LastInspection { get; set; }

        public abstract bool InspectionStatus();

        public virtual string DisplayInfo()
        {
            return $"Brand: {Brand}, Model: {Model}, Production Date: {ProductionDate.ToShortDateString()}";
        }
    }
}
