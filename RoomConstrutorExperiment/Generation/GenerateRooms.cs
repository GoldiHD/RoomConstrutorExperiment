using RoomConstrutorExperiment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomConstrutorExperiment.Generation
{
    class GenerateRooms
    {
        Random RNG = new Random(Guid.NewGuid().GetHashCode()); //should be better random

        public void GenerateWorld(int roomsToCreate)
        {
            throw new Exception("Create new rooms");

            PickCursorSpawnPoint();
        }

        private int[] GiveRandomRoomConnected()//try and make it relative to other rooms
        {
            int tempx;
            int tempy;
            while (true)
            {
                tempx = RNG.Next(0, SingleTon.GetRooms().GetLength(0));
                tempy = RNG.Next(0, SingleTon.GetRooms().GetLength(1));
                if (SingleTon.GetRooms()[tempx, tempy] != null)
                {
                    return new int[2] { tempx, tempy };
                }
            }
        }
        private int[] GiveRandomRoom()//try and make it relative to other rooms
        {
            int tempx;
            int tempy;
            while (true)
            {
                tempx = RNG.Next(0, SingleTon.GetRooms().GetLength(0));
                tempy = RNG.Next(0, SingleTon.GetRooms().GetLength(1));
                if (SingleTon.GetRooms()[tempx, tempy] == null)
                {
                    return new int[2] { tempx, tempy };
                }
            }

        }
        private int[] GivePassageRooms()//Create Passages between rooms
        {
            throw new System.Exception("This feature is not yet to be implamented");
            return new int[] { 0, 1 };
        }


        private void PickCursorSpawnPoint()
        {

        }
    }
}

