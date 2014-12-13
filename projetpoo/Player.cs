﻿using System;
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
        }
        protected string nom { get; private set; }
        public int numero { get; private set; }

        public int score { get; set; }

        protected List<ProjetPOO.IUnit> listUnit { get; set; }

        public void incScore()
        {
            score++;
        }

        public void killUnit(Unit myUnit)
        {
            listUnit.Remove(myUnit);
            if (!listUnit.Any())
            {
                this.lose();
            }
        }
        protected void lose()
        {
            World.Instance.removePlayer(this);
        }

        public void endGame()
        {
            foreach (Unit unit in listUnit)
            {
                unit.endGame();
            }
        }
    }
}
