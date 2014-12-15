using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class Tile
    {
        public Position position { get; private set; }

        public Tile(Position p0)
        {
            position = p0;
        }
    }
}
