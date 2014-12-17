using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class Orc : Unit
    {
        public int pvOrc { get; private set; }

        public Orc(Player p, Tile t) : base(p,t)
        {
            pvOrc = 0;
            //référence image
        }

        //méthode utilisée pour les tests unitaires seulement
        //permet de changer les pv d'un orc
        public void setPvForUnitTest(int h)
        {
            pvOrc = h;
        }

        override
        public double calcDeplAtt(Position p)
        {
            return calcDepl(p);
        }

        //calcDepl effectue le mouvement de la pièce vers la position
        override
        public double calcDepl(Position p)
        {
            double deplacementDuTour = 0;
            //Les coûts de déplacement sont différents selon le type de terrain
            //gettyle TODO
            switch (World.Instance.getTile(p).GetType().ToString())
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
                    throw new Exception("Type de terrain non matché");
            }
            if (deplacementDuTour > nbDeplacement)
            {
                throw new Exception("plus assez de mouvements disponibles");
            }
            return deplacementDuTour;
        }

        public void incPvOrc()
        {
            pvOrc++;
        }

        override
        public void winFight(Position p)
        {
            if (World.Instance.getTile(p).GetType().ToString() != "Forest")
            {
                incPvOrc();
            }
        }

        override
        public bool loseFight()
        {
            this.die();
            return true;
        }

        override
        public void endGame()
        {
            this.controler.score += pvOrc;
        }

    }

    public class Dwarf : Unit
    {
        public Dwarf(Player p, Tile t)
            : base(p, t)
        {
            //référence image
        }

        override
        public double calcDeplAtt(Position p)
        {
            double deplacementDuTour = 0;
            //Les coûts de déplacement sont différents selon le type de terrain
            switch (World.Instance.getTile(p).GetType().ToString())
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
                    throw new Exception("Type de terrain non matché");
            }
            if (deplacementDuTour > nbDeplacement)
            {
                throw new Exception("plus assez de mouvements disponibles");
            }
            return deplacementDuTour;
        }

        override
        public double calcDepl(Position p)
        {
            double deplacementDuTour = 0;
            //Les coûts de déplacement sont différents selon le type de terrain
            switch (World.Instance.getTile(p).GetType().ToString())
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
                    throw new Exception("Type de terrain non matché");
            }
            if (deplacementDuTour > nbDeplacement)
            {
                throw new Exception("plus assez de mouvements disponibles");
            }
            return deplacementDuTour;
        }

        override
        public void winFight(Position p)
        {
            //coder tout
            if (World.Instance.getTile(p).GetType().ToString() != "Plain")
            {
                this.controler.incScore();
            }
        }

        override
        public bool loseFight()
        {
            this.die();
            return false;
        }

        override
        public void endGame() { }
    }

    public class Elf : Unit
    {
        public Elf(Player p, Tile t) : base(p, t)
        {
            //référence image
        }

        //calcDeplAtt gère le déplacement d'une attaque. Il n'est différent que pour le nain.
        //le reste des unités appelle calcdepl
        override
        public double calcDeplAtt(Position p)
        {
            return calcDepl(p);
        }

        override
        public double calcDepl(Position p)
        {
            double deplacementDuTour = 0;
            //Les coûts de déplacement sont différents selon le type de terrain
            switch (World.Instance.getTile(p).GetType().ToString())
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
                default:
                    throw new Exception("Type de terrain non matché");
            }
            if (deplacementDuTour > nbDeplacement)
            {
                throw new Exception("plus assez de mouvements disponibles");
            }
            return deplacementDuTour;
        }

        override
        public void winFight(Position p)
        {
            this.controler.incScore();
        }

        override
        public bool loseFight()
        {
            Random rdm = new Random();
            int prob = rdm.Next(0,2);
            if (prob == 1)
            {
                this.def = 1;
                //repli de l'unité
                //appel du joueur elfe pour qu'il choississe une case non occupée pour se replier (interrompt le tour du premier joueur)
                //call methode controler qui rend une position de repli TODO
                //message l'unité elfe est sauvée et se replie
                this.repli(null); //remplacer par position p de repli
                return false;
            }
            else
            {
                this.die();
                return true;
            }
        }

        public void repli(Position p)
        {
            Unit elem = World.Instance.getUnit(p); 
            if (elem == null)
            {
                //traite le repli d'un elfe : on donne la possibililité de bouger une seule fois
                double depl = this.nbDeplacement;
                int current = World.Instance.currentPlayer;
                World.Instance.currentPlayer = this.controler.numero;

                this.move(p);

                World.Instance.currentPlayer = current;
                this.nbDeplacement = depl;
            }
            else
            {
                throw new Exception("Le repli ne peut se faire que sur des cases non occupées");
            }
        }
        
        override
        public void endGame(){}
    }
}
