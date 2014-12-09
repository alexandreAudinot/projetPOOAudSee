using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public interface IUnit
    {
        bool move(Position p);
        bool fight(Position p);
        void die();
        bool makeAMove(Position p);
        void winFight();
    }

}
