using RoomConstrutorExperiment.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomConstrutorExperiment
{
    class GameControler
    {
        private bool KeepRunning = true;
        GenerateRooms GenerateRooms = new GenerateRooms();
        Grapichs Screen = new Grapichs();
        ConsoleKeyInfo CurrentInput;
        Controls controls = new Controls();

        public void GamePlay()
        {
            Screen.DrawMap();
            while(KeepRunning)
            {
                CurrentInput = Console.ReadKey();
                if(controls.KeyCommands(CurrentInput.Key))
                {
                    Screen.DrawMap();
                }
            }
        }
    }
}
