// See https://aka.ms/new-console-template for more information

using Reflection;
using System.Reflection;
using System.Collections;

/*
Assembly assembly = Assembly.GetExecutingAssembly();
Type t;

foreach (Type type in assembly.GetTypes())
{
    if(type.Name=="Program")
    {
        var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        foreach (var item in methods)
        {
            Console.WriteLine(item.Name);
        }
    }
   
}

void GetFruit(Enum fruit)
{
    Console.WriteLine(Convert.ToInt32(fruit));
}

GetFruit(Fruits.Apple | Fruits.Banana);

enum Fruits
{
    Apple = 1,
    Banana = 2,
    Orange = 3,
    WaterMelon = 4
}



00001
00010
00100
10000

*/

Course course = new Course("C#", 8000, new List<Topic>
{
  new Topic{ Title = "Introduction", Duration = 1 },
  new Topic{ Title= "Get Started", Duration = 2 }
});

Type type = course.GetType();

var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.ExactBinding);

foreach (var property in properties)
{
    if (property.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)))
    {
        var items = (IEnumerable)property.GetValue(property);

        foreach (var item in items)
        {
            var it = item.GetType();
            var topicTypes = it.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var topicType in topicTypes)
            {

                Console.WriteLine(topicType.GetValue(item));

            }
        }
        Console.WriteLine();
    }
    else
        Console.WriteLine(property.GetValue(course));
}






