namespace obejkt_dag_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //here we use the objekt and make and instance of car
            Car myCar = new Car
            {
                Brand = "BMW",
                Model = "i8",
                ProductionDate = new DateTime(2017, 5, 1),
                LastInspection = new DateTime(2020, 8, 15)
            };
            myCar.SetTireType(isWinterTire: true); 
            Console.WriteLine(myCar.DisplayInfo());
            Console.WriteLine($"Needs Inspection: {myCar.InspectionStatus()}");
            Console.WriteLine(myCar.GetInterfaceInfo());
            //here we use the obejkt and makes a instance of truck 
            Truck myTruck = new Truck
            {
                Brand = "AUDI",
                Model = "A6",
                ProductionDate = new DateTime(2022, 3, 10),
                LastInspection = new DateTime(2023, 4, 20)
            };
            myTruck.SetTireType(isWinterTire: false); 
            Console.WriteLine(myTruck.DisplayInfo());
            Console.WriteLine($"Needs Inspection: {myTruck.InspectionStatus()}");
            Console.WriteLine(myTruck.GetInterfaceInfo());

            Console.ReadLine();
        }
    }
}

