﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public abstract class AbstractFactory : IFactory
    {
        public abstract void createUnit(List<Player> players, List<Tile> tiles, List<String> types);
    }
}
