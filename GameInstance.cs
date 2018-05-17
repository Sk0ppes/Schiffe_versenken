using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
{
    class GameInstance
    {
        // Schiffe
        // 2 x 2
        // 3 x 3
        // 4 x 2
        // 5 x 1
        // Feld
        // 10 x 10
        List<Ship> ships = new List<Ship>();

        public void Setup()
        {
            PlaceShip(new Ship(5, Ship.Rotation.Down, new Vector2(0, 0)));
        }

        public void PlaceShip(Ship ship)
        {
            bool placed = false;
            do
            {
                ships.Remove(ship);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        placed = true;
                        break;
                    case ConsoleKey.W:
                        ship.position.y -= 1;
                        break;
                    case ConsoleKey.S:
                        ship.position.y += 1;
                        break;
                    case ConsoleKey.A:
                        ship.position.x -= 2;
                        break;
                    case ConsoleKey.D:
                        ship.position.x += 2;
                        break;
                    case ConsoleKey.E:
                        ship.Rotate(Ship.Rotation.Right);
                        break;
                    case ConsoleKey.Q:
                        ship.Rotate(Ship.Rotation.Left);
                        break;
                }
                ships.Add(ship);
                Draw();
            }
            while (!placed);
        }

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(" " + i);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Write("\n" + "abcdefghij"[i] + "                   ");
            }

            foreach (Ship ship in ships)
            {
                ship.Draw();
            }
        }
    }
}
