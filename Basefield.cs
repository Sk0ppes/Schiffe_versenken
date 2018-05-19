using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
{
    class Basefield
    {
        public virtual void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < 10; i++)
                Console.Write(" " + i);

            for (int i = 0; i < 10; i++)
                Console.Write("\n" + "abcdefghij"[i] + String.Concat(Enumerable.Repeat(" ", 19)));
        }

        public virtual void Update()
        {

        }

    }
}
