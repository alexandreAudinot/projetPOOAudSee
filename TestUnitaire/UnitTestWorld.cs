using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetPOO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* ---------------------------------------------------------------------------------------------- *
 * ---------------------------------------------------------------------------------------------- *
 * --- Classe test validée - Classe test validée - Classe test validée -  Classe test validée --- *
 * ---------------------------------------------------------------------------------------------- *
 * ---------------------------------------------------------------------------------------------- */

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
            Assert.AreEqual(-1, World.Instance.repliCurrentPlayer);
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
            World.Instance.addPlayer("Jean-Pierre", "Orc");
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(),new Position(1,1)));
            Assert.IsTrue(World.Instance.unitBool(new Position(1, 1)));
            Assert.IsFalse(World.Instance.unitBool(new Position(1, 2)));
        }

        [TestMethod]
        public void testCanMove()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Orc");
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), new Position(2, 2)));
            Assert.IsTrue(((Unit)World.Instance.players.First().listUnit.First()).canMove());
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), new Position(1, 2)));
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), new Position(2, 1)));
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), new Position(3, 2)));
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), new Position(2, 3)));
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), new Position(1, 3)));
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), new Position(3, 1)));
            Assert.IsFalse(((Unit)World.Instance.players.First().listUnit.First()).canMove());
        }

        [TestMethod]
        public void testGetUnit()
        {
            InitAll();
            MonteurDemo m = new MonteurDemo();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            Orc o0 = new Orc(World.Instance.players.First(), new Position(1, 1));
            Orc o1 = new Orc(World.Instance.players.First(), new Position(1, 1));
            o0.setDefForUnitTest(2);
            World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.First().listUnit.Add(o1);
            Assert.IsNull(World.Instance.getUnit(new Position(1, 2)));
            Assert.AreEqual(2, World.Instance.getUnit(new Position(1, 1)).def);
            o0.setDefForUnitTest(5);
            Orc o2 = new Orc(World.Instance.players.First(), new Position(1, 1));
            Orc o3 = new Orc(World.Instance.players.First(), new Position(1, 1));
            Orc o4 = new Orc(World.Instance.players.First(), new Position(1, 1));
            Orc o5 = new Orc(World.Instance.players.First(), new Position(1, 1));
            Orc o6 = new Orc(World.Instance.players.First(), new Position(1, 1));
            Orc o7 = new Orc(World.Instance.players.First(), new Position(1, 1));
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
            Assert.IsNotNull(World.board.getTile(new Position(1, 1)));
            Assert.AreEqual(World.board.Tiles[1, 1], World.board.getTile(new Position(1, 1)));
        }

        [TestMethod]
        public void testAddPlayer()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            Assert.AreEqual(1, World.Instance.nbPlayer);
            Assert.IsTrue(World.Instance.listType.Contains("Elf"));
            Assert.AreEqual("Jean-Pierre", World.Instance.players.First().nom);
            Assert.IsTrue(new Position(1, 1).equals(World.Instance.players.First().pDepart));
        }

        [ExpectedException(typeof(Exception), "Le type n'est pas valide")]
        [TestMethod]
        public void testWrongTypePlayer()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Perdu");
            Assert.AreEqual(0, World.Instance.nbPlayer);
            Assert.IsFalse(true);
        }

        [ExpectedException(typeof(Exception), "Le type est déjà utilisé par un autre joueur")]
        [TestMethod]
        public void testWrongTwiceTypePlayer()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Elf");
            Assert.AreEqual(1, World.Instance.nbPlayer);
            Assert.IsFalse(true);
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
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testEndGameByNoMoreTurn()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Orc");
            int turn = 0;
            while (turn < 10)
            {
                World.Instance.endTurn();
                turn++;
            }
            Assert.IsFalse(World.Instance.stateGame);
        }

        [TestMethod]
        public void testEndGameByRemove()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Orc");
            World.Instance.players.ElementAt(1).listUnit.Add(new Orc(World.Instance.players.ElementAt(1), new Position(2, 2)));
            World.Instance.players.ElementAt(1).score = 2;
            World.Instance.removePlayer(World.Instance.players.First());
            Assert.IsFalse(World.Instance.stateGame);
            Assert.AreEqual(1, World.Instance.players.First().score);
        }

        [TestMethod]
        public void testUpdateScore()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Les nains sentent mauvais", "Elf");
            World.Instance.addPlayer("No man can kill me", "Orc");
            Elf e = new Elf(World.Instance.players.First(), new Position(1, 0));
            Elf e1 = new Elf(World.Instance.players.First(), new Position(1, 3));
            World.Instance.players.ElementAt(0).listUnit.Add(e);
            World.Instance.players.ElementAt(0).listUnit.Add(e1);
            Orc o = new Orc(World.Instance.players.ElementAt(1), new Position(1, 1));
            o.setPvForUnitTest(9);
            Orc o0 = new Orc(World.Instance.players.ElementAt(1), new Position(1, 1));
            o0.setPvForUnitTest(0);
            World.Instance.players.ElementAt(1).listUnit.Add(o);
            World.Instance.players.ElementAt(1).listUnit.Add(o0);
            World.Instance.players.First().score = 2;
            World.Instance.players.ElementAt(1).score = 0;
            World.Instance.updateScore();
            Assert.AreEqual(2, World.Instance.players.First().score);
            Assert.AreEqual(0, World.Instance.players.ElementAt(1).score);
        }

        [TestMethod]
        public void testEndTurn()
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
        public void testGagnantRemove()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Caathy Couss", "Orc");
            World.Instance.removePlayer(World.Instance.players.First());
            Assert.AreEqual("Caathy Couss", World.Instance.gagnant());
        }

        [TestMethod]
        public void testGagnantTurn()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Caathy Couss", "Orc");
            World.Instance.players.First().incScore();
            Assert.AreEqual(1, World.Instance.players.First().score);
            Assert.AreEqual("Jean-Pierre", World.Instance.gagnant());
        }

        [TestMethod]
        public void testGagnantNul()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Caathy Couss", "Orc");
            Assert.AreEqual("Match nul", World.Instance.gagnant());
        }
    }
}
