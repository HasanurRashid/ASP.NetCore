using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.BMW
{
    public class BMWFactory : CarFactory
    {
        public override IEngine CreateEngine()
        {
          return new Engine();
        }

        public override IHeadLight CreateHeadLight()
        {
           return new HeadLight();
        }

        public override ITire CreateTire()
        {
           return new Tire();
        }
    }
}
