using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class Orc : Unit
    {
        public int pvOrc { get; private set; }

        //constructeur de Orc
        public Orc(Player p, Position po) : base(p,po)
        {
            pvOrc = 0;
        }

        override
        //loadUnit permet de charger une unité selon les valeurs données en paramètre
        public void loadUnit(int uatt, int udef, int uhp, int unbDeplacement, int uinitialLife, int opt)
        {
            att = uatt;
            def = udef;
            hp = uhp;
            nbDeplacement = unbDeplacement;
            initialLife = uinitialLife;
            pvOrc = opt;
        }

        //méthode utilisée pour les tests unitaires seulement
        //permet de changer les pv d'un orc
        public void setPvForUnitTest(int h)
        {
            pvOrc = h;
        }

        //calcDeplAtt calcule le déplacement en cas d'attaque de l'orc
        override
        public double calcDeplAtt(Position p)
        {
            return calcDepl(p);
        }

        //calcDepl effectue le mouvement de la pièce vers la position pour les orcs
        override
        public double calcDepl(Position p)
        {
            double deplacementDuTour = 0;
            //Les coûts de déplacement sont différents selon le type de terrain
            switch (World.Instance.getTile(p).GetType().ToString())
            {
                case "ProjetPOO.Mountain":
                    deplacementDuTour = 1;
                    break;
                case "ProjetPOO.Forest":
                    deplacementDuTour = 1;
                    break;
                case "ProjetPOO.Plain":
                    deplacementDuTour = 0.5;
                    break;
                case "ProjetPOO.Desert":
                    deplacementDuTour = 1;
                    break;
                default:
                    throw new Exception("Type de terrain non matché : " + World.Instance.getTile(p).GetType().ToString());
            }
            if (deplacementDuTour > nbDeplacement)
            {
                throw new Exception("plus assez de mouvements disponibles");
            }
            return deplacementDuTour;
        }

        //incPvOrc incrémente les points de victoire de l'orc
        public void incPvOrc()
        {
            pvOrc++;
        }

        //WinFight est le traitement en cas de victoire de l'orc
        override
        public void winFight(Position p)
        {
            if (World.Instance.getTile(p).GetType().ToString() != "ProjetPOO.Forest")
            {
                incPvOrc();
            }
        }

        //loseFight est le traitement en cas de défaite de l'orc
        override
        public bool loseFight()
        {
            this.die();
            return true;
        }

        //endGame fait le traitement de fin de partie pour les orcs (ajout de pv)
        override
        public void endGame()
        {
            if (World.Instance.getTile(this.position).GetType().ToString() != "ProjetPOO.Forest")
            {
                this.controler.score += pvOrc;
            }
        }
    }

    public class Dwarf : Unit
    {
        //constructeur de Dwarf
        public Dwarf(Player p, Position po) : base(p,po){}

        override
        //loadUnit permet de charger une unité
        public  void loadUnit(int uatt, int udef, int uhp, int unbDeplacement, int uinitialLife, int opt)
        {
            att = uatt;
            def = udef;
            hp = uhp;
            nbDeplacement = unbDeplacement;
            initialLife = uinitialLife;
        }

        //calcDeplAtt calcule le déplacement en cas d'attaque du nain
        override
        public double calcDeplAtt(Position p)
        {
            double deplacementDuTour = 0;
            //Les coûts de déplacement sont différents selon le type de terrain
            switch (World.Instance.getTile(p).GetType().ToString())
            {
                case "ProjetPOO.Mountain":
                    deplacementDuTour = 1;
                    break;
                case "ProjetPOO.Forest":
                    deplacementDuTour = 1;
                    break;
                case "ProjetPOO.Plain":
                    deplacementDuTour = 0.5;
                    break;
                case "ProjetPOO.Desert":
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

        //calcDepl effectue le mouvement de la pièce vers la position pour les Dwarves
        override
        public double calcDepl(Position p)
        {
            double deplacementDuTour = 0;
            //Les coûts de déplacement sont différents selon le type de terrain
            switch (World.Instance.getTile(p).GetType().ToString())
            {
                case "ProjetPOO.Mountain":
                    deplacementDuTour = 0;
                    break;
                case "ProjetPOO.Forest":
                    deplacementDuTour = 1;
                    break;
                case "ProjetPOO.Plain":
                    deplacementDuTour = 0.5;
                    break;
                case "ProjetPOO.Desert":
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

        //WinFight est le traitement en cas de victoire du Dwarf
        override
        public void winFight(Position p)
        {
            //coder tout
            if (World.Instance.getTile(p).GetType().ToString() != "Plain")
            {
                this.controler.incScore();
            }
        }

        //WinFight est le traitement en cas de victoire du Dwarf
        override
        public bool loseFight()
        {
            this.die();
            return true;
        }

        //endGame fait le traitement de fin de partie pour les dwarves (rien)
        override
        public void endGame() { }
    }

    public class Elf : Unit
    {
        //constructeur de Elf
        public Elf(Player p, Position po) : base(p,po){}

        override
        //loadUnit permet de charger une unité
        public void loadUnit(int uatt, int udef, int uhp, int unbDeplacement, int uinitialLife, int opt)
        {
            att = uatt;
            def = udef;
            hp = uhp;
            nbDeplacement = unbDeplacement;
            initialLife = uinitialLife;
        }

        //calcDeplAtt gère le déplacement d'une attaque. Il n'est différent que pour le nain.
        //le reste des unités appelle calcdepl
        override
        public double calcDeplAtt(Position p)
        {
            return calcDepl(p);
        }

        //calcDepl effectue le mouvement de la pièce vers la position pour un elfe
        override
        public double calcDepl(Position p)
        {
            double deplacementDuTour = 0;
            //Les coûts de déplacement sont différents selon le type de terrain
            switch (World.Instance.getTile(p).GetType().ToString())
            {
                case "ProjetPOO.Mountain" :
                    deplacementDuTour = 1;
                    break;
                case "ProjetPOO.Forest":
                    deplacementDuTour = 0.5;
                    break;
                case "ProjetPOO.Plain":
                    deplacementDuTour = 1;
                    break;
                case "ProjetPOO.Desert":
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

        //WinFight est le traitement en cas de victoire d'un elfe
        override
        public void winFight(Position p){}

        //WinFight est le traitement en cas de victoire de l'elfe
        override
        public bool loseFight()
        {
            Random rdm = new Random();
            int prob = rdm.Next(0,2);
            if (prob == 1)
            {
                if (!this.canMove())
                {
                    this.die();
                    return true;
                }
                this.def = 1;
                //le repli de l'unité est demandé au joueur
                //le joueur qui jouait avant perd momentanément la main
                //le joueur elfe choisit une case non occupée pour se replier
                //call methode controler qui rend une position de repli TODO
                //message l'unité elfe est sauvée et se replie
                World.Instance.repliCurrentPlayer = World.Instance.currentPlayer;
                World.Instance.currentPlayer = this.controler.numero;
                this.initDeplacement();
                return false;
                //le joueur fait son repli : seulement un move est possible
            }
            else
            {
                this.die();
                return true;
            }
        }

        //repli permet à l'elfe de se replier 50% du temps quand un combat est perdu
        //il dispose alors d'un point de déplacement pour fuir, mais ses points de vie redescendront à 1
        //dans le cas où il n'y a pas de possibilité de déplacement, l'unité mourra

        //endGame fait le traitement de fin de partie pour les elfes (rien)
        override
        public void endGame(){}
    }
}
