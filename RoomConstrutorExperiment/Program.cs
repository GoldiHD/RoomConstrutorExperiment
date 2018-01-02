using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomConstrutorExperiment
{
    class Program
    {
        Room[,] Rooms;
        int X;
        string XInput;
        int Y;
        string YInput;
        int AmountOfRooms;
        string InputAmountOfRooms;
        Random RNG = new Random();

        static void Main(string[] args){new Program().Start();}

        public void Start()
        {

            Console.WriteLine("Hello and welcome to this demostartion");
            Console.Write("What should the X size of the map be: ");
            XInput = Console.ReadLine();
            if( !(int.TryParse(XInput, out X)))
            {
               X = Redo();
            }
            Console.Clear();
            Console.Write("What should the Y size of the map be: ");
            YInput = Console.ReadLine();
            if ( !(int.TryParse(YInput, out Y)))
            {
                Y = Redo();
            }
            Console.Clear();
            Console.Write("How many rooms would you like to be created: ");
            InputAmountOfRooms = Console.ReadLine();
            if(!(int.TryParse(InputAmountOfRooms, out AmountOfRooms)))
            {
                AmountOfRooms = Redo();
            }
            Console.Clear();
            Rooms = new Room[X, Y];
            PopulateRooms(AmountOfRooms);
            DrawArray();
            if(Console.ReadKey().Key == ConsoleKey.Spacebar || Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Start();
            }
            
        }

        private int Redo()
        {
            int ReturnValue;
            Console.Clear();
            Console.WriteLine("Please give a valid input in form of a whole number");
            if(!(int.TryParse(Console.ReadLine(), out ReturnValue)))
            {
                ReturnValue = Redo();
            }
            return ReturnValue;
        }

        private void DrawArray()
        {
            Console.WriteLine();
            Console.WriteLine("X: " + X);
            Console.WriteLine("Y: " + Y);
            Console.WriteLine("Rooms: " + AmountOfRooms);
            Console.Write("\n\n\n\n\n");
            for(int i = 0; i < Rooms.GetLength(0); i++)
            {
                Console.Write("        ");
                for(int x = 0; x < Rooms.GetLength(1); x++)
                {
                    if(Rooms[i,x] == null)
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
                Console.WriteLine();
            }
        }

        private void PopulateRooms(int roomstoconstruct)
        {
            List<int> Postions;
            int Tempx = RNG.Next(0, Rooms.GetLength(0));
            int Tempy = RNG.Next(0, Rooms.GetLength(1));
            int tempPicked;
            bool FoundASpot;
            Rooms[Tempx, Tempy] = new Room(Tempx, Tempy, true);

            for(int i = 1; i < roomstoconstruct; i++)
            {
                Postions = new List<int> { 0, 1, 2, 3 };
                FoundASpot = false;
                for (int x = 0; x < 4; x++)
                {
                    tempPicked = RNG.Next(0, Postions.Count);
                    switch (tempPicked)
                    {
                        case 0:
                            if((Tempx + 1)  < (X-1 ) && Rooms[(Tempx + 1),Tempy] == null)
                            {
                                Tempx++;
                                Rooms[Tempx, Tempy] = new Room(Tempx, Tempy, false);
                                FoundASpot = true;                                
                            }
                            else
                            {
                                Postions.Remove(tempPicked);
                            }
                            break;

                        case 1:
                            if ((Tempx - 1) > -1 && Rooms[(Tempx -1), Tempy] == null)
                            {
                                Tempx--;
                                Rooms[Tempx, Tempy] = new Room(Tempx, Tempy, false);
                                FoundASpot = true;
                            }
                            else
                            {
                                Postions.Remove(tempPicked);
                            }
                            break;

                        case 2:
                            if ((Tempy + 1) < (Y - 1) && Rooms[Tempx,(Tempy + 1)] == null)
                            {
                                Tempy++;
                                Rooms[Tempx, Tempy] = new Room(Tempx, Tempy, false);
                                FoundASpot = true;
                            }
                            else
                            {
                                Postions.Remove(tempPicked);
                            }
                            break;

                        case 3:
                            if ((Tempy - 1) > -1 && Rooms[Tempx, (Tempy - 1)] == null)
                            {
                                Tempy--;
                                Rooms[Tempx, Tempy] = new Room(Tempx, Tempy, false);
                                FoundASpot = true;
                            }
                            else
                            {
                                Postions.Remove(tempPicked);
                            }
                            break;
                    }
                    if(FoundASpot == true)
                    {
                        break;
                    }
                    else if(x == 3) 
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
                            Rooms[Tempx, Tempy] = new Room(Tempx, Tempy, false);
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
            while(true)
            {
                tempx = RNG.Next(0, Rooms.GetLength(0));
                tempy = RNG.Next(0, Rooms.GetLength(1));
                if(Rooms[tempx, tempy] != null)
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
                tempx = RNG.Next(0, Rooms.GetLength(0));
                tempy = RNG.Next(0, Rooms.GetLength(1));
                if (Rooms[tempx, tempy] == null)
                {
                    return new int[2] { tempx, tempy };
                }
            }
        }
    }
}
