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
        Room[,] AllRooms;
        Room[,] RoomsConnected;
        List<Waypoints> waypoints = new List<Waypoints>();

        public void GenerateWorld(int roomsToCreate)
        {
            //throw new Exception("Create new rooms");
            List<int> Postions;
            int Tempx = RNG.Next(0, SingleTon.GetRooms().GetLength(0));
            int Tempy = RNG.Next(0, SingleTon.GetRooms().GetLength(1));
            int tempPicked;
            bool FoundASpot;
            SingleTon.GetRooms()[Tempx, Tempy] = new Room(Tempx, Tempy, true, RNG.Next(0, 101));
            SingleTon.SetUpCursor(SingleTon.GetRooms()[Tempx, Tempy]);
            for (int i = 1; i < roomsToCreate; i++)
            {
                Postions = new List<int> { 0, 1, 2, 3 };
                FoundASpot = false;
                for (int x = 0; x < 4; x++)
                {
                    tempPicked = RNG.Next(0, Postions.Count);
                    switch (tempPicked)
                    {
                        case 0:
                            if ((Tempx + 1) < (SingleTon.GetRooms().GetLength(0) - 1) && SingleTon.GetRooms()[(Tempx + 1), Tempy] == null)
                            {
                                Tempx++;
                                SingleTon.GetRooms()[Tempx, Tempy] = new Room(Tempx, Tempy, false, RNG.Next(0, 101));
                                FoundASpot = true;
                            }
                            else
                            {
                                Postions.Remove(tempPicked);
                            }
                            break;

                        case 1:
                            if ((Tempx - 1) > -1 && SingleTon.GetRooms()[(Tempx - 1), Tempy] == null)
                            {
                                Tempx--;
                                SingleTon.GetRooms()[Tempx, Tempy] = new Room(Tempx, Tempy, false, RNG.Next(0, 101));
                                FoundASpot = true;
                            }
                            else
                            {
                                Postions.Remove(tempPicked);
                            }
                            break;

                        case 2:
                            if ((Tempy + 1) < (SingleTon.GetRooms().GetLength(1) - 1) && SingleTon.GetRooms()[Tempx, (Tempy + 1)] == null)
                            {
                                Tempy++;
                                SingleTon.GetRooms()[Tempx, Tempy] = new Room(Tempx, Tempy, false, RNG.Next(0, 101));
                                FoundASpot = true;
                            }
                            else
                            {
                                Postions.Remove(tempPicked);
                            }
                            break;

                        case 3:
                            if ((Tempy - 1) > -1 && SingleTon.GetRooms()[Tempx, (Tempy - 1)] == null)
                            {
                                Tempy--;
                                SingleTon.GetRooms()[Tempx, Tempy] = new Room(Tempx, Tempy, false, RNG.Next(0, 101));
                                FoundASpot = true;
                            }
                            else
                            {
                                Postions.Remove(tempPicked);
                            }
                            break;
                    }
                    if (FoundASpot == true)
                    {
                        break;
                    }
                    else if (x == 3)
                    {
                        if (RNG.Next(0, 101) > 25)
                        {
                            int[] tempHolder = GiveRandomRoomConnected();
                            Tempx = tempHolder[0];
                            Tempy = tempHolder[1];
                        }
                        else
                        {
                            int[] tempHolder = GiveRandomRoom();
                            Tempx = tempHolder[0];
                            Tempy = tempHolder[1];
                            SingleTon.GetRooms()[Tempx, Tempy] = new Room(Tempx, Tempy, false, RNG.Next(0, 101));
                            break;
                        }
                    }
                }

            }



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

        private void CheckRoomConnection() //check where there is unreachable areas
        {
            Room LastusedRoom;
            AllRooms = SingleTon.GetRooms();
            RoomsConnected = new Room[SingleTon.GetRooms().GetLength(0), SingleTon.GetRooms().GetLength(1)];
            LastusedRoom = AllRooms[SingleTon.GetCursor().GetX(), SingleTon.GetCursor().GetY()];
            RoomsConnected[SingleTon.GetCursor().GetX(), SingleTon.GetCursor().GetY()] = AllRooms[SingleTon.GetCursor().GetX(), SingleTon.GetCursor().GetY()];
            for (int i = 0; i < 50; i++)//maybe make it all rooms as amount of times to check or do a while loop to check for when some bool get's check for being stuck
            {
                LastusedRoom = CheckNeightboors(LastusedRoom);
            }
        }

        private Room CheckNeightboors(Room CheckRoom)
        {
            Waypoints Temp = new Waypoints(CheckRoom.X, CheckRoom.Y);
            if ((AllRooms[CheckRoom.X + 1, CheckRoom.Y] != null) && (RoomsConnected[CheckRoom.X, CheckRoom.Y] == null))
            {
                Temp.ToggleNorth();
            }

            if((AllRooms[CheckRoom.X - 1, CheckRoom.Y] != null) && (RoomsConnected[CheckRoom.X, CheckRoom.Y] == null))
            {
                Temp.ToggleSouth();
            }

            if ((AllRooms[CheckRoom.X, CheckRoom.Y + 1] != null) && (RoomsConnected[CheckRoom.X, CheckRoom.Y] == null))
            {
                Temp.ToggleEast();
            }

            if((AllRooms[CheckRoom.X, CheckRoom.Y - 1]!= null) && (RoomsConnected[CheckRoom.X, CheckRoom.Y] == null))
            {
                Temp.ToggleWest();
            }

            int Amount = 0;

            foreach (bool element in Temp.ReturnDirecetions())
            {
                if(element)
                {
                    Amount++;
                }
            }

            if(Amount == 2 || Amount == 3)
            {
                
            }
            else if(Amount == 1)
            {
                switch(Temp.GetSingleDirection())
                {
                    case Direction.North:
                        RoomsConnected[CheckRoom.X + 1, CheckRoom.Y] = AllRooms[CheckRoom.X + 1, CheckRoom.Y];
                        return AllRooms[CheckRoom.X + 1, CheckRoom.Y];

                    case Direction.South:
                        RoomsConnected[CheckRoom.X - 1, CheckRoom.Y] = AllRooms[CheckRoom.X - 1, CheckRoom.Y];
                        return AllRooms[CheckRoom.X - 1, CheckRoom.Y];

                    case Direction.East:
                        RoomsConnected[CheckRoom.X, CheckRoom.Y + 1] = AllRooms[CheckRoom.X, CheckRoom.Y + 1];
                        return AllRooms[CheckRoom.X, CheckRoom.Y + 1];

                    case Direction.West:
                        RoomsConnected[CheckRoom.X, CheckRoom.Y - 1] = AllRooms[CheckRoom.X, CheckRoom.Y - 1];
                        return AllRooms[CheckRoom.X, CheckRoom.Y - 1];


                }
            }
            else
            {

                //find new room from waypoints
            }
        }

        private int[] GivePassageRooms()//Create Passages between rooms
        {
            throw new System.Exception("This feature is not yet to be implamented");
            return new int[] { 0, 1 };
        }

    }

    class Waypoints
    {
        int X;
        int Y;

        List<bool> ArrayOfDirecetions = new List<bool>() {false, false, false, false};

        public Waypoints(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void ToggleNorth()
        {
            ArrayOfDirecetions[0] = true;
        }

        public void ToggleSouth()
        {
            ArrayOfDirecetions[1] = true;
        }


        public void ToggleEast()
        {
            ArrayOfDirecetions[2] = true;
        }

        public void ToggleWest()
        {
            ArrayOfDirecetions[3] = true;
        }

        public bool[] ReturnDirecetions()
        {
            return ArrayOfDirecetions.ToArray();
        }

        public Direction PickRandomOpenDirection()
        {
            switch(ArrayOfDirecetions.FindIndex(x => x.Equals(true)))
            {

            }
        }

        public Direction GetSingleDirection()
        {
            switch(ArrayOfDirecetions.FindIndex(x => x.Equals(true)))
            {
                case 0:
                    return Direction.North;

                case 1:
                    return Direction.South;

                case 2:
                    return Direction.East;

                default:
                    return Direction.West;
            }
        }

    }
}

