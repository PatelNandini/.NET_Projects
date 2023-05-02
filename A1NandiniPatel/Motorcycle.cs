using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1NandiniPatel
{
    internal class Motorcycle : Vehicle
    {
        public Motorcycle(int id, string name, double rentalPrice, string category, string type, bool isReserved) : base(id, name, rentalPrice, category, type, isReserved)
        {
        }
    }
}
