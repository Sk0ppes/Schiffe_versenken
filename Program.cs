using System;
using Battleships.UI.Menus;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            if (args.Length == 1)
                if (args[0] == "overpowered")
                {
                    Game.OP = true;
                    Console.Beep(250, 250);
                }

            MainMenu menu = new MainMenu();
            menu.Open(true);
        }
    }
}