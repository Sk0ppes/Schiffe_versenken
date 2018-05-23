using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
{
    class Button : Element
    {
        private Action action;
        private string title;

        public Button(Vector2 location, Action action, string title) : base(location)
        {
            this.action = action;
            this.title = title;
        }

        public override void Draw(bool hovered)
        {
            if (hovered)
                Console.ForegroundColor = ConsoleColor.White;
            else
                Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(location.x, location.y);
            Console.Write(title);
        }

        public override void Update() { }

        public override void OnEnter()
        {
            action();
        }
    }
}
