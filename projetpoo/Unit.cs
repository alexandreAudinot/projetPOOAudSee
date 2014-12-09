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
        protected double nbDeplacement;

        
        protected Unit(Player p, Tile t)
        {
            att = 2;
            def = 1;
            hp = 5;
            controler = p;
            position = t.getPosition();
            nbDeplacement = 0;
        }

        protected void initDeplacement()
        {
            nbDeplacement = 2 ; //TOCHECK
        }
        
        private Player controler{get;set;}
        protected Position position{get;set;}
        public abstract bool move(Tile t);
        public abstract bool makeAMove(Tile t);
        public abstract bool fight(Tile tile);

        public void die()
        {
            this.controler.killUnit(this);
        }

        public abstract void winFight();
    }
}
