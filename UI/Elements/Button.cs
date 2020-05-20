using System;
using System.Numerics;

namespace Battleships.UI.Elements
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

            Console.SetCursorPosition((int)location.X, (int)location.Y);
            Console.Write(title);
        }

        public override void Update() { }

        public override void OnEnter()
        {
            action();
        }
    }
}
