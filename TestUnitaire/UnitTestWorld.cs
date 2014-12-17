using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetPOO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTestWorld
    {

        public static void InitAll()
        {
            World.Clean();
            AbstractBoard b = new DemoBoard();
            World.board = b;
            Assert.IsNotNull(World.Instance);
            World.board.initBoard();
            World.board.initVarBoard();
            Assert.IsNotNull(World.Instance);
        }

        [TestMethod]
        public void testWorldBoard()
        {
            World.Clean();
            AbstractBoard b = new DemoBoard();
            World.board = b;
            Assert.IsNotNull(World.Instance);
            Assert.AreEqual(0, World.Instance.nbPlayer);
            Assert.IsTrue(World.Instance.stateGame);
            Assert.AreEqual(World.board, b);
            Assert.AreEqual(0, World.Instance.nbTours);
            Assert.IsNotNull(World.Instance.listType);
            Assert.IsNotNull(World.Instance.listAvailableType);
            Assert.IsNotNull(World.Instance.players);
        }

        [TestMethod]
        public void testWorldVar()
        {
            InitAll();
            Assert.AreEqual(5, World.Instance.maxnbTours);
            Assert.AreEqual(4, World.Instance.nbUnity);
            Assert.AreEqual(0, World.Instance.currentPlayer);
        }

        [TestMethod]
        public void testInitType()
        {
            Board b = new DemoBoard();
            Assert.IsNotNull(World.Instance);
            Assert.IsTrue(World.Instance.listAvailableType.Contains("Orc"));
            Assert.IsTrue(World.Instance.listAvailableType.Contains("Dwarf"));
            Assert.IsTrue(World.Instance.listAvailableType.Contains("Elf"));
            Assert.AreEqual(3, World.Instance.listAvailableType.Count);
        }

        [TestMethod]
        public void testUnitBool()
        {
            InitAll();
            MonteurDemo m = new MonteurDemo();
            m.createTiles();
            World.Instance.addPlayer("Jean-Pierre", "Orc");
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), World.board.getTile(new Position(1,1))));
            Assert.IsTrue(World.Instance.unitBool(new Position(1, 1)));
            Assert.IsFalse(World.Instance.unitBool(new Position(1, 2)));
        }

        [TestMethod]
        public void testGetUnit()
        {
            InitAll();
            MonteurDemo m = new MonteurDemo();
            m.createTiles();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            Orc o0 = new Orc(World.Instance.players.First(), World.board.getTile(new Position(1, 1)));
            Orc o1 = new Orc(World.Instance.players.First(), World.board.getTile(new Position(1, 1)));
            o0.setDefForUnitTest(2);
            World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.First().listUnit.Add(o1);
            Assert.IsNull(World.Instance.getUnit(new Position(1, 2)));
            Assert.AreEqual(2, World.Instance.getUnit(new Position(1, 1)).def);
            o0.setDefForUnitTest(5);
            Orc o2 = new Orc(World.Instance.players.First(), World.board.getTile(new Position(1, 2)));
            Orc o3 = new Orc(World.Instance.players.First(), World.board.getTile(new Position(1, 2)));
            Orc o4 = new Orc(World.Instance.players.First(), World.board.getTile(new Position(1, 2)));
            Orc o5 = new Orc(World.Instance.players.First(), World.board.getTile(new Position(1, 2)));
            Orc o6 = new Orc(World.Instance.players.First(), World.board.getTile(new Position(1, 2)));
            Orc o7 = new Orc(World.Instance.players.First(), World.board.getTile(new Position(1, 2)));
            World.Instance.players.First().listUnit.Add(o2);
            World.Instance.players.First().listUnit.Add(o3);
            World.Instance.players.First().listUnit.Add(o4);
            World.Instance.players.First().listUnit.Add(o5);
            World.Instance.players.First().listUnit.Add(o6);
            World.Instance.players.First().listUnit.Add(o7);
            o2.setPvForUnitTest(2);
            o3.setPvForUnitTest(3);
            o4.setPvForUnitTest(4);
            o5.setPvForUnitTest(5);
            o6.setPvForUnitTest(6);
            o7.setPvForUnitTest(7);
            //test de l'unité Random (impossible à tester directement à cause du hasard
            //le test sera fait en regardant les valeurs du débuggage
            //Assert.AreEqual(2, ((Orc)World.Instance.getUnit(new Position(1, 2))).pvOrc);
        }

        [TestMethod]
        public void testgetTile()
        {
            InitAll();
            MonteurDemo m = new MonteurDemo();
            m.createTiles();
            Assert.IsNotNull(World.board.getTile(new Position(1, 1)));
            Assert.IsTrue((new Position(1,1)).equals(World.board.getTile(new Position(1, 1)).position));
        }

        [TestMethod]
        public void testAddPlayer()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            Assert.AreEqual(1, World.Instance.nbPlayer);
            Assert.IsTrue(World.Instance.listType.Contains("Elf"));
            Assert.AreEqual("Jean-Pierre", World.Instance.players.First().nom);
        }

        [ExpectedException(typeof(Exception), "Le type n'est pas valide")]
        [TestMethod]
        public void testWrongTypePlayer()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Perdu");
            Assert.AreEqual(0, World.Instance.nbPlayer);
        }

        [ExpectedException(typeof(Exception), "Le type est déjà utilisé par un autre joueur")]
        [TestMethod]
        public void testWrongTwiceTypePlayer()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Elf");
            Assert.AreEqual(1, World.Instance.nbPlayer);
        }

        [TestMethod]
        public void testremovePlayer()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Orc");
            World.Instance.removePlayer(World.Instance.players.First());
            Assert.IsFalse(World.Instance.stateGame);
        }

        [ExpectedException(typeof(Exception), "Erreur dans la suppression d'un joueur")]
        [TestMethod]
        public void testremovePlayerFail()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Orc");
            World.Instance.removePlayer(null);
        }

        [TestMethod]
        public void testEndGameByNoMoreTurn()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Caathy Couss", "Orc");
            Assert.IsTrue(World.Instance.stateGame);
            Assert.AreEqual("Jean-Pierre", World.Instance.players.First().nom);
            Orc o0 = new Orc(World.Instance.players.ElementAt(1), new Tile(new Position(1, 1)));
            /*o0.setPvForUnitTest(5);
            Assert.AreEqual(5, o0.pvOrc);*/
            Orc o1 = new Orc(World.Instance.players.ElementAt(1), new Tile(new Position(1, 1)));
            Orc o2 = new Orc(World.Instance.players.ElementAt(1), new Tile(new Position(1, 2)));
            Elf e0 = new Elf(World.Instance.players.ElementAt(1), new Tile(new Position(4, 2)));
            Elf e1 = new Elf(World.Instance.players.ElementAt(1), new Tile(new Position(4, 2)));
            World.Instance.players.ElementAt(1).listUnit.Add(o0);
            World.Instance.players.ElementAt(1).listUnit.Add(o1);
            World.Instance.players.ElementAt(1).listUnit.Add(o2);
            World.Instance.players.ElementAt(0).listUnit.Add(e1);
            World.Instance.players.ElementAt(0).listUnit.Add(e0);
            World.Instance.endGame();
            Assert.IsFalse(World.Instance.stateGame);
            Assert.AreEqual(1, World.Instance.players.ElementAt(0).score);
            //Assert.AreEqual(2, World.Instance.players.ElementAt(1).score);
            //Assert.AreEqual("Caathy Couss", World.Instance.gagnant());

            /*foreach (Player p in World.Instance.players)
            {
                p.updateScore();
            }*/
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testEndGameByRemove()
        {
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testUpdateScore()
        {
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void endTurn()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Orc");
            Assert.AreEqual(0, World.Instance.currentPlayer);
            World.Instance.endTurn();
            Assert.AreEqual(1, World.Instance.currentPlayer);
            World.Instance.endTurn();
            Assert.AreEqual(0, World.Instance.currentPlayer);
        }

        [TestMethod]
        public void testEndTurn()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Orc");
            int turn = 0;
            while(turn < 10)
            {
                World.Instance.endTurn();
                turn++;
            }
            Assert.IsFalse(World.Instance.stateGame);
        }

        [TestMethod]
        public void testGagnant()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Caathy Couss", "Orc");
            Assert.IsTrue(World.Instance.stateGame);
            World.Instance.players.First().incScore();
            World.Instance.players.First().incScore();
            World.Instance.players.First().incScore();
            World.Instance.players.First().incScore();
            World.Instance.players.First().incScore();
            World.Instance.players.First().incScore();
            World.Instance.players.ElementAt(1).incScore();
            Orc o0 = new Orc(World.Instance.players.First(), new Tile(new Position(1, 1)));
            o0.setPvForUnitTest(2);
            Orc o1 = new Orc(World.Instance.players.First(), new Tile(new Position(1, 1)));
            World.Instance.endGame();
            Assert.IsFalse(World.Instance.stateGame);
            Assert.AreEqual(3, World.Instance.players.ElementAt(1).score);
            Assert.AreEqual(6, World.Instance.players.ElementAt(0).score);
            Assert.AreEqual("Jean-Pierre", World.Instance.gagnant());
        }

        [TestMethod]
        public void testGagnantNul()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.removePlayer(World.Instance.players.First());
            Assert.IsTrue(World.Instance.stateGame);
            World.Instance.players.First().incScore();
            World.Instance.players.ElementAt(1).incScore();
            Assert.AreEqual("Match null", World.Instance.gagnant());
        }
    }
}
