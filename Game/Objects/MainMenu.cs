using System;
using System.Threading;
using System.Net;

namespace SchiffeFicken
{
    class MainMenu : Menu
    {
        public override void Open()
        {
            options = new string[] {
                "Host",
                "Join",
                "Exit"
            };

            base.Open();
        }

        public override void Draw()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;

            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < options.Length + 2; y++)
                {
                    Console.SetCursorPosition(x + 1, y + 1);
                    Console.Write(" ");
                }
            }

            for (int i = 0; i < options.Length; i++)
            {
                Console.ForegroundColor = selection == i ? ConsoleColor.White : ConsoleColor.Gray;
                Console.SetCursorPosition(2, i + 2);
                Console.Write(options[i]);
            }
        }

        protected override void OnEnter()
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
                    Close();
                    break;
            }
        }

        private void SetupHost()
        {
            ConnectMenu connection = new ConnectMenu();
            connection.Open();
            Networking.Setup(Networking.State.Host);
            
            new ConnectingMenu().Open();

            Start();
        }

        private void SetupClient()
        {
            ConnectMenu connection = new ConnectMenu();
            connection.Open();
            Networking.Setup(Networking.State.Client);
            
            new ConnectingMenu().Open();

            Start();
        }

        private void Start()
        {
            Game.Setup();
        }
    }
}