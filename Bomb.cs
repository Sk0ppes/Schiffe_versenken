using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
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
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = IsHit ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write("X");
            Console.ForegroundColor = oldColor;
        }

        public void Hit()
        {
            Networking.SendMessage("game:attack(" + position.x + "," + position.y + ")");
            IsHit = Networking.GetBool();
        }
    }
}
