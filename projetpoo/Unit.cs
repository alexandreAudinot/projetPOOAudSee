using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public abstract class Unit : ProjetPOO.IUnit
    {
        public int att { get; private set; }
        public int def { get; private set; }
        public int hp { get; private set; }
        protected double nbDeplacement { get; set; }

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
        public Position position{get;set;}
        public abstract void makeAMove(Position p);

        public void fight(Position p, Unit u)
        {

        }

        public void die()
        {
            this.controler.killUnit(this);
        }

        //La méthode move détermine si l'évènement est un déplacement ou un combat et fait l'appel le cas échéant
        public void move(Position p)
        {
            Unit elem = World.Instance.getUnit(p); 
            if (elem == null)
            {
                this.makeAMove(p);
            }
            else
            {
                this.fight(p, elem);
            }
        }

        public abstract void winFight();
    }
}
