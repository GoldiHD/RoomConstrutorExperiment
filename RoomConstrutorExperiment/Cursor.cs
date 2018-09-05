using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomConstrutorExperiment
{
    class Cursor
    {
        private int xCord = 0;
        private int yCord = 0;
        private Room CurrentRoom;

        public Room GetCurrentRoom()
        {
            return CurrentRoom;
        }

        public int GetX()
        {
            return xCord;
        }

        public int GetY()
        {
            return yCord;
        }

        public void SetCurrentRoom(Room currentroom)
        {
            CurrentRoom = currentroom;
            SetX(CurrentRoom.X);
            SetY(CurrentRoom.Y);
        }

        public int[] GetCords()
        {
            return new int[] { xCord, yCord };
        }


        public void SetX(int x)
        {
            xCord = x;
        }

        public void SetY(int y)
        {
            yCord = y;
        }
    }
}
