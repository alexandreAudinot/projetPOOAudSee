using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public interface IUnit
    {
        bool move(Tile p);
        bool fight(Position p);
        void die();
        bool makeAMove(Tile p);
        void winFight();
    }

}
