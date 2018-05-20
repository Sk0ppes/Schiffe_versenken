using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SchiffeFicken
{
    class ConnectingMenu : Menu
    {
        public override void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;

            for (int x = 0; x < 17; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Console.SetCursorPosition(x + 1, y + 1);
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition(3, 2);
            Console.Write("Connecting...");
        }

        public override void Update()
        {
            Thread.Sleep(1000);
            if (Networking.connected)
                Close();
        }
    }
}
