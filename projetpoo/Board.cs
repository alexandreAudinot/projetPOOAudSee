using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public interface Board
    {
        Tile getTile(Position p);
        void initVarBoard();
    }
}
