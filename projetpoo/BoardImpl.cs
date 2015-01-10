using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//remplacer tous les demoboard par des monteurDemo dans tous les tests et partout
namespace ProjetPOO
{
    public class DemoBoard : AbstractBoard
    {
        public DemoBoard()
        {
            size = 6;
            World.Instance.board = this;
            Tiles = new Tile[size, size];
        }

        override
        public void initVarBoard()
        {
            World.Instance.WorldVar(5, 4);
        }
    }

    public class SmallBoard : AbstractBoard
    {
        public SmallBoard()
        {
            size = 10;
            World.Instance.board = this;
            Tiles = new Tile[size, size];
        }

        override
        public void initVarBoard()
        {
            World.Instance.WorldVar(20, 6);
        }
    }

        public class NormalBoard : AbstractBoard
        {
            public NormalBoard()
            {
                size = 14;
                World.Instance.board = this;
                Tiles = new Tile[size, size];
            }

            override
            public void initVarBoard()
            {
                World.Instance.WorldVar(30, 8);
            }
        }
}
