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

        protected bool isAlive()
        {
            return hp > 0;
        }
        
        private Player controler{get;set;}
        public Position position{get;set;}
        public abstract void makeAMove(Position p);

        //méthode fight traite le combat de deux unités
        public void fight(Position p, Unit u)
        {
            //le nombre de combats est compris entre 3 et le nombre de points de vie maximum des 2 unités ajouté de 2
            Random rdm = new Random();
            int nbCombats = rdm.Next(3,2 + Math.Max(this.hp,u.hp));
            //calcul des probabilités de combat
            double probAtt = 0;//TODO
            //Sélection de l'attaquant et attaque
            while(this.isAlive() && u.isAlive() && nbCombats > 0)
            {
                if (rdm.Next(0, 100) < probAtt)
                {
                    //l'attaque est pondérée par les points de vie de l'attaquant
                    u.hp -= this.hp * this.att;
                }
                else
                {
                    this.hp -= u.hp * u.att;
                }
            }
            if (nbCombats != 0)
            {
                //cas de mort d'une unité
                if (this.isAlive())
                {
                    u.die();
                    this.winFight();
                } 
                else
                {
                    this.die();
                    u.winFight();
                }
            }
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
