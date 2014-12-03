using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class Player
    {

        private int score { get; set; }

        protected List<ProjetPOO.IUnit> Unit { get; set; }

        protected void incScore()
        {
            score++;
        }

        public void killUnit(Unit unit)
        {
            //recherche de l'unité
        }
        protected void lose()
        {
            //call remove player of world
            throw new System.NotImplementedException();
        }
    }
}
