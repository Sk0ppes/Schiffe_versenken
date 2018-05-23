using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
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
            for (int y = 0; y < size.y; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(new string(' ', size.x));
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
