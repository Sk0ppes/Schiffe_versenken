using System.Numerics;
using System.Threading;
using Battleships.Net;
using Battleships.UI.Elements;

namespace Battleships.UI.Menus
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
