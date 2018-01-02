using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomConstrutorExperiment
{
    public class Room
    {
        bool StartingRoom;
        private int X;
        private int Y;
        //private roomObject;

        public Room(int xCord, int yCord, bool startingRoom)
        {
            X = xCord;
            Y = yCord;
            StartingRoom = startingRoom;
        }
    }
}
