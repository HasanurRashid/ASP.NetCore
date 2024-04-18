// See https://aka.ms/new-console-template for more information


using Delegates;

BubbleSort<int> bubbleSort = new();

var result =  bubbleSort.Sort(new int[] {4,2,7,5,9,15,10,11}, Check);

foreach (var item in result)
{
    Console.Write(item);
    Console.Write(" ,");
}   
Console.WriteLine();

//bool Check(int x, int y)
//{
//    return x < y;
//}

bool Check(int a, int b) => a < b;

BubbleSort<Person> bubbleSort1 = new();
Person[] persons = new Person[]
{
    new Person(){ Name="Hasan", Age= 35},
    new Person(){ Name="Mamaun", Age= 34},
    new Person(){ Name="Mizan", Age= 29},
    new Person(){ Name="Ahsan", Age= 27},
};

var retusl1 = bubbleSort1.Sort(persons, Compare2);

bool Compare2(Person a, Person b)
{
    if (a.Name == b.Name)
    {
        return a.Age < b.Age;
    }
    else
        return a.Name.CompareTo(b.Name) < 0;
}

foreach(var person in retusl1)
{
    Console.WriteLine($"Name : {person.Name} , Age : {person.Age}");
}
