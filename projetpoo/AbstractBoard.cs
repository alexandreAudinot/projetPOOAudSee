using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapping;

namespace ProjetPOO
{
    public abstract class AbstractBoard : Board
    {
        protected int size;
        //private ProjetPOO.ITile[,] tile;
        public ProjetPOO.ITile[,] ITile { get; set; }

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
            return (Tile) ITile[p.x, p.y];
        }

        public abstract void initVarBoard();
    }
}
