using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
{
    class Ship
    {
        public enum Rotation
        {
            Up,
            Down,
            Left,
            Right
        }

        private bool[] status;
        private int length;
        public Vector2 position;
        private Rotation rotation;

        public Ship(int length, Rotation rotation, Vector2 location)
        {
            status = new bool[length];
            this.length = length;
            this.rotation = rotation;
            this.position = location;
        }

        public void Draw()
        {
            int xOff = 0, yOff = 0;
            switch (rotation)
            {
                case Rotation.Down:
                    yOff = 1;
                    break;
                case Rotation.Up:
                    yOff = -1;
                    break;
                case Rotation.Right:
                    xOff = 1;
                    break;
                case Rotation.Left:
                    xOff = -1;
                    break;
            }

            if (position.x < 1)
                position.x = 1;
            if (position.y < 1)
                position.y = 1;
            if (position.x + xOff * 2 * (length-1) < 1)
                position.x = 1 - xOff * 2 * (length-1);
            if (position.y + yOff * (length - 1) < 1)
                position.y = 1 - yOff * (length - 1);

            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(position.x + xOff*i*2, position.y + yOff*i);
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = status[i] ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write("X");
                Console.ForegroundColor = oldColor;
            }
        }

        public void Rotate(Rotation rotation)
        {
            if(rotation == Rotation.Left)
            {
                switch(this.rotation)
                {
                    case Rotation.Up:
                        this.rotation = Rotation.Left;
                        break;
                    case Rotation.Left:
                        this.rotation = Rotation.Down;
                        break;
                    case Rotation.Down:
                        this.rotation = Rotation.Right;
                        break;
                    case Rotation.Right:
                        this.rotation = Rotation.Up;
                        break;
                }
            }
            else if(rotation == Rotation.Right)
            {
                switch (this.rotation)
                {
                    case Rotation.Up:
                        this.rotation = Rotation.Right;
                        break;
                    case Rotation.Right:
                        this.rotation = Rotation.Down;
                        break;
                    case Rotation.Down:
                        this.rotation = Rotation.Left;
                        break;
                    case Rotation.Left:
                        this.rotation = Rotation.Up;
                        break;
                }
            }
        }
    }
}
