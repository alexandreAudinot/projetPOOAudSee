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
        private int nbDeplacement;

        protected Unit() { } //constructeur non voulu obligatoire pour la compilation ?
        
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

        private Position position{get;set;}

        public abstract void move(Tile t);
        public abstract void attack(Position position);

        public void die()
        {
            this.controler.killUnit(this);
        }

        public abstract void winFight();
    }
}
