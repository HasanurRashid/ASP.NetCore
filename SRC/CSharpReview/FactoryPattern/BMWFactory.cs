using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class BMWFactory : CarFactory
    {
        public override ICar Create(string color, string model, double fuelCapacity)
        {
           return new BMW() { Color = color, Model = model, FuelCapacity = fuelCapacity };
        }
    }
}
