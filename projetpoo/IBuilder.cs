﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ProjetPOO
{
    public interface IBuilder
    {
        Board Board
        {
            get;
            set;
        }
        void make();
    }
}
