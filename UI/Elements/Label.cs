using System;
using System.Numerics;

namespace Battleships.UI.Elements
{
    class Label : Element
    {
        private string title;

        public Label(Vector2 location, string title) : base(location)
        {
            this.title = title;
        }

        public override void Draw(bool hovered)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition((int)location.X, (int)location.Y);
            Console.Write(title);
        }

        public override void Update() { }

        public override void OnEnter() { }
    }
}
