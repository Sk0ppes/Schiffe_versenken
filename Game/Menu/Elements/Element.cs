using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
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
