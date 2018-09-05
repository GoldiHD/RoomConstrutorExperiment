using RoomConstrutorExperiment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomConstrutorExperiment.Generation
{
    class Menu
    {
        string XInput;
        string YInput;
        string InputAmountOfRooms;
        int X;
        int Y;
        int AmountOfRooms;
        Random RNG = new Random();
        bool refresh = false;

        public void Startup()
        {
            Console.WriteLine("Hello and welcome to this demostartion");
            Console.Write("What should the X size of the map be: ");
            XInput = Console.ReadLine();
            if (!(int.TryParse(XInput, out X)))
            {
                X = Redo();
            }
            Console.Clear();
            Console.Write("What should the Y size of the map be: ");
            YInput = Console.ReadLine();
            if (!(int.TryParse(YInput, out Y)))
            {
                Y = Redo();
            }
            Console.Clear();
            Console.Write("How many rooms would you like to be created: ");
            InputAmountOfRooms = Console.ReadLine();
            if (!(int.TryParse(InputAmountOfRooms, out AmountOfRooms)))
            {
                AmountOfRooms = Redo();
            }
            Console.Clear();
            SingleTon.SetUpRooms(X, Y);
            new GenerateRooms().GenerateWorld(AmountOfRooms);
            new GameControler().GamePlay();
            
            /*
            Rooms = new Room[X, Y];
            PopulateRooms(AmountOfRooms);
            DrawArray();
            while (true)
            {
                KeyCommands(Console.ReadKey().Key);
            }
            */
        }


        

        private int Redo()
        {
            int ReturnValue;
            Console.Clear();
            Console.WriteLine("Please give a valid input in form of a whole number");
            if (!(int.TryParse(Console.ReadLine(), out ReturnValue)))
            {
                ReturnValue = Redo();
            }
            return ReturnValue;
        }

    }
}
