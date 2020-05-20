using System;
using System.Numerics;
using Battleships.Net;

namespace Battleships.Gamefield
{
    class Bomb
    {
        Vector2 position;
        bool IsHit = false;

        public Bomb(Vector2 position)
        {
            this.position = position;
            Hit();
        }

        public Bomb(Vector2 position, bool IsHit)
        {
            this.position = position;
            this.IsHit = IsHit;
        }

        public void Draw()
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.SetCursorPosition((int)position.X, (int)position.Y);
            Console.ForegroundColor = IsHit ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write("X");
            Console.ForegroundColor = oldColor;
        }

        public void Hit()
        {
            Networking.SendMessage("game:attack(" + position.X + "," + position.Y + ")");
            IsHit = Networking.GetBool();
        }
    }
}
