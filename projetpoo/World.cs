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

        public static World myWorld
        {
            get { return World.world; }
            set { World.world = value; }
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

        public static List<Unit> getUnit(Position position)
        {
            //TODO : comment a t-on accès aux positions des unités ? Accès direct avec tile ou parcourir toutes les unités avec un if
            /*foreach (Unit element in unitList)
            {
            System.Console.WriteLine(element);
            }*/
            throw new System.NotImplementedException();
        }

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
