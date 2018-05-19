using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
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
            if (position.x < 1)
                position.x = 1;
            if (position.y < 1)
                position.y = 1;
            if (position.x > 19)
                position.x = 19;
            if (position.y > 10)
                position.y = 10;
        }

        public void Draw()
        {
            if (!Visible)
                return;
            Console.SetCursorPosition(position.x, position.y);
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
