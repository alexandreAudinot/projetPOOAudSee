using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class Player
    {
        public string nom { get; private set; }
        public int numero { get; private set; }
        public int score { get; set; } //passer en private set ?
        public List<ProjetPOO.IUnit> listUnit { get; private set; }

        public Player(string name, int n)
        {
            score = 0;
            nom = name;
            numero = n;
            listUnit = new List<IUnit>();
        }

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
