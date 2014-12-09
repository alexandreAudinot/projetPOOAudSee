using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public interface IUnit
    {
        bool move(Tile t);
        bool fight(Tile tile);
        void die();
        bool makeAMove(Tile t);
        void winFight();
    }

}
