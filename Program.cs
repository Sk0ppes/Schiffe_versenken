using System;

namespace SchiffeFicken
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            MainMenu menu = new MainMenu();
            menu.Open(true);
        }
    }
}