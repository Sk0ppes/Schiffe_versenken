using System.Numerics;

namespace Battleships.UI.Elements
{
    abstract class Element
    {
        protected Vector2 location;

        public Element(Vector2 location)
        {
            this.location = location;
        }

        public abstract void Draw(bool hovered);
        public abstract void Update();
        public abstract void OnEnter();
    }
}
