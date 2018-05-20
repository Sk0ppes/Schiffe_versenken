using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
{
    class Menu
    {
        protected int selection = 0;
        protected String[] options;
        protected bool show = true;


        public virtual void Draw() { }
        protected virtual void OnEnter() { }
        protected virtual void Close() { show = false; }

        public virtual void Open()
        {
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
                    if (selection < options.Length - 1)
                        selection += 1;
                    break;
                case ConsoleKey.Enter:
                    OnEnter();
                    break;
            }
        }
    }
}
