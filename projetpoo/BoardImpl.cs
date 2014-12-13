using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class DemoBoard : AbstractBoard
    {
        override
        public Tile getTile(Position p)
        {
            return null;
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
        public Tile getTile(Position p)
        {
            return null;
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
        public Tile getTile(Position p)
        {
            return null;
        }

        override
        public void initVarBoard()
        {
            World.Instance.WorldVar(30, 8);
        }
    }
}
