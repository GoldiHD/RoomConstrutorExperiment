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
        int XDrawingStart = 0;
        int XDrawingEnd = 0;
        int YDrawingStart = 0;
        int YDrawingEnd = 0;
        int ScreenRes = 20;


        public void DrawMap()
        {
            Console.Clear();
            DrawStats();
            CalculateDrawPos();
            DrawRooms();
        }

        private void DrawStats()
        {
            Console.WriteLine("World");
            Console.Write("X: " + SingleTon.GetRooms().GetLength(0) + "          ");
            Console.WriteLine("Y: " + SingleTon.GetRooms().GetLength(1));
            Console.WriteLine("Cursor X: " + SingleTon.GetCursor().GetX() + "     Y: " + SingleTon.GetCursor().GetY());
            Console.WriteLine("Rooms: " + (SingleTon.GetRooms().GetLength(0) * SingleTon.GetRooms().GetLength(1)));

        }

        private void DrawRooms() //limit map to 50*50 and move the "camera" around the map 
        {
            for (int i = XDrawingStart; i < XDrawingEnd; i++)
            {
                Console.Write("        ");
                for (int x = YDrawingStart; x < YDrawingEnd; x++)
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
                    Console.Write("   ");
                }
                Console.WriteLine("\n");
            }
        }
            

        private void CalculateDrawPos()
        {
            XDrawingStart = 0;
            YDrawingStart = 0;
            XDrawingEnd = 0;
            YDrawingEnd = 0;
            if (SingleTon.GetRooms().GetLength(0) < ScreenRes && SingleTon.GetRooms().GetLength(1) < ScreenRes)
            {
                XDrawingStart = 0;
                YDrawingStart = 0;
                XDrawingEnd = SingleTon.GetRooms().GetLength(0);
                YDrawingEnd = SingleTon.GetRooms().GetLength(1);
            }
            else
            {
                if ((SingleTon.GetCursor().GetX() - (ScreenRes / 2)) > 0)
                {
                    XDrawingStart += SingleTon.GetCursor().GetX() - (ScreenRes / 2);
                }
                else
                {
                    XDrawingEnd += (ScreenRes / 2) - SingleTon.GetCursor().GetX();
                    XDrawingStart += 0;
                }

                if ((SingleTon.GetCursor().GetX() + (ScreenRes / 2)) < SingleTon.GetRooms().GetLength(0))
                {
                    XDrawingEnd = SingleTon.GetCursor().GetX() + (ScreenRes / 2);
                }
                else
                {
                    XDrawingStart += (ScreenRes / 2) - (SingleTon.GetRooms().GetLength(0) - SingleTon.GetCursor().GetX());
                    XDrawingEnd += SingleTon.GetCursor().GetX() + (SingleTon.GetRooms().GetLength(0) - SingleTon.GetCursor().GetX());
                }

                if ((SingleTon.GetCursor().GetY() - (ScreenRes / 2)) > 0)
                {
                    YDrawingStart += SingleTon.GetCursor().GetY() - (ScreenRes / 2);
                }
                else
                {
                    YDrawingEnd += (ScreenRes / 2) - SingleTon.GetCursor().GetY();
                    YDrawingStart = 0;
                }

                if ((SingleTon.GetCursor().GetY() + (ScreenRes / 2)) < SingleTon.GetRooms().GetLength(1))
                {
                    YDrawingEnd += SingleTon.GetCursor().GetY() + (ScreenRes / 2);
                }
                else
                {
                    YDrawingStart += (ScreenRes / 2) - (SingleTon.GetRooms().GetLength(1) - SingleTon.GetCursor().GetY()); ;
                    YDrawingEnd += SingleTon.GetCursor().GetY() + (SingleTon.GetRooms().GetLength(1) - SingleTon.GetCursor().GetY());
                }
            }
        }

    }
}
