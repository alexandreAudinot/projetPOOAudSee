using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public interface IUnit
    {
        void move(Position p);
        void fight(Position p, Unit u);
        void die();
        double calcDepl(Position p);
        double calcDeplAtt(Position p);
        void winFight(Position p);
        void winFightAtt(Position p);
        void winFightDef(Position p);
        bool loseFight();
        void makeAMove(Position p, double depl);
        void endGame();
        bool checkMove(Position p);
        bool isAlive();
        String getLeType();
    }

}
