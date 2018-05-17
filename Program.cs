using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            GameInstance gameInstance = new GameInstance();
            gameInstance.Setup();
            gameInstance.Draw();
            Console.ReadKey();
        }
    }
}