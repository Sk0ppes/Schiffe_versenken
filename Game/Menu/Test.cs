using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
{
    class Test
    {
        Element[] elements;
        int selection = 0;
        bool show = true;

        public Test()
        {
            elements = new Element[]
            {
                new Button(new Vector2(1, 1), SetupHost, "Host"),
                new Button(new Vector2(1, 2), SetupClient, "Join"),
                new Button(new Vector2(1, 3), Close, "Exit")
            };

            do
            {
                Draw();
                Update();
            }
            while (show);
        }

        public virtual void Update()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    if (selection > 0)
                        selection -= 1;
                    break;
                case ConsoleKey.S:
                    if (selection < elements.Length - 1)
                        selection += 1;
                    break;
                case ConsoleKey.Enter:
                    OnEnter();
                    break;
                case ConsoleKey.Escape:
                    Close();
                    break;
            }
        }

        public void Draw()
        {
            for (int i = 0; i < elements.Length; i++)
                elements[i].Draw(i == selection);
        }

        private void OnEnter()
        {
            elements[selection].OnEnter();
        }

        protected void Close()
        {
            show = false;
        }

        private void SetupHost()
        {
            ConnectMenu connection = new ConnectMenu();
            connection.Open(true);
            Networking.Setup(Networking.State.Host);

            new ConnectingMenu().Open(true);

            Start();
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

        private void Start()
        {
            Game.Setup();
        }
    }
}
