using System.Collections.Immutable;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace A1NandiniPatel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice, option, option2;
            List<Vehicle> v = new List<Vehicle>();
            v.AddRange(new List<Vehicle>
            {
                new Vehicle(1, "Honda Civic", 69.9, "Sedan", "Standard", true),
                new Vehicle(2, "Toyota Corolla", 69.9, "Sedan", "Standard", true),
                new Vehicle(3, "Ford Explorer", 99.9, "SUV", "Standard", true),
                new Vehicle(4, "Nissan Versa", 49.9, "Hatchback", "Standard", true),
                new Vehicle(5, "Hyundai Tucson", 89.9, "SUV", "Standard", true),
                new Vehicle(6, "Lamborghini Aventador", 189.9, "Sports", "Exotic", true),
                new Vehicle(7, "Ferrari 488 GTB", 179.9, "Sports", "Exotic", true),
                new Vehicle(8,"MacLaren P1", 199.9, "Sports", "Exotic", true),
                new Vehicle(9, "Suzuki Boulevard M109R", 49.9, "Crusier", "Bike", true),
                new Vehicle(10,"Harley-Davidson Street Glide", 79.9, "Crusier", "Bike", true),
                new Vehicle(11,"Honda CRF125", 39.9, "Dirt", "Bike", true),
                new Vehicle(12,"Ducati Monster", 69.9, "Sports", "Bike", true),
                new Vehicle(13,"Can-Am Spyder", 59.9, "Cruiser", "Trike", true),
                new Vehicle(14,"Polaris Slingshot", 69.9, "Cruiser", "Trike", true)
            });

            var displayItem = from vehicle in v select vehicle;
            do
            {
                Console.WriteLine("\nASSIGNMENT-1 by GURSHARAN TATLA");
                Console.WriteLine("**********************************************************");

                Console.WriteLine("1 - View all vehicles");
                Console.WriteLine("2 - View available Vehicles");
                Console.WriteLine("3 - View Reserved Vehicles");
                Console.WriteLine("4 - Reserve a Vehicle");
                Console.WriteLine("5 - Cancel Reservation");
                Console.WriteLine("6 - Exit");

                Console.WriteLine("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nAll Vehicles");
                        Console.WriteLine("\nID  Name\t\t\t\tRental Price\t\tCategory\tType\t\tAvailable");
                        foreach (var item in displayItem)
                        {
                            Console.WriteLine($"{item.id}  {item.name,-30}\t\t{item.rentalPrice}\t\t{item.category,-12}\t{item.type,-11}\t{item.isReserved}");
                        }
                        break;
                    case 2:
                        var availableItem = from avehicle in v where avehicle.isReserved = true select avehicle;
                        Console.WriteLine("\nAll available Vehicles");
                        Console.WriteLine("\nID  Name\t\t\t\tRental Price\t\tCategory\tType");
                        foreach (var item in availableItem)
                        {
                            Console.WriteLine($"{item.id}  {item.name,-30}\t\t{item.rentalPrice}\t\t{item.category,-12}\t{item.type,-11}");
                        }
                        break;
                    case 3:
                        var a = from rv in v where rv.isReserved == false select rv;
                        Console.WriteLine("Reserved Vehicle: ");
                        foreach (var r in a)
                        {
                            Console.WriteLine($"{r.id}  {r.name,-30}\t\t{r.rentalPrice}\t       \t{r.category,-12}\t\t{r.type,-11}");
                        }
                        break;
                    case 4:
                        var rItem = from rvehicle in v where rvehicle.isReserved = true select rvehicle;

                        Console.WriteLine("\nAvailable Vehicles to reserve: ");
                        Console.WriteLine("\nID  Name\t\t\t\t\tRental Price\t\tCategory\tType");
                        foreach (var reserve in rItem)
                        {
                            Console.WriteLine($"{reserve.id}  {reserve.name,-30}\t\t        {reserve.rentalPrice}\t\t{reserve.category,-12}\t{reserve.type}");
                        }

                        Console.WriteLine("Enter Vehicle number to reserve: ");
                        option = Convert.ToInt32(Console.ReadLine());

                        
                        var rc = from rv in v where rv.id == option select rv;
                        if (option <= 14)
                        {

                            Console.WriteLine("Vehicle Reservation Successful.");
                            Console.WriteLine("\nAvailable Vehicles to reserve: ");
                            Console.WriteLine("\nID  Name\t\t\t\tRental Price\t\tCategory           \tType");
                            foreach (var r in rc)
                            {
                                Console.WriteLine($"{r.id}  {r.name,-30}\t\t{r.rentalPrice}\t       \t{r.category,-12}\t\t{r.type,-11}");
                            }
                            foreach(var update in v.Where(w => w.id == option))
                            {
                                update.isReserved = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no record found.");
                        }
                        break;
                    case 5:
                        var cancel = from rv in v where rv.isReserved == false select rv;
                        Console.WriteLine("Reserved Vehicle: ");
                        foreach (var c in cancel)
                        {
                            Console.WriteLine($"{c.id}  {c.name,-30}\t\t{c.rentalPrice}\t       \t{c.category,-12}\t\t{c.type,-11}");
                        }

                        Console.WriteLine("Enter the Vehicle ID to cancel the reservation: ");
                        option2 = Convert.ToInt32(Console.ReadLine());

                        foreach (var update in v.Where(w => w.id == option2))
                        {
                            update.isReserved = true;
                        }
                        Console.WriteLine("Reservation has been cancelled successfully.");
                        break;
                    case 6:
                        Console.WriteLine("Press any key to exit..");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice..!!");
                        break;

                }
            } while (choice<6);
        }
    }
}