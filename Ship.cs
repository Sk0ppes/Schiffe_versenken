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

        public enum State
        {
            placing,
            placed,
            destroyed
        }

        public int xOff = 0, yOff = 0;
        private State[] status;
        private int length;
        public Vector2 position;
        private Rotation rotation;

        public Ship(int length, Rotation rotation, Vector2 location)
        {
            this.status = new State[length];
            this.length = length;
            this.rotation = rotation;
            this.position = location;

            for (int i = 0; i < status.Length; i++)
                status[i] = State.placing;
        }

        public void Update()
        {
            yOff = 0;
            xOff = 0;

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
            if (position.x + xOff * 2 * (length - 1) < 1)
                position.x = 1 - xOff * 2 * (length - 1);
            if (position.y + yOff * (length - 1) < 1)
                position.y = 1 - yOff * (length - 1);
            if (position.x > 19)
                position.x = 19;
            if (position.x + xOff * 2 * (length - 1) > 19)
                position.x = 19 - xOff * 2 * (length - 1);
            if (position.y > 10)
                position.y = 10;
            if (position.y + yOff * (length - 1) > 10)
                position.y = 10 - yOff * (length - 1);
        }

        public void Draw()
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(position.x + xOff*i*2, position.y + yOff*i);
                ConsoleColor oldColor = Console.ForegroundColor;

                switch(status[i])
                {
                    case State.destroyed:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("█");
                        break;
                    case State.placed:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("█");
                        break;
                    case State.placing:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("█");
                        break;
                }
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

        public bool IsCrossing(Ship ship)
        {
            for(int indexSelf = 0; indexSelf < length; indexSelf++)
            {
                for(int indexTarget = 0; indexTarget < ship.length; indexTarget++)
                {
                    if (position.x + xOff * 2 * indexSelf == ship.position.x + ship.xOff * 2 * indexTarget && position.y + yOff * indexSelf == ship.position.y + ship.yOff * indexTarget)
                        return true;
                }
            }
            return false;
        }

        public bool IsHitting(Vector2 location)
        {
            for (int indexSelf = 0; indexSelf < length; indexSelf++)
            {
                if (position.x + xOff * 2 * indexSelf == location.x && position.y + yOff * indexSelf == location.y)
                {
                    status[indexSelf] = State.destroyed;
                    return true;
                }
            }
            return false;
        }

        public void Place()
        {
            for (int i = 0; i < status.Length; i++)
                status[i] = State.placed;
        }
    }
}
