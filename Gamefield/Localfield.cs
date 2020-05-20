using System;
using System.Collections.Generic;
using System.Numerics;

namespace Battleships.Gamefield
{
    class Localfield : Basefield
    {
        private List<Ship> ships = new List<Ship>();
        private List<Bomb> bombs = new List<Bomb>();

        public override void Update()
        {
            base.Update();

            foreach (Ship ship in ships)
                ship.Update();
        }

        public override void Draw()
        {
            base.Draw();

            foreach (Ship ship in ships)
                ship.Draw();
            foreach (Bomb bomb in bombs)
                bomb.Draw();
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
                        ship.position.Y -= 1;
                        break;
                    case ConsoleKey.S:
                        ship.position.Y += 1;
                        break;
                    case ConsoleKey.A:
                        ship.position.X -= 2;
                        break;
                    case ConsoleKey.D:
                        ship.position.X += 2;
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

        // Gets called when other Player has attacked
        public bool Attack(Vector2 location)
        {
            foreach (Ship ship in ships)
                if (ship.IsHitting(location))
                {
                    Draw();
                    return true;
                }
            bombs.Add(new Bomb(location, false));
            Draw();
            return false;
        }

        public bool IsAlive()
        {
            foreach (Ship ship in ships)
                if (ship.IsAlive())
                    return true;

            return false;
        }
    }
}
