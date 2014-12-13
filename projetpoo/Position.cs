using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }

        public void setPosition(Position pos)
        {
            x = pos.x;
            y = pos.y;
        }

        public Boolean equals(Position p)
        {
            return ((p.x == this.x) && (p.y == this.y));
        }
    }
}
