using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public interface IWorld
    {
        IPlayer IPlayer
        {
            get;
            set;
        }

        IUnit IUnit
        {
            get;
            set;
        }
    }
}
