using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public abstract class Unit : ProjetPOO.IUnit
    {
        private int att;
        public int def { get; private set; }
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
        public Position position{get;set;}
        public abstract void makeAMove(Position p);
        public abstract bool fight(Position p, Unit u);

        public void die()
        {
            this.controler.killUnit(this);
        }

        public void move(Position p)
        {
            Unit elem = World.Instance.getUnit(p); //fouille le world pour savoir s'il y a quelqu'un
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
        //public abstract double tileDep(Tile t);
    }
}
