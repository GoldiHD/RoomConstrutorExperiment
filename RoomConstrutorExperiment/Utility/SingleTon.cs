using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomConstrutorExperiment.Utility
{
    class SingleTon
    {
        private static Room[,] AllRoomsInstace;
        private static Cursor cursorInstance;

        public static void SetUpCursor(Room current)
        {
            cursorInstance = new Cursor();
            cursorInstance.SetCurrentRoom(current);
        }

        public static Cursor GetCursor()
        {
            return cursorInstance;
        }

        public static void SetUpRooms(int x, int y)
        {
            AllRoomsInstace = new Room[x, y];
        }

        public static Room[,] GetRooms()
        {
            return AllRoomsInstace;
        }


    }
}
