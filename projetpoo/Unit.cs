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
        public int def { get; protected set; }
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
        
        protected Player controler{get;set;}
        public Position position{get;set;}
        public abstract double calcDepl(Position p);
        public abstract double calcDeplAtt(Position p);

        //méthode fight traite le combat de deux unités
        public void fight(Position p, Unit u)
        {
            //le nombre de combats est compris entre 3 et le nombre de points de vie maximum des 2 unités ajouté de 2
            Random rdm = new Random();
            int nbCombats = rdm.Next(3,2 + Math.Max(this.hp,u.hp)) - 1;
            //calcul des probabilités de combat
            double probAtt = (Math.Abs(u.def - this.att) / u.def) * (50) + 50;
            //Sélection de l'attaquant et attaque
            while(this.isAlive() && u.isAlive() && nbCombats > 0)
            {
                nbCombats++;
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
                    //message this.getType().toString() gagne le combat
                    if (u.loseFight())
                    {
                        this.winFightAtt(p);
                    }
                } 
                else
                {
                    //message u.getType().toString() gagne le combat
                    if (this.loseFight())
                    {
                        u.winFightDef(p);
                    }
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
                this.makeAMove(p,this.calcDepl(p));
            }
            else
            {
                this.makeAMove(p, this.calcDeplAtt(p));
                this.fight(p, elem);
            }
        }

        public void makeAMove(Position p, double depl)
        {
            //mise à jour de nbDeplacement
            nbDeplacement -= this.calcDepl(p);
            position.setPosition(p);
        }

        public abstract void winFight(Position p);
        public abstract bool loseFight();


        //winFightAtt permet de gérer le combat gagné pour l'attaquant au départ
        //l'unité gagnante doit tenter de se déplacer sur la case de l'unité perdante
        //ce qui n'est pas le cas de l'unité perdante
        public void winFightAtt(Position p)
        {
            if (!World.Instance.unitBool(p))
            {
                double depl = this.nbDeplacement;
                this.initDeplacement();
                this.calcDepl(p);
                this.nbDeplacement = depl;
            }
            this.winFight(p);
        }

        public void winFightDef(Position p)
        {
            this.winFight(p);
        }
    }
}
