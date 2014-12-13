using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class TileImpl : Tile
    {
        public TileImpl(Position p): base(p){}
    }

    public class Plain : Tile
    {
        public Plain(Position p) : base(p) { }
    }

    public class Forest : Tile
    {
        public Forest(Position p) : base(p) { }
    }

    public class Desert : Tile
    {
        public Desert(Position p) : base(p) { }
    }
}
