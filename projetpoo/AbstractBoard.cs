using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapping;

namespace ProjetPOO
{
    public abstract class AbstractBoard : Board
    {

        private ProjetPOO.ITile[,] tile;
        public ProjetPOO.ITile[,] ITile
        {
            get
            {
                return tile;
            }
        }

        public void initBoard()
        {
            Wrapper wrapper = new Wrapper();
            List<int> generatedList;
            generatedList = wrapper.compute(12, 12);
        }
    }
}
