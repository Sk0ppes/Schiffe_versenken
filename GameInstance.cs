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
        Ship[] ShipsToPlace = {
            new Ship(2, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(2, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(3, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(3, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(3, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(4, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(4, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(5, Ship.Rotation.Down, new Vector2(1, 1))
        };

        public void Setup()
        {
            Draw();

            foreach (Ship ship in ShipsToPlace)
                PlaceShip(ship);

            Attack(new Vector2(1, 1)); // TEST
        }

        public void PlaceShip(Ship ship)
        {
            bool placed = false;
            Update();
            Draw();


            do
            {
                ships.Remove(ship);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        placed = true;
                        foreach (Ship s in ships)
                            if (ship.IsCrossing(s))
                                placed = false;
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
                Update();
                Draw();
            }
            while (!placed);
            ship.Place();
        }

        public void Update()
        {
            foreach(Ship ship in ships)
            {
                ship.Update();
            }
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
                Console.Write("\n" + "abcdefghij"[i] + String.Concat(Enumerable.Repeat(" ", 19)));
            }

            foreach (Ship ship in ships)
            {
                ship.Draw();
            }
        }

        public void Attack(Vector2 location)
        {
            foreach(Ship ship in ships)
            {
                ship.IsHitting(location);
            }
            Draw();
        }
    }
}
