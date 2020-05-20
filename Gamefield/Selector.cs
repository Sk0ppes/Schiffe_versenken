using System;
using System.Numerics;

namespace Battleships.Gamefield
{
    class Selector
    {
        public Vector2 position;
        private bool Visible = false;

        public Selector(Vector2 position)
        {
            this.position = position;
        }

        public void Update()
        {
            if (!Visible)
                return;
            if (position.X < 1)
                position.X = 1;
            if (position.Y < 1)
                position.Y = 1;
            if (position.X > 19)
                position.X = 19;
            if (position.Y > 10)
                position.Y = 10;
        }

        public void Draw()
        {
            if (!Visible)
                return;
            Console.SetCursorPosition((int)position.X, (int)position.Y);
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("X");

            Console.ForegroundColor = oldColor;
        }

        public void Show()
        {
            Visible = true;
        }

        public void Hide()
        {
            Visible = false;
        }
    }
}
