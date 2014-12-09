using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public interface IUnit
    {
        void move(Tile t);
        void fight(Tile tile);
        void die();

        void winFight();
    }

}
