using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SchiffeFicken
{
    class ConnectingMenu : Menu
    {
        private static Vector2 size = new Vector2(16, 3);

        public ConnectingMenu() : base(size)
        {
            elements.Add(new Label(new Vector2(3, 1), "Connecting..."));
        }

        public override void Update()
        {
            Thread.Sleep(500);
            if (Networking.connected || Networking.error)
                Close();
        }
    }
}
