﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public abstract class Monteur : IBuilder
    {
        private List<Desert> Deserts
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private List<Forest> Forests
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private List<TileImpl> Mountains
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private List<Plain> Plains
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ProjetPOO.Board Board
        {
            get;
            set;
        }
    
        public abstract void createTiles();

        public void make()
        {

        }
    }

    public abstract class AbstractFactoryUnit : AbstractFactory
    {

        protected void createTiles()
        {
            throw new System.NotImplementedException();
        }
    }
}
