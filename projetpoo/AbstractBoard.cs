using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public abstract class AbstractBoard : Board
    {

        public ProjetPOO.ITile[,] ITile
        {
            get;
            set;
        }

        public void initBoard()
        {
            throw new System.NotImplementedException();
        }
    }
}
