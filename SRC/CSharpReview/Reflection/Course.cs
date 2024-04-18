using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Course
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Topic> Topics { get;}

        public Course( string name, double price, List<Topic> topics)
        {
            Name = name;
            Price = price;
            Topics = topics;
        }
    }
}
