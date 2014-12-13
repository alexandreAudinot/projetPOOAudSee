using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class SaveGame
    {
        public World world;
        public Board board;
        public void saveOnDisk(World w, Board b)
        {
            if (World.stateGame)
            {
                throw new Exception("Impossible d'enregistrer une partie terminée");
            }
            world = w;
            board = b;
        }

        public void loadOnDisk()
        {
            World w = new World(world,board);
        }
    }
}
