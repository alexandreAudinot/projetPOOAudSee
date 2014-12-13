using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class Player
    {
        public Player(string name)
        {
            score = 0;
            nom = name;
            //initlistunti
        }
        protected string nom { get; private set; }

        private int score { get; set; }

        protected List<ProjetPOO.IUnit> listUnit { get; set; }

        public void incScore()
        {
            score++;
        }

        public void killUnit(Unit myUnit)
        {
            listUnit.Remove(myUnit);
            //check player dying
        }
        protected void lose()
        {
            World.Instance.removePlayer(this);
        }
    }
}
