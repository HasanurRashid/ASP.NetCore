// See https://aka.ms/new-console-template for more information

using BuilderPattern;

string connectionString = new ConnectionStringBuilder("Maaq-B","CSharpDB")
    .UsePort(4444)
    .UseTrustedConnection()
    .GetConnectionString();
Console.WriteLine(connectionString);

