using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
{
    class Textbox : Element
    {
        private string Value = "";
        private string Title = "";
        private bool Active = false;

        public Textbox(Vector2 location, string title) : base(location) { this.Title = title; }

        public override void Draw(bool hovered)
        {
            ConsoleColor oldColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            if (Active)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (hovered)
                Console.ForegroundColor = ConsoleColor.White;
            else
                Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(location.x, location.y);
            Console.Write(String.Concat(Enumerable.Repeat(" ", 18 + Title.Length)));
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(Title + ": " + Value);
            Console.BackgroundColor = oldColor;
        }

        public override void Update() { }

        public override void OnEnter()
        {
            Active = true;

            do
            {
                Draw(true);
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        Active = false;
                        Value = "";
                        break;
                    case ConsoleKey.Enter:
                        Active = false;
                        break;
                    case ConsoleKey.Backspace:
                        if(Value.Length != 0)
                            Value = Value.Remove(Value.Length - 1);
                        break;
                    default:
                        if(Value.Length < 16)
                            Value += key.KeyChar;
                        break;
                }
            }
            while (Active);
        }

        public string GetText()
        {
            return Value;
        }
    }
}
