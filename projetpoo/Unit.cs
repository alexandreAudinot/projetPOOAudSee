using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public abstract class Unit : ProjetPOO.IUnit
    {
        private int att;
        private int def;
        private int hp;

        private Player controler{get;set;}

        private Position position{get;set;}

        public abstract void move();
        public abstract void attack(Position position);

        public void die()
        {
            this.controler.killUnit(this);
        }

        public abstract void winFight();

        public abstract void init();
    }
}
