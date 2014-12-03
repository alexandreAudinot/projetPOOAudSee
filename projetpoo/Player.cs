using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class Player
    {

        private int score { get; set; }

        protected List<ProjetPOO.IUnit> listUnit { get; set; }

        protected void incScore()
        {
            score++;
        }

        public void killUnit(Unit myUnit)
        {
            listUnit.Remove(myUnit);
        }
        protected void lose()
        {
            //World.myWorld.removeplayer(this);
            //call remove player of world
            throw new System.NotImplementedException();
        }
    }
}
