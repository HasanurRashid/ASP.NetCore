using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public abstract class CarFactory
    {
        public abstract ICar Create(string color, string model, double fuelCapacity);
    }
}
