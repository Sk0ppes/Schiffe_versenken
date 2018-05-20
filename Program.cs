using System;

namespace SchiffeFicken
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Menu menu = new Menu();
            menu.Show();
        }
    }
}