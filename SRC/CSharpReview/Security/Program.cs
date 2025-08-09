
using  Security;


var connectionString = "Server=Hasan-PL;Database=AspnetB9;User Id=sa;Password= Hr@786; TrustServerCertificate=true"
;
AdonetUtility adonetUtility = new AdonetUtility(connectionString);

//var title = Console.ReadLine();
//var title = "C# ' or 1=1;Select * from Courses; --";
//var sql = "Select * from Courses where Title = '"+ title + "'";
//var data = adonetUtility.GetData(sql);

var title = "C# ' or 1=1;Select * from Courses; --";
var sql = "Select * from Courses where Title = @title";
var data = adonetUtility.GetData(sql, new Dictionary<string, object>
{
    { "title", title },
});

if (data is not null)
{
    foreach (var row in data)
    {
        foreach (var col in row)
        {
            Console.Write(col);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}

