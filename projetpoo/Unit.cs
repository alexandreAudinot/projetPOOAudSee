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
        public abstract bool makeAMove(Tile p);
        public abstract bool fight(Position p);

        public void die()
        {
            this.controler.killUnit(this);
        }

        public bool move(Tile p)
        {
            List<Unit> elem = World.getUnit(p.getPosition()); //fouille le world pour savoir s'il y a quelqu'un
            if (elem.Any())
            {
                return makeAMove(p);
            }
            else
            {
                if (elem.Count == 1)
                {
                    //fight(p,get) changer fight pour qu'il prenne un unit
                }
            }
            return false;
        }

        public abstract void winFight();
    }
}
