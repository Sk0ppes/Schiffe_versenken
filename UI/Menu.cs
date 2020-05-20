using System;
using System.Collections.Generic;
using System.Numerics;
using Battleships.UI.Elements;

namespace Battleships.UI
{
    abstract class Menu
    {
        protected List<Element> elements;
        protected int selection;
        protected bool show = true;
        private Vector2 size;

        public Menu(Vector2 size)
        {
            this.size = size;
            this.elements = new List<Element>();
        }

        public virtual void Open(bool clear)
        {
            if(clear)
                Console.Clear();
            do
            {
                Draw();
                Update();
            }
            while (show);
        }

        public virtual void Update()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    if (selection > 0)
                        selection -= 1;
                    break;
                case ConsoleKey.S:
                    if (selection < elements.Count - 1)
                        selection += 1;
                    break;
                case ConsoleKey.Enter:
                    OnEnter();
                    break;
                case ConsoleKey.Escape:
                    Close();
                    break;
            }
        }

        public void Draw()
        {
            ConsoleColor oldColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int y = 0; y < size.Y; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(new string(' ', (int)size.X));
            }

            for (int i = 0; i < elements.Count; i++)
                elements[i].Draw(i == selection);
            Console.BackgroundColor = oldColor;
        }

        private void OnEnter()
        {
            elements[selection].OnEnter();
        }

        protected void Close()
        {
            show = false;
        }
    }
}
