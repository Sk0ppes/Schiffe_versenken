using System;
using System.Numerics;
using Battleships.UI.Elements;
using Battleships.Net;

namespace Battleships.UI.Menus
{
    class MainMenu : Menu
    {
        private static Vector2 size = new Vector2(16, 5);

        public MainMenu() : base(size)
        {
            elements.Add(new Button(new Vector2(1, 1), SetupHost, "Host"));
            elements.Add(new Button(new Vector2(1, 2), SetupClient, "Join"));
            elements.Add(new Button(new Vector2(1, 3), Close, "Exit"));
        }

        private void SetupHost()
        {
            ConnectMenu connection = new ConnectMenu();
            connection.Open(true);
            Networking.Setup(Networking.State.Host);
            
            new ConnectingMenu().Open(true);
            if (!Networking.error)
                Start();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        private void SetupClient()
        {
            ConnectMenu connection = new ConnectMenu();
            connection.Open(true);
            Networking.Setup(Networking.State.Client);
            
            new ConnectingMenu().Open(true);
            if (!Networking.error)
                Start();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        private static void Start()
        {
            Game.Setup();
        }
    }
}