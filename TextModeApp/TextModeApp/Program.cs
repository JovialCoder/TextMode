using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextModeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            GameWorld.StartGame();
            GameWorld.CreateCharacter();
            GameWorld.ListRoom("The air is slightly stale.");
            GameWorld.ParseInput();

            
        }

        
    }
}
