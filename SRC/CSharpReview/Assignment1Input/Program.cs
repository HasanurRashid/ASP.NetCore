// See https://aka.ms/new-console-template for more information

using Assignment1Input;

SimpleMapper simpleMapper = new();

House house = new House
{
   Rooms = new List<Room>
   {
      new Room
      {
          RoomNumber = "101",
          Windows = new List<Window>
          {
              new Window
              {
                  Width= 100,
                  Height= 200
              },
              new Window
              {
                  Width= 44,
                  Height= 50
              },
          }
      },
      new Room
      {
          RoomNumber = "102",
          Windows = new List<Window>
          {
              new Window
              {
                  Width= 300,
                  Height= 200
              },
              new Window
              {
                  Width= 150,
                  Height= 100
              },
          }
      }
   }
};

Building building = new();
simpleMapper.Copy(house, building);
