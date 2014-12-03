﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public interface IUnit
    {
        void move();
        void attack(Position position);

        void die();

        void winFight();

        void init();
    }

}
