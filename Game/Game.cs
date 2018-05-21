using System;

namespace SchiffeFicken
{
    class Game
    {
        // Schiffe
        // 2 x 2
        // 3 x 3
        // 4 x 2
        // 5 x 1
        // Feld
        // 10 x 10
        private static Ship[] ShipsToPlace;
        
        private static bool InGame = false;
        private static Basefield activeField;
        private static Localfield localfield;
        private static Enemyfield enemyfield;

        public static void Setup()
        {
            ShipsToPlace = new Ship[] {
                new Ship(2, Ship.Rotation.Down, new Vector2(1, 1)),
                new Ship(2, Ship.Rotation.Down, new Vector2(1, 1)),
                new Ship(3, Ship.Rotation.Down, new Vector2(1, 1)),
                new Ship(3, Ship.Rotation.Down, new Vector2(1, 1)),
                new Ship(3, Ship.Rotation.Down, new Vector2(1, 1)),
                new Ship(4, Ship.Rotation.Down, new Vector2(1, 1)),
                new Ship(4, Ship.Rotation.Down, new Vector2(1, 1)),
                new Ship(5, Ship.Rotation.Down, new Vector2(1, 1))
            };

            localfield = new Localfield();
            enemyfield = new Enemyfield();

            activeField = localfield;
            activeField.Draw();

            foreach (Ship ship in ShipsToPlace)
                ((Localfield)activeField).PlaceShip(ship);
            (activeField).Draw();
            Networking.SendMessage("game:ready");
            Start();
        }
        
        public static void Start()
        {
            while(Networking.GetMessage() != "game:ready")
            {
                if (Networking.error)
                {
                    ShowEndScreen("Lost Connection", false);
                    return;
                }
            }

            InGame = true;

            if(Networking.HostMode == Networking.State.Client)
            {
                activeField = enemyfield;
                enemyfield.Move();
                activeField = localfield;
                activeField.Draw();
            }

            while (InGame)
            {
                string cmd = Networking.GetMessage();

                if (cmd.StartsWith("game:end("))
                {
                    // example: game:end(nomoreships)
                    ShowEndScreen(cmd.Split('(')[1].Split(')')[0], true);
                }
                else if (cmd == "game:yourmove()")
                {
                    if (!localfield.IsAlive())
                        EndGame("No more Ships");
                    else
                    {
                        activeField = enemyfield;
                        enemyfield.Move();
                        activeField = localfield;
                        activeField.Draw();
                    }
                }
                else if (cmd.StartsWith("game:attack("))
                {
                    // example: game:attack(1,2)
                    Vector2 pos = new Vector2(Convert.ToInt32(cmd.Split('(')[1].Split(',')[0]), Convert.ToInt32(cmd.Split(')')[0].Split(',')[1]));
                    Networking.SendBool(localfield.Attack(pos));
                }


                if (Networking.error)
                {
                    ShowEndScreen("Lost Connection", false);
                    InGame = false;
                }
            }
        }

        public static void EndGame(string reason)
        {
            Networking.SendMessage("game:end(" + reason + ")");
            ShowEndScreen(reason, false);
        }

        public static void ShowEndScreen(string reason, bool win)
        {
            InGame = false;
            int xOff = 2, yOff = 2;

            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int x = 0; x < 16; x++)
                for (int y = 0; y < 4; y++)
                {
                    Console.SetCursorPosition(x + xOff, y + yOff);
                    Console.Write(" ");
                }

            Console.SetCursorPosition(1 + xOff, 1 + yOff);
            Console.Write(reason);
            Console.SetCursorPosition(1 + xOff, 2 + yOff);
            Console.Write(win ? "Winner" : "Loser");

            Networking.Close();

            Console.ReadKey(true);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }
    }
}
