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
            //init board
            //appel selon les évènements
            //*******************************************************************************//
            Board b = new DemoBoard();
            //*******************************************************************************//
            b.initBoard();
            FactoryUnit.pinitDwarf = new Position(1, 1);
            FactoryUnit.pinitElf = new Position(2, 2);
            FactoryUnit.pinitOrc = new Position(3, 3);



            //init world
            World.board.initVarBoard();

            //init players
             //addPlayer(string nomJoueur, string type)
             //appel évènement à faire
            //*******************************************************************************//
            World.Instance.addPlayer("Dan", "Orc");
            World.Instance.addPlayer("Alexandre", "Nain");
            //*******************************************************************************//

            //init unit
            IFactory f = new FactoryUnit();

            // List<Player> players, List<Tile> tiles, List<String> types
            // Les paramètres de début de partie ajoutent la position des tiles
            //*******************************************************************************//
            Tile t1 = new Tile();
            Tile t2 = new Tile();
            List<Tile> tiles = new List<Tile>();
            tiles.Add(t1);
            tiles.Add(t2);
            //*******************************************************************************//
            f.createUnit(World.Instance.players, tiles, World.Instance.listType);
;
        }


        public void loadGame(World w, Board b)
        {
            //TODO
        }
    }
}