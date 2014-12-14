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
            World.board.initVarBoard();

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
            // Les paramètres de début de partie ajoutent la position des tiles
            //*******************************************************************************//
            Tile t1 = new Tile(new Position(1, 1));
            Tile t2 = new Tile(new Position(3, 3));
            List<Tile> tiles = new List<Tile>();
            tiles.Add(t1);
            tiles.Add(t2);
            //*******************************************************************************//
            f.createUnit(w.players, tiles, w.listType);
;
        }


        public void loadGame()
        {
            throw new System.NotImplementedException();
        }
    }
}