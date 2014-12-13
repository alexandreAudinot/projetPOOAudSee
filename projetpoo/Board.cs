using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public interface Board
    {
        ITile[,] ITile
        {
            get;
        }

        Tile getTile(Position p);
        void initBoard();
        void initVarBoard();
    }
}
