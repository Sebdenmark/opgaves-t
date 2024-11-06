namespace obejkt_dag_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //here we make an instance of the objekt car 
            Car myCar = new Car
            {
                Brand = "BMW",
                Model = "i8",
                ProductionDate = new DateTime(2017, 5, 1),
                LastInspection = new DateTime(2020, 8, 15)
            };

            //here we make an instance of the object truck 
            Truck myTruck = new Truck
            {
                Brand = "AUDI",
                Model = "A6",
                ProductionDate = new DateTime(2022, 3, 10),
                LastInspection = new DateTime(2023, 4, 20)
            };

           
            Console.WriteLine(myCar.DisplayInfo());
            Console.WriteLine($"Needs Inspection: {myCar.InspectionStatus()}");

            Console.WriteLine(myTruck.DisplayInfo());
            Console.WriteLine($"Needs Inspection: {myTruck.InspectionStatus()}");

            Console.ReadLine();
        }
    }
}
