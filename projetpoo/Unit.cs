using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapping;

namespace ProjetPOO
{
    public abstract class Unit : ProjetPOO.IUnit
    {
        public int att { get; protected set; }
        public int def { get; protected set; }
        public int hp { get; protected set; }
        public double nbDeplacement { get; set; }
        public Player controler { get; set; }
        public Position position { get; set; }
        public int initialLife{ get; protected set; }
        public abstract double calcDepl(Position p);
        public abstract double calcDeplAtt(Position p);
        public abstract void endGame();
        public abstract bool loseFight();
        public abstract void winFight(Position p);
        public abstract void loadUnit(int uatt, int udef, int uhp, int unbDeplacement, int uinitialLife, int opt);

        //constructeur d'unité, méthode accessible que par les classes filles
        protected Unit(Player p, Position po)
        {
            att = 2;
            def = 1;
            hp = 5;
            controler = p;
            position = po;
            nbDeplacement = 0;
            initialLife = 5;
        }

        //méthode utilisée pour les tests unitaires seulement
        //permet de changer la défense d'une unité
        public void setDefForUnitTest(int h)
        {
            def = h;
        }

        //méthode utilisée pour les tests unitaires seulement
        //permet de changer la vie d'une unité
        public void setHPForUnitTest(int h)
        {
            hp = h;
        }

        //initialisation du déplacement en début de tour
        public void initDeplacement()
        {
            nbDeplacement = 1 ;
        }

        //vérification si l'unité est en vie
        public bool isAlive()
        {
            return hp > 0;
        }

        //méthode fight traite le combat de deux unités
        public void fight(Position p, Unit u)
        {
            //le nombre de combats est compris entre 3 et le nombre de points de vie maximum des 2 unités ajouté de 2
            Random rdm = new Random();
            int nbCombats = rdm.Next(3,2 + Math.Max(this.hp,u.hp)) - 1;
            //calcul des probabilités de combat
            double probAtt;
            if (this.att < u.def)
            {
                probAtt = (100 - 100 * this.att / u.def) * 50.0 / 100 + 50;
            }
            else
            {
                probAtt = (100 - 100 * u.def/this.att)*50.0/100 + 50;
            }
            //String s = "nb Combats : " + nbCombats + " Probatt : " + probAtt;
            //Sélection de l'attaquant et attaque
            while(this.isAlive() && u.isAlive() && nbCombats > 0)
            {
                nbCombats--;
                if (rdm.Next(0, 100) < probAtt)
                {
                    //l'attaque est pondérée par les points de vie de l'attaquant
                    u.hp -= (int) Math.Truncate((this.hp * 1.0 / this.initialLife) * this.att);
                    //s += ", 75 attaque de " + ((int)Math.Truncate((this.hp * 1.0 / this.initialLife) * this.att)).ToString() + "(" + this.hp + "," + u.hp + ")";
                }
                else
                {
                    this.hp -= (int) Math.Truncate((u.hp * 1.0 / u.initialLife) * u.att);
                    //s += ", 25 attaque de " + ((int)Math.Truncate((u.hp * 1.0 / u.initialLife) * u.att)).ToString() + "(" + this.hp + "," + u.hp + ")";
                }
            }
                //cas de mort d'une unité
                if (!this.isAlive())
                {
                    //s += " Mort de l'attaquant";
                    //message this.getType().toString() gagne le combat
                    if (this.loseFight())
                    {
                        u.winFightDef(p);
                    }
                } 
                else
                {
                    if (!u.isAlive())
                    {
                        //s += " Mort du défenseur";
                        if (u.loseFight())
                        {
                            this.winFightAtt(p);
                            if (World.Instance.unitBool(p)) //NS
                            {
                                this.fight(p, World.Instance.getUnit(p));
                            } 
                            else
                            {
                                this.makeAMove(p, this.calcDeplAtt(p));
                            }
                        }
                    }
                    else
                    {
                        //s += " Pas de gagnant";
                        //message pas de gagnant
                    }
               }
            //throw new Exception(s);
        }

        //die permet de tuer l'unité courante
        //de la retirer de la liste d'unité du joueur
        public void die()
        {
            this.controler.killUnit(this);
        }

        public List<Position> getAllPossibleMoves()
        {
            List<Position> res = new List<Position>();

            if (position.x + 1 < World.Instance.board.size)
                res.Add(new Position(position.x + 1, position.y));
            if (position.x - 1 > 0)
                res.Add(new Position(position.x - 1, position.y));
            if (position.y + 1 < World.Instance.board.size)
                res.Add(new Position(position.x, position.y + 1));
            if (position.y - 1 > 0)
                res.Add(new Position(position.x, position.y - 1));

            if (this.position.y % 2 == 0)
            {
                if (position.x + 1 < World.Instance.board.size)
                {
                    if (position.y - 1 > 0)
                        res.Add(new Position(position.x + 1, position.y - 1));
                    if (position.y + 1 < World.Instance.board.size)
                        res.Add(new Position(position.x + 1, position.y + 1));
                }
            }
            else
            {
                if (position.x - 1 > 0)
                {
                    if (position.y - 1 > 0)
                        res.Add(new Position(position.x - 1, position.y - 1));
                    if (position.y + 1 < World.Instance.board.size)
                        res.Add(new Position(position.x - 1, position.y + 1));
                }
            }
            return res;
        }

        //checkmove vérifie la cohérence du mouvement avec les règles
        //on décide arbitrairement de ne prendre que des déplacements de une case
        //Les déplacements possibles pour la case 2,2 sont (1,2), (2,1), (2,3), (3,2), (1,3), (3,1).
        public bool checkMove(Position p)
        {
            List<Position> list = getAllPossibleMoves();
            foreach(Position tile in list)
            {
                if (tile.equals(p))
                    return true;
            }
            return false;
            
            /*if (!((p.x < 0) || (p.y < 0) || (p.x >= World.Instance.board.size) || (p.y >= World.Instance.board.size)))
            {
                if(this.position.y % 2 == 0)
                {
                    return (
                        ((p.x + 1 == this.position.x) && (this.position.y == p.y))
                        || ((p.x - 1 == this.position.x) && (this.position.y == p.y))
                        || ((p.x == this.position.x) && (this.position.y + 1 == p.y))
                        || ((p.x == this.position.x) && (this.position.y - 1 == p.y))
                        || ((p.x == this.position.x + 1) && (this.position.y - 1 == p.y))
                        || ((p.x == this.position.x + 1) && (this.position.y + 1 == p.y)));
                }
                else
                {
                    return (
                        ((p.x + 1 == this.position.x) && (this.position.y == p.y))
                        || ((p.x - 1 == this.position.x) && (this.position.y == p.y))
                        || ((p.x == this.position.x) && (this.position.y + 1 == p.y))
                        || ((p.x == this.position.x) && (this.position.y - 1 == p.y))
                        || ((p.x == this.position.x - 1) && (this.position.y - 1 == p.y))
                        || ((p.x == this.position.x - 1) && (this.position.y + 1 == p.y)));
                }
            }
            return false;*/
        }

        //fonction canMove permet de savoir si un déplacement est possible de la case de l'unité
        //on utilisera la fonction lors du repli de l'elfe
        public bool canMove()
        {
            return ((!World.Instance.unitBool(new Position(this.position.x + 1, this.position.y))
            || (!World.Instance.unitBool(new Position(this.position.x - 1, this.position.y)))
            || (!World.Instance.unitBool(new Position(this.position.x, this.position.y + 1)))
            || (!World.Instance.unitBool(new Position(this.position.x, this.position.y - 1)))
            || (!World.Instance.unitBool(new Position(this.position.x + 1, this.position.y - 1)))
            || (!World.Instance.unitBool(new Position(this.position.x - 1, this.position.y + 1)))));
        }
        public Position randomPosition()
        {
            Random rand = new Random();
            List<Position> possiblePos = new List<Position>();

            //if (new Position(this.position.x + 1, this.position.y))


            return null;
        }

        //La méthode move détermine si l'évènement est un déplacement ou un combat et fait l'appel le cas échéant
        //elle empêche les déplacements de plus d'une case
        public void move(Position p)
        {
            if (World.Instance.currentPlayer == this.controler.numero)
            {
                if (!this.checkMove(p))
                {
                    throw new Exception("Le mouvement est impossible");
                }

                Unit elem = World.Instance.getUnit(p);
                if (elem == null)
                {
                    this.makeAMove(p, this.calcDepl(p));
                }
                else
                {
                    if (elem.controler.numero == this.controler.numero)
                    {
                        this.makeAMove(p, this.calcDeplAtt(p));
                    }
                    else
                    {
                        if (World.Instance.repliCurrentPlayer != -1)
                        {
                            throw new Exception("Il n'est pas possible d'attaquer lors d'un repli");
                        }
                        this.calcDeplAtt(p);
                        this.fight(p, elem);
                    }   
                }
            }
            else
            {
                throw new Exception("C'est au joueur " + (World.Instance.currentPlayer+1) + " de jouer");
            }
        }

        public void makeAMove(Position p, double depl)
        {
            //mise à jour de nbDeplacement
            nbDeplacement -= this.calcDepl(p);
            position.setPosition(p);
        }

        //winFightAtt permet de gérer le combat gagné pour l'attaquant au départ
        //l'unité gagnante doit tenter de se déplacer sur la case de l'unité perdante
        //ce qui n'est pas le cas de l'unité perdante
        public void winFightAtt(Position p)
        {
            if (!World.Instance.unitBool(p))
            {
                double depl = this.nbDeplacement;
                this.initDeplacement();
                this.makeAMove(p, this.nbDeplacement);
                this.nbDeplacement = depl;
            }
            this.winFight(p);
        }

        //winFightDef permet de gérer le traitement additionnel en cas de victoire dans un combat
        //défensif pour l'unité courante
        public void winFightDef(Position p)
        {
            this.winFight(p);
        }

        //permet de calculer le déplacement, mais renvoie un entier grand
        //si jamais le mouvement est impossible au lieu d'une exception
        double calcDepl2(Position p)
        {
            double d;
            try
            {
               return d = this.calcDepl(p);
            }
            catch(Exception e)
            {
               return d = 5000;
            }
        }

        //permet de calculer le déplacement, mais renvoie un entier grand
        //si jamais le mouvement est impossible au lieu d'une exception
        double calcDeplAtt2(Position p)
        {
            double d;
            try
            {
                return d = this.calcDeplAtt(p);
            }
            catch (Exception e)
            {
                return d = 5000;
            }
        }

        //getMoveSuggestions est un algorithme de suggestion en C#
        //getMoveSuggestions permet de faire la suggestion de 3 cases maximum pour une unité
        //il ne fera aucune suggestion si rien est intéressant
        public List<Position> getMoveSuggestions()
        {
            List<Position> l = new List<Position>();
            int i = this.position.x;
            int j = this.position.y;
            Position p;
            String s = "";
            double depl = this.nbDeplacement;
            for (int x = i - 1; x < i + 2; x++)
            {
                for (int y = j - 1; y < j + 2; y++)
                {
                    this.nbDeplacement = depl;
                    if (!(x == y))
                    {
                        p = new Position(x, y);
                        //on vérifie que le mouvement est possible
                        if (this.checkMove(p))
                        {
                            if (World.Instance.unitBool(p))
                            {//cas où une unité est sur la case
                                if (World.Instance.unitCount(p) < 2)
                                {//on n'attaquera pas / ne rejoindra pas les cases avec plus d'une unité dessus
                                    if (World.Instance.getUnit(p).controler.numero != this.controler.numero)
                                    {//cas de l'unité ennemie
                                        //cas où le déplacement est possible
                                        if (this.calcDeplAtt2(p) <= this.nbDeplacement)
                                        { // on decide de ne tenter le combat que si la vie de l'unité adverse est inférieure
                                            if (World.Instance.getUnit(p).hp < this.hp)
                                            {//le combat est envisageable
                                                l.Add(p);
                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {
                                //cas où il n'y a pas d'unité
                                if (this.calcDepl2(p) <= this.nbDeplacement)
                                {//le déplacement est possible
                                    s += x + " " + y + " , ";
                                    if (this.strategy(p))
                                    {
                                        s += x + " " + y + " , ";
                                        l.Add(p);
                                    }

                                }
                            }
                        }
                    }
                }
            }

            this.nbDeplacement = depl;
            //on prend trois suggestions de l aléatoirement
            /*List<Position> lres = new List<Position>();
            int cpt = 3;
            Random random = new Random();
            int index;
            while ((cpt > 0)||(l.Any()))
            {
                index = random.Next(0, l.Count());
                lres.Add(l.ElementAt(index));
                l.RemoveAt(index);
                cpt--;
            }*/

            //on ne prend que les trois premières suggestions de l
            /*List<Position> lres = new List<Position>();
            int cpt = 0;
            foreach (Position p0 in l)
            {
                if (cpt > 3)
                {
                    return lres;
                }
                else
                {
                    lres.Add(p0);
                    cpt++;
                }
            }*/
            //throw new Exception(l.ElementAt(1).x + " " + l.ElementAt(1).y);
            return l;
        }

        //strategy permet de déterminer s'il y a des alliers autour de l'unité courante
        //on voudra pour l'IA éviter les cases où les alliers sont à proximité
        //pour étirer au maximum la surface de jeu
        //et éviter les unités avec plus de vie que l'unité courante
        //sinon, il cherchera les combats
        public bool strategy(Position p)
        {
            Unit u;
            for (int x = p.x - 1; x < p.x + 2; x++)
            {
                for (int y = p.y - 1; y < p.y + 2; y++)
                {
                    u = World.Instance.getUnit(new Position(x, y));
                    if (u != null)
                    {
                        if ((!((u.position.x + 1 == p.x) && (u.position.y + 1 == p.y))) && ((!((u.position.x - 1 == p.x) && (u.position.y - 1 == p.y)))) && (!((x == this.position.x) && (y == this.position.y))))
                        {
                            if (u.controler.numero == this.controler.numero)
                            {
                                return false;
                            }
                            else
                            {
                                if (u.hp > this.hp)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        //getMoveSuggestions2 est un algorithme de suggestion en C++ via le wrapper
        //getMoveSuggestions2 permet de faire la suggestion de 3 cases maximum pour une unité
        //il ne fera aucune suggestion si rien est intéressant
        public List<Position> getMoveSuggestions2()
        {
            double depl = this.nbDeplacement;
            int i = this.position.x;
            int j = this.position.y;
            Position p;
            String s = "";
            List<int> l = new List<int>();
            Unit u;
            List<Position> lp = new List<Position>();
            l.Add(this.hp);
            for (int x = i - 1; x < i + 2; x++)
            {
                for (int y = j - 1; y < j + 2; y++)
                {
                    if (!(x == y))
                    {
                        p = new Position(x, y);
                        //on vérifie que le mouvement est possible
                        if (this.checkMove(p))
                        {
                            lp.Add(p);
                            if (!World.Instance.unitBool(p))
                            {//cas où il n'y a pas d'unité sur la case
                                this.nbDeplacement = depl;
                                if (this.nbDeplacement >= this.calcDepl(p))
                                {
                                    lp.Add(p);
                                    l.Add(-1);
                                    l.Add(-1);
                                }
                            }
                            else
                            {// il y a une unité sur la case
                                u = World.Instance.getUnit(p);
                                if (u.controler.numero == this.controler.numero)
                                {//allié
                                    this.nbDeplacement = depl;
                                    if (this.nbDeplacement >= this.calcDepl(p))
                                    {
                                        lp.Add(p);
                                        l.Add(1);
                                        l.Add(1);
                                    }
                                }
                                else
                                {//ennemi
                                    this.nbDeplacement = depl;
                                    if (this.nbDeplacement >= this.calcDeplAtt(p))
                                    {
                                        lp.Add(p);
                                        l.Add(0);
                                        l.Add(u.hp);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Wrapper algo = new Wrapper();
            List<int> resul = algo.computeSug(l.ElementAt(0), l.ElementAt(1), l.ElementAt(2), l.ElementAt(3),  l.ElementAt(4),
                l.ElementAt(5), l.ElementAt(6),l.ElementAt(7), l.ElementAt(8), l.ElementAt(9), l.ElementAt(10) , l.ElementAt(11), l.ElementAt(12));
            //translate
            List<Position> lres = new List<Position>();
            int rang = 0;
            for (int x = i - 1; x < i + 2; x++)
            {
                for (int y = j - 1; y < j + 2; y++)
                {
                    if (!(x == y))
                    {
                        p = new Position(x, y);
                        if (resul.ElementAt(rang) == 1)
                        {
                            lres.Add(p);
                        }
                    }
                }
            }
            Random rnd = new Random();
            int cpt = 0;
            int rn;
            while ((cpt < 3) && (cpt < lres.Count()))
            {
                rn = rnd.Next(0, 3);
                lres.RemoveAt(rn);
                cpt++;
            }
            throw new Exception("fin" + resul.Count());
            this.nbDeplacement = depl;
            return lres;
        }
    }
}
