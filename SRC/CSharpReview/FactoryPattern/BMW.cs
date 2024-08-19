using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class BMW : ICar
    {
        public string Color { get; set; }
        public string Model { get; set; }
        public double FuelCapacity { get; set; }
    }
}
