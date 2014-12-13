using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class Tile
    {
        private Position p;
        public Position getPosition()
        {
            return p;
        }

        public Tile(Position p0)
        {
            p = p0;
        }
    }
}
