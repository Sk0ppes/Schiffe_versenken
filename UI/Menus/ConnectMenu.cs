using System;
using System.Net;
using System.Numerics;
using Battleships.Net;
using Battleships.UI.Elements;

namespace Battleships.UI.Menus
{
    class ConnectMenu : Menu
    {
        private static Vector2 size = new Vector2(26, 5);

        public ConnectMenu() : base(size)
        {
            elements.Add(new Textbox(new Vector2(3, 1), "IP"));
            elements.Add(new Textbox(new Vector2(3, 2), "PORT"));
            elements.Add(new Button(new Vector2(3, 3), Connect, "Confirm"));
        }

        public void Connect()
        {
            try
            {
                Networking.Address = IPAddress.Parse(((Textbox)elements[0]).GetText());
                Networking.Port = Convert.ToInt32(((Textbox)elements[1]).GetText());
                Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
