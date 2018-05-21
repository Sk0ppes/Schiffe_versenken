using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
{
    class Label : Element
    {
        private string title;

        public Label(Vector2 location, string title) : base(location) { this.title = title; }

        public override void Draw(bool hovered)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(title);
        }

        public override void Update() { }

        public override void OnEnter() { }
    }
}
