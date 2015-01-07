using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class Player
    {
        public string nom { get; private set; }
        public int numero { get; set; }
        public int score { get; set; }
        public List<IUnit> listUnit { get; set; }
        public Position pDepart { get; set; }
        public String type { get; private set; }

        //constructeur testPlayer
        //on impose la position des pièces du joueur 0 en (1,1)
        //on impose la position des pièces du joueur 1 à l'autre coin par symétrie centrale
        public Player(string name, int n, string t)
        {
            score = 0;
            nom = name;
            numero = n;
            listUnit = new List<IUnit>();
            type = t;
            if (n == 0)
            {
                pDepart = new Position(1, 1);
            }
            else
            {
                pDepart = new Position(World.board.size - 1, World.board.size - 1);
            }
        }

        //incScore fonction qui permet d'incrémenter le score
        public void incScore()
        {
            score++;
        }

        public void initDeplacement()
        {
            foreach (Unit u in listUnit)
            {
                u.initDeplacement();
            }
        }

        //fonction qui permet de tuer une unité
        //fait perdre le joueur si plus d'unité
        public void killUnit(Unit myUnit)
        {
            listUnit.Remove(myUnit);
            if (!listUnit.Any())
            {
                this.lose();
            }
        }

        //fonction lose appelée si le joueur a perdu
        //on efface le joueur de la liste des joueurs
        public void lose()
        {
            World.Instance.removePlayer(this);
        }

        //fonction updateSpecialPv qui permet de mettre à jour les points de victoire spéciaux
        public void updateSpecialPv()
        {
            foreach (Unit unit in listUnit)
            {
                unit.endGame();
            }
        }

        //fonction updateScore permet de mettre à jour les points de victoire
        public void updateScore()
        {
            if (this.listUnit.Count() > 0 )
            {
                if (this.listUnit.First().GetType().ToString() != "ProjetPOO.Orc")
                {
                    if (this.listUnit.First().GetType().ToString() != "ProjetPOO.Dwarf")
                    {
                        {
                            List<Position> l = new List<Position>();
                            l.Add(new Position(-1, -1));
                            Boolean trouve = false;
                            foreach (Unit unit in listUnit)
                            {
                                foreach (Position p in l)
                                {
                                    if (p.equals(unit.position))
                                    {
                                        trouve = true;
                                        break;
                                    }
                                }
                                if (!trouve)
                                {
                                    l.Add(unit.position);
                                }
                                trouve = false;
                            }
                            score = l.Count - 1;
                            this.updateSpecialPv();
                            return;
                        }
                    }
                    else
                    {
                        this.updateScoreDwarf();
                        this.updateSpecialPv();
                        return;
                    }
                }
                else
                {
                    this.updateScoreOrc();
                    this.updateSpecialPv();
                    return;
                }
            }
            else
            {
                return;
            }
        }

        //fonction updateScoreOrc permet de mettre à jour les points de victoire pour les orcs
        public void updateScoreOrc()
        {
            List<Position> l = new List<Position>();
            l.Add(new Position(-1, -1));
            Boolean trouve = false;
            foreach (Unit unit in listUnit)
            {
                if ((World.Instance.getTile(unit.position)).GetType().ToString() != "ProjetPOO.Forest")
                {
                    foreach (Position p in l)
                    {
                        if (p.equals(unit.position))
                        {
                            trouve = true;
                            break;
                        }
                    }
                    if (!trouve)
                    {
                        l.Add(unit.position);
                    }
                    trouve = false;
                }
            }
            score = l.Count - 1;
        }

        //fonction updateScoreOrc permet de mettre à jour les points de victoire pour les orcs
        public void updateScoreDwarf()
        {
            List<Position> l = new List<Position>();
            l.Add(new Position(-1, -1));
            Boolean trouve = false;
            foreach (Unit unit in listUnit)
            {
                if ((World.Instance.getTile(unit.position)).GetType().ToString() != "ProjetPOO.Plain")
                {
                    foreach (Position p in l)
                    {
                        if (p.equals(unit.position))
                        {
                            trouve = true;
                            break;
                        }
                    }
                    if (!trouve)
                    {
                        l.Add(unit.position);
                    }
                    trouve = false;
                }
            }
            score = l.Count - 1;
        }

        public void apresRepli()
        {
            //traite le repli d'un elfe : on donne la possibililité de bouger une seule fois
            World.Instance.currentPlayer = World.Instance.repliCurrentPlayer;
            World.Instance.repliCurrentPlayer = -1;
        }
    }
}
