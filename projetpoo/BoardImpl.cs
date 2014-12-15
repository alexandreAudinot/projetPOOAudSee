using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class DemoBoard : AbstractBoard
    {

        override
        public void initBoard()
        {
            size = 6;
            World.board = this;
            ITile = new ITile[size, size];
        }

        override
        public void initVarBoard()
        {
            World.Instance.WorldVar(5, 4);
        }
    }

    public class NormalBoard : AbstractBoard
    {
        override
        public void initBoard()
        {
            size = 10;
            ITile = new ITile[size, size];
            World.board = this;
        }

        override
        public void initVarBoard()
        {
            World.Instance.WorldVar(20, 6);
        }
    }

    public class SmallBoard : AbstractBoard
    {
        override
        public void initBoard()
        {
            size = 4;
            World.board = this;
            ITile = new ITile[size, size];
        }

        override
        public void initVarBoard()
        {
            World.Instance.WorldVar(30, 8);
        }
    }
}
