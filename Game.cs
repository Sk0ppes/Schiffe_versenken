using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
{
    class Game
    {
        // Schiffe
        // 2 x 2
        // 3 x 3
        // 4 x 2
        // 5 x 1
        // Feld
        // 10 x 10
        private static Ship[] ShipsToPlace = {
            new Ship(2, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(2, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(3, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(3, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(3, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(4, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(4, Ship.Rotation.Down, new Vector2(1, 1)),
            new Ship(5, Ship.Rotation.Down, new Vector2(1, 1))
        };
        
        private static bool InGame = false;
        private static Basefield activeField;

        public static void Setup()
        {
            activeField = new Localfield();
            activeField.Draw();

            foreach (Ship ship in ShipsToPlace)
                ((Localfield)activeField).PlaceShip(ship);
            Networking.SendMessage("game:ready");
        }

        // Gets called when both Players are ready
        public static void Start()
        {
            InGame = true;
        }

        public static void EndGame(string reason)
        {
            InGame = false;
            Networking.SendMessage("game:end(" + reason + ")");
        }
    }
}
