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
        public int X;
        public int Y;
        private int Value;

        //private roomObject;

        public Room(int xCord, int yCord, bool startingRoom, int value)
        {
            Value = value;
            X = xCord;
            Y = yCord;
            StartingRoom = startingRoom;
        }

        public int GetValue()
        {
            return Value;
        }

    }
}
