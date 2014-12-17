using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapping;

namespace ProjetPOO
{
    public abstract class AbstractBoard : Board
    {
        public int size { get; set; }
        //private ProjetPOO.ITile[,] tile;
        public Tile[,] Tiles { get; set; }

        /*public void initBoard()
        {
            Wrapper wrapper = new Wrapper();
            List<int> generatedList;
            generatedList = wrapper.compute(12, 12);
        }*/

        public abstract void initBoard();
        //future méthode à utiliser après

        public Tile getTile(Position p)
        {
            if ((p.x > size)||(p.y > size))
            {
                throw new Exception("La carte est trop petite pour cette position");
            }
            return (Tile) Tiles[p.x, p.y];
        }

        public abstract void initVarBoard();
    }
}
