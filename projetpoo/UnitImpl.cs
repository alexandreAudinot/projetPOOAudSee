using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class Orc : Unit
    {
        protected Orc(Player p, Tile t) : base(p,t)
        {
            //référence image
        }

        override
        public bool makeAMove(Tile p)
        {
            double deplacementDuTour = 0;
            //On considère qu'il y a personne sur la case (vérifier avant)
            switch (p.GetType().ToString())
            {
                case "Mountain":
                    deplacementDuTour = 1;
                    break;
                case "Forest":
                    deplacementDuTour = 1;
                    break;
                case "Plain":
                    deplacementDuTour = 0.5;
                    break;
                case "Desert":
                    deplacementDuTour = 1;
                    break;
                default:
                    return false;
                    //Type de terrain non matché
            }
            if (deplacementDuTour > nbDeplacement)
            {
                return false;
                //plus assez de mouvements disponibles
            }
            else
            {
                nbDeplacement -= deplacementDuTour;
                position.setPosition(p.getPosition());
                return true;
            }
        }
        override
        public bool fight(Position p)
        {
            //On considère qu'il y a du monde sur la case (vérifier avant)
            return false;

        }

        override
        public void winFight()
        {
            //coder tout
        }

    }

    public class Dwarf : Unit
    {
        protected Dwarf(Player p, Tile t) : base(p,t)
        {
            //référence image
        }

        override
        public bool makeAMove(Tile p)
        {
            double deplacementDuTour = 0;
            //On considère qu'il y a personne sur la case (vérifier avant)
            switch (p.GetType().ToString())
            {
                case "Mountain":
                    deplacementDuTour = 0;
                    break;
                case "Forest":
                    deplacementDuTour = 1;
                    break;
                case "Plain":
                    deplacementDuTour = 0.5;
                    break;
                case "Desert":
                    deplacementDuTour = 1;
                    break;
                default:
                    return false;
                //Type de terrain non matché
            }
            if (deplacementDuTour > nbDeplacement)
            {
                return false;
                //plus assez de mouvements disponibles
            }
            else
            {
                nbDeplacement -= deplacementDuTour;
                position.setPosition(p.getPosition());
                return true;
            }
        }

        override
        public bool fight(Position p)
        {
            //On considère qu'il y a du monde sur la case (vérifier avant)
            return false;

        }

        override
        public void winFight()
        {
            //coder tout
        }
    }

    public class Elf : Unit
    {
        protected Elf(Player p, Tile t) : base(p, t)
        {
            //référence image
        }

        override
        public bool makeAMove(Tile p)
        {
            double deplacementDuTour = 0;
            //On considère qu'il y a personne sur la case (vérifier avant)
            switch(p.GetType().ToString())
            {
                case "Mountain" :
                    deplacementDuTour = 1;
                    break;
                case "Forest":
                    deplacementDuTour = 0.5;
                    break;
                case "Plain":
                    deplacementDuTour = 1;
                    break;
                case "Desert":
                    deplacementDuTour = 2;
                    break;
                default :
                    return false;
                //Type de terrain non matché
            }
            if (deplacementDuTour > nbDeplacement)
            {
                return false;
                //plus assez de mouvements disponibles
            }
            else
            {
                nbDeplacement -= deplacementDuTour;
                position.setPosition(p.getPosition());
                return true;
            }
        }

        override
        public bool fight(Position p)
        {
            //On considère qu'il y a du monde sur la case (vérifier avant)
            return false;

        }

        override
        public void winFight()
        {
            //coder tout
        }
    }
}
