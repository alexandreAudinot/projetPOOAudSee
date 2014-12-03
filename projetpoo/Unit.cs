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

        public void move();
        public void attack(Position position);

        public void die();

        public void winFight();

        public void init();
    }
}
