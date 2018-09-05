using RoomConstrutorExperiment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomConstrutorExperiment
{
    class Grapichs
    {

        public void DrawMap()
        {
            Console.Clear();
            DrawStats();
            DrawRooms();
        }

        private void DrawStats()
        {
            Console.WriteLine("World");
            Console.Write("X: " + SingleTon.GetRooms().GetLength(0) + "          ");
            Console.WriteLine("Y: " + SingleTon.GetRooms().GetLength(1));
            Console.WriteLine("Rooms: " + SingleTon.GetRooms().GetLength(0) + SingleTon.GetRooms().GetLength(1));

        }

        private void DrawRooms() //limit map to 50*50 and move the "camera" around the map 
        {
            for (int i = 0; i < SingleTon.GetRooms().GetLength(0); i++)
            {
                Console.Write("        ");
                for (int x = 0; x < SingleTon.GetRooms().GetLength(1); x++)
                {
                    if ((SingleTon.GetCursor().GetCords()[0] == i && SingleTon.GetCursor().GetCords()[1] == x))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("O");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (SingleTon.GetRooms()[i, x] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("#");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(" ");
                }
            }
        }
    }
}
