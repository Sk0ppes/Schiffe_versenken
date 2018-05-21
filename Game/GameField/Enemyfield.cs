using System;
using System.Collections.Generic;
using System.Threading;

namespace SchiffeFicken
{
    class Enemyfield : Basefield
    {
        Selector selector = new Selector(new Vector2(1, 1));
        List<Bomb> bombs = new List<Bomb>();

        // Gets called when other Player has moved
        public void Move()
        {
            bool ready = false;
            selector.Show();
            Draw();
            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        ready = true;
                        break;
                    case ConsoleKey.W:
                        selector.position.y -= 1;
                        break;
                    case ConsoleKey.S:
                        selector.position.y += 1;
                        break;
                    case ConsoleKey.A:
                        selector.position.x -= 2;
                        break;
                    case ConsoleKey.D:
                        selector.position.x += 2;
                        break;
                }
                Update();
                Draw();
            }
            while (!ready);
            selector.Hide();

            bombs.Add(new Bomb(new Vector2(selector.position.x, selector.position.y)));
            Draw();
            Thread.Sleep(1000);
            Networking.SendMessage("game:yourmove()");
        }

        public override void Update()
        {
            base.Update();

            selector.Update();
        }

        public override void Draw()
        {
            base.Draw();

            foreach (Bomb b in bombs)
                b.Draw();
            selector.Draw();
        }
    }
}
