using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1NandiniPatel
{
    internal class Vehicle
    {
        public int id { get; set; }
        public string name { get; set; }
        public double rentalPrice { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public bool isReserved { get; set; }
        public Vehicle(int id, string name, double rentalPrice, string category, string type, bool isReserved)
        {
            this.id = id;
            this.name = name;
            this.rentalPrice = rentalPrice;
            this.category = category;
            this.type = type;
            this.isReserved = isReserved;
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        enum categories
        {
            Hatchback, Sedan, SUV, Cruiser, Sports, Dirt
        }

        enum types
        {
            Standard, Exotic, Bike, Trike
        }
    }
}
