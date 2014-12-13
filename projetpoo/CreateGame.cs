﻿using System;
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
            //init board
            //appel selon les évènements
            //*******************************************************************************//
            Board b = new DemoBoard();
            //*******************************************************************************//
            b.initBoard();




            //init world
            World w = new World(b);
            b.initVarBoard();
            UnitType lType = new UnitType();
            lType.init();
            w.listType = lType.listType;

            //init players
             //addPlayer(string nomJoueur, string type)
             //appel évènement à faire
            //*******************************************************************************//
            w.addPlayer("Dan", "Orc");
            w.addPlayer("Alexandre", "Nain");
            //*******************************************************************************//

            //init unit
            IFactory f = new FactoryUnit();
            // List<Player> players, List<Tile> tiles, List<String> types
            // Les paramètres de début de partie ajoutent
            //*******************************************************************************//
            Tile t = new Tile();
            List<String> l = new List<String>();
            //*******************************************************************************//
            f.createUnit(w.players, new List<Tile>(), new List<String>());
;
        }


        public void loadGame()
        {
            throw new System.NotImplementedException();
        }
    }
}