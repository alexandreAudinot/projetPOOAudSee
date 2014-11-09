using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public abstract class Unit : ProjetPOO.IUnit
    {
        private int att;
        private int def;
        private int hp;

        private Player controler
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private Position position
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void move()
        {
            throw new System.NotImplementedException();
        }
        public void attack(Position position)
        {
            throw new System.NotImplementedException();
        }

        public void die()
        {
            throw new System.NotImplementedException();
        }

        public void winFight()
        {
            throw new System.NotImplementedException();
        }

        public void init()
        {
            throw new System.NotImplementedException();
        }
    }
}
