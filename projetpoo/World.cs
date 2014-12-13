using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class World
    {
        private int nbTours;
        private int nbUnity;
        private int sizeBoard;
        private List<Player> players;
        private static World world;
        private static Board board;
        private static List<string> listType;
        public static bool stateGame;

        public static World Instance
        {
            get
            {
                if (world == null)
                {
                    world = new World(); 
                }
                return World.world;
            }
        }

        protected World()
        {
            stateGame = true;
            //coder constructeur de world
        }

        private System.Collections.Generic.List<ProjetPOO.IUnit> unitList
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private CreateGame createGame
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Display display
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public SaveGame saveGame
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        //unitBool rend vrai s'il y a une unité sur la position p
        public bool unitBool(Position p)
        {
            foreach (Unit unit in unitList)
            {
                if (unit.position.equals(p))
                {
                    return true;
                }
            }
            return false;
        }

        //getUnit rend une unité nulle s'il n'y a pas de pièce sur la position
        //ou sinon rend l'unité de plus grande défense de la case (l'unité au hasard en cas d'égalité)
        public Unit getUnit(Position position)
        {
            List<Unit> l = new List<Unit>();
            foreach (Unit unit in unitList)
            {
                if (unit.position.equals(position))
                {
                    if (!l.Any())
                    {
                        l.Add(unit);
                    }
                    else
                    {
                        if (unit.def > l.First().def)
                        {
                            l.Clear();
                            l.Add(unit);
                        }
                        else
                        {
                            if (unit.def == l.First().def)
                            {
                                l.Add(unit);
                            } 
                            else
                            {
                            }
                        }
                    }
                }
            }
            //renvoie null si rien n'a été trouvé sur la case
            if (!l.Any())
            {
                return null;
            }
            else
            {
                if (l.Count() == 1)
                {
                    return l.First();
                } 
                else
                {
                    //renvoie une unité au hasard
                    //tester que le nombre est bien dans les cordes
                    Random rnd = new Random();
                    return l.ElementAt(rnd.Next(0,l.Count() + 1));
                }
            }
        }

        public Tile getTile(Position p)
        {
            return board.getTile(p);
        }
        
        //fonction qui prend une position et renvoie un tile


        private void addPlayer(string nomJoueur, string type)
        {
            Player player = new Player(nomJoueur);
            if (!listType.Remove(type))
            {
                if (listType.Any())
                {
                    throw new Exception("Le type n'a pas été matché");
                }
                else
                {
                    throw new Exception("Plus de types disponibles");
                }
            }
            players.Add(player);
        }


        public void removePlayer(Player p)
        {
            if (!players.Remove(p))
            {
                throw new Exception("Erreur dans la suppression d'un joueur");
            }
            if (players.Count() == 1)
            {
                this.endGame();
            }
        }

        public void endGame()
        {
            stateGame = false;
        }

        public void saveTheGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
