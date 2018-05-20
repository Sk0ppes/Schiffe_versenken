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
        private static Ship[] ShipsToPlace = {
            new Ship(2, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(2, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(3, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(3, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(3, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(4, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(4, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(5, Ship.Rotation.Down, new Vector2(1, 1))
        };
        
        private static bool InGame = false;
        private static Basefield activeField;
        private static Localfield localfield;
        private static Enemyfield enemyfield;

        public static void Setup()
        {
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
            while(Networking.GetMessage() != "game:ready");

            InGame = true;

            while(InGame)
            {
                string cmd = Networking.GetMessage();

                if (cmd.StartsWith("game.end("))
                {
                    // example: game:end(nomoreships)
                    ShowEndScreen(cmd.Split('(')[1].Split(')')[0], true);
                }
                else if (cmd == "game:yourmove()")
                {
                    activeField = enemyfield;
                    enemyfield.Move();
                }
                else if (cmd.StartsWith("game:attack("))
                {
                    // example: game:attack(1,2)
                    Vector2 pos = new Vector2(Convert.ToInt32(cmd.Split('(')[1].Split(',')[0]), Convert.ToInt32(cmd.Split(')')[0].Split(',')[1]));
                    localfield.Attack(pos);
                }
            }
        }

        public static void EndGame(string reason)
        {
            InGame = false;
            Networking.SendMessage("game:end(" + reason + ")");
            ShowEndScreen(reason, false);
        }

        public static void ShowEndScreen(string reason, bool win)
        {
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
        }
    }
}
