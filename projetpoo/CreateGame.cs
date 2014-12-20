using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class CreateGame
    {
        public Monteur Monteur { get; private set; }

        protected void init()
        {
            /* ----------------------------------------Fonction init ---------------------------------------- *
             * ---------------------------------------------------------------------------------------------- */


             /* ------------------------------Type du plateau, appels à faire--------------------------------- *
              * -----------------------Plateau Demo : MonteurDemo m = new MonteurDemo()----------------------- *
              * -----------------------Plateau Small : MonteurSmall m = new MonteurSmall()-------------------- *
              * -----------------------Plateau Normal : MonteurNormal m = new MonteurDemo()------------------- *
              * ---------------------------------------------------------------------------------------------- */


            /* ------------------------------Type des joueurs, appels à faire-------------------------------- *
             * ---------------------- les joueurs sont numérotés selon la vitesse d'inscription-------------- *
             * -----------------------Joueur nom, type : World.Instance.addPlayer(nom,type) ----------------- *
             * -----------------------Joueur nom, type : World.Instance.addPlayer(nom,type) ----------------- *
             * --------------------------------Donner le numéro de chaque joueur----------------------------- *
             * --------------------------------------------------------------------------------------------- */

            Random rdm = new Random();
            World.Instance.currentPlayer = rdm.Next(0, World.Instance.players.Count());
            //changer les positions initiales, changer avec position Player.pDepart


            //FactoryUnit f = new FactoryUnit();

            //f.createUnit(World.Instance.players, tiles, World.Instance.listType);
;
        }


        public void loadGame(World w, Board b)
        {
            //TODO
        }
    }
}