using System;
using System.Threading;
using System.Net;

namespace SchiffeFicken
{
    class Menu
    {
        bool running = true;
        int selection;
        string[] menus = {
            "Host",
            "Join",
            "Exit"
        };

        IPAddress address;
        int Port;

        public void Show()
        {
            do
            {
                DrawMenu();
                Update();
            }
            while (running);
        }

        public void Update()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    if (selection > 0)
                        selection -= 1;
                    break;
                case ConsoleKey.S:
                    if (selection < menus.Length - 1)
                        selection += 1;
                    break;
                case ConsoleKey.Enter:
                    OnEnter();
                    break;
            }
        }

        public void DrawMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;

            for (int x = 0; x < 6; x++)
                for (int y = 0; y < menus.Length + 2; y++)
                {
                    Console.SetCursorPosition(x + 1, y + 1);
                    Console.Write(" ");
                }

            for (int i = 0; i < menus.Length; i++)
            {
                Console.ForegroundColor = selection == i ? ConsoleColor.White : ConsoleColor.Gray;
                Console.SetCursorPosition(2, i + 2);
                Console.Write(menus[i]);
            }
        }

        public void DrawConnect()
        {
            int xOff = 1, yOff = 1;
            bool ready = false;
            int selection = 0;
            string ip = "", port = "";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            do
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                for (int x = 0; x < 21; x++)
                    for (int y = 0; y < 5; y++)
                    {
                        Console.SetCursorPosition(x + xOff, y + yOff);
                        Console.Write(" ");
                    }

                Console.ForegroundColor = selection == 0 ? ConsoleColor.White : ConsoleColor.Gray;
                Console.SetCursorPosition(1 + xOff, 1 + yOff);
                Console.Write("IP: " + ip);

                Console.ForegroundColor = selection == 1 ? ConsoleColor.White : ConsoleColor.Gray;
                Console.SetCursorPosition(1 + xOff, 2 + yOff);
                Console.Write("PORT: " + port);

                Console.ForegroundColor = selection == 2 ? ConsoleColor.White : ConsoleColor.Gray;
                Console.SetCursorPosition(1 + xOff, 3 + yOff);
                Console.Write("confirm");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        if (selection > 0)
                            selection -= 1;
                        break;
                    case ConsoleKey.S:
                        if (selection < 2)
                            selection += 1;
                        break;
                    case ConsoleKey.Enter:
                        switch(selection)
                        {
                            case 0:
                                Console.SetCursorPosition(5 + xOff, 1 + yOff);
                                ip = Console.ReadLine();
                                break;
                            case 1:
                                Console.SetCursorPosition(7 + xOff, 2 + yOff);
                                port = Console.ReadLine();
                                break;
                            case 2:
                                try
                                {
                                    IPAddress.Parse(ip);
                                    Convert.ToInt32(port);
                                    ready = true;
                                }
                                catch(Exception) { }
                                break;
                        }
                        break;
                }
            }
            while (!ready);

            address = IPAddress.Parse(ip);
            Port = Convert.ToInt32(port);
        }

        public void DrawConnecting()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;

            for (int x = 0; x < 17; x++)
                for (int y = 0; y < 3; y++)
                {
                    Console.SetCursorPosition(x + 1, y + 1);
                    Console.Write(" ");
                }

            Console.SetCursorPosition(3, 2);
            Console.Write("Connecting...");
        }

        private void OnEnter()
        {
            switch(selection)
            {
                case 0:
                    SetupHost();
                    break;
                case 1:
                    SetupClient();
                    break;
                case 2:
                    running = false;
                    break;
            }
        }

        private void SetupHost()
        {
            DrawConnect();
            Networking.Setup(Networking.State.Host, IPAddress.Parse("127.0.0.1"), Port);

            do
            {
                DrawConnecting();
                Thread.Sleep(1000);
            }
            while (!Networking.connected);

            Start();
        }

        private void SetupClient()
        {
            DrawConnect();
            Networking.Setup(Networking.State.Client, address, Port);

            do
            {
                DrawConnecting();
                Thread.Sleep(1000);
            }
            while (!Networking.connected);

            Start();
        }

        private void Start()
        {
            Game.Setup();
        }
    }
}