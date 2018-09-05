using RoomConstrutorExperiment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomConstrutorExperiment
{
    class Controls
    {
        private Cursor cursor;
        public bool KeyCommands(ConsoleKey key)
        {
            if(cursor == null)
            {
                SingleTon.GetCursor();
            }
            Console.WriteLine("Controls need a rework");
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (cursor.GetCords()[0] == 0)
                    {
                        cursor.SetX(SingleTon.GetRooms().GetLength(0) - 1);
                        return true;

                    }
                    else if (SingleTon.GetRooms()[cursor.GetX() - 1, cursor.GetY()] != null)
                    {
                        cursor.SetX(cursor.GetX() - 1);
                        return true;
                    }
                    cursor.SetCurrentRoom(SingleTon.GetRooms()[cursor.GetX(), cursor.GetY()]);
                    break;

                case ConsoleKey.DownArrow:
                    if (cursor.GetCords()[0] == (SingleTon.GetRooms().GetLength(0) - 1))
                    {
                        cursor.SetX(0);
                        return true;
                    }
                    else if (SingleTon.GetRooms()[cursor.GetX() + 1, cursor.GetY()] != null)
                    {
                        cursor.SetX(cursor.GetX() + 1);
                        return true;
                    }
                    cursor.SetCurrentRoom(SingleTon.GetRooms()[cursor.GetX(), cursor.GetY()]);

                    break;

                case ConsoleKey.RightArrow:
                    if (cursor.GetCords()[1] == (SingleTon.GetRooms().GetLength(1) - 1))
                    {
                        cursor.SetY(SingleTon.GetRooms().GetLength(1) - 1);
                        return true;
                    }
                    else if (SingleTon.GetRooms()[cursor.GetX(), cursor.GetY() + 1] != null)
                    {
                        cursor.SetY(cursor.GetY() + 1);
                        return true;
                    }
                    cursor.SetCurrentRoom(SingleTon.GetRooms()[cursor.GetX(), cursor.GetY()]);
                    break;

                case ConsoleKey.LeftArrow:
                    if (cursor.GetCords()[1] == 0)
                    {
                        cursor.SetY(SingleTon.GetRooms().GetLength(0) - 1);
                        return true;
                    }
                    else if (SingleTon.GetRooms()[cursor.GetX(), cursor.GetY() - 1] != null)
                    {
                        cursor.SetY(cursor.GetY() - 1);
                        return true;
                    }
                    cursor.SetCurrentRoom(SingleTon.GetRooms()[cursor.GetX(), cursor.GetY()]);
                    return true;
            }
            return false;
        }
    }
}
