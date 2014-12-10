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
                    //tester que le nombre est bien dans les cordes
                    Random rnd = new Random();
                    return l.ElementAt(rnd.Next(0,l.Count() + 1));
                }
            }
        }

        //fonction qui prend une position et renvoie un tile

        public void removePlayer()
        {
            throw new System.NotImplementedException();
        }

        public void endGame()
        {
            throw new System.NotImplementedException();
        }

        public void saveTheGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
