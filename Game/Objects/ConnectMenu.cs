using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SchiffeFicken
{
    class ConnectMenu : Menu
    {
        string Address = "";
        string Port = "";
        private int xOff = 1, yOff = 1;

        public override void Open()
        {
            options = new string[] {
                "IP: ",
                "PORT: ",
                "CONFIRM"
            };

            base.Open();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int x = 0; x < 21; x++)
                for (int y = 0; y < 5; y++)
                {
                    Console.SetCursorPosition(x + xOff, y + yOff);
                    Console.Write(" ");
                }

            Console.ForegroundColor = selection == 0 ? ConsoleColor.White : ConsoleColor.Gray;
            Console.SetCursorPosition(1 + xOff, 1 + yOff);
            Console.Write("IP: " + Address);

            Console.ForegroundColor = selection == 1 ? ConsoleColor.White : ConsoleColor.Gray;
            Console.SetCursorPosition(1 + xOff, 2 + yOff);
            Console.Write("PORT: " + Port);

            Console.ForegroundColor = selection == 2 ? ConsoleColor.White : ConsoleColor.Gray;
            Console.SetCursorPosition(1 + xOff, 3 + yOff);
            Console.Write("confirm");
        }

        protected override void OnEnter()
        {
            switch (selection)
            {
                case 0:
                    Console.SetCursorPosition(5 + xOff, 1 + yOff);
                    Address = Console.ReadLine();
                    break;
                case 1:
                    Console.SetCursorPosition(7 + xOff, 2 + yOff);
                    Port = Console.ReadLine();
                    break;
                case 2:
                    try
                    {
                        Networking.Address = IPAddress.Parse(Address);
                        Networking.Port = Convert.ToInt32(Port);
                        Close();
                    }
                    catch (Exception) { }
                    break;
            }
        }
    }
}
