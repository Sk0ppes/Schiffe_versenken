using System;
using System.Linq;

namespace SchiffeFicken
{
    class Basefield
    {
        public virtual void Draw()
        {
            ShowHelp();

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < 10; i++)
                Console.Write(" " + i);

            for (int i = 0; i < 10; i++)
                Console.Write("\n" + "abcdefghij"[i] + String.Concat(Enumerable.Repeat(" ", 19)));
        }

        public virtual void Update()
        {

        }

        private void ShowHelp()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.White;

            int xLen = 30, yLen = 7;

            for (int x = 0; x < xLen; x++)
                for (int y = 0; y < yLen; y++)
                {
                    Console.SetCursorPosition(x + 21, y + 1);
                    Console.Write(" ");
                }

            Console.SetCursorPosition(21, 1);
            Console.Write("WASD\t- Move");

            Console.SetCursorPosition(21, 2);
            Console.Write("QE\t\t- Rotate");

            Console.SetCursorPosition(21, 3);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t- Moving Ship");

            Console.SetCursorPosition(21, 4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t- Normal Ship");

            Console.SetCursorPosition(21, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t- Destroyed Ship");

            Console.SetCursorPosition(21, 6);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("X");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t- Bomb hitted");

            Console.SetCursorPosition(21, 7);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("X\t\t- Bomb missed");
        }

    }
}
