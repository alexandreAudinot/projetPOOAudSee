using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public interface IUnit
    {
        void move(Position p);
        bool fight(Position p, Unit u);
        void die();
        void makeAMove(Position p);
        void winFight();
    }

}
