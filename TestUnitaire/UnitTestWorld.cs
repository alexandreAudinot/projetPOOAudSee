using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetPOO;
using System.Collections;
using System.Collections.Generic;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTestWorld
    {

        [TestMethod]
        public void testWorldBoard()
        {
            Board b = new DemoBoard();
            World world = new World(b);
            Assert.IsNotNull(world);
            Assert.AreEqual(World.Instance.nbPlayer, 0);
            Assert.IsTrue(World.stateGame);
            Assert.AreEqual(b, World.board);
            Assert.AreEqual(World.Instance.nbTours, 0);
            Assert.IsNotNull(World.Instance.listType);
            Assert.IsNotNull(World.Instance.listAvailableType);
            Assert.IsNotNull(World.Instance.players);
        }

        [TestMethod]
        public void testWorldBoard2()
        {
            Board b = new DemoBoard();
            World world = new World(b);
            b.initBoard();
            World.board.initVarBoard();
            Assert.AreEqual(World.Instance.maxnbTours, 5);
            World world2 = new World(world, World.board);
            Assert.IsNotNull(world2);
            Assert.AreEqual(World.Instance.nbPlayer, 0);
            Assert.IsTrue(World.stateGame);
            Assert.AreEqual(b, World.board);
            Assert.AreEqual(World.Instance.nbTours, 0);
            Assert.IsNotNull(World.Instance.listType);
            Assert.IsNotNull(World.Instance.listAvailableType);
            Assert.IsNotNull(World.Instance.players);
            //Assert.AreEqual(World.Instance.maxnbTours, 5);
            /*Assert.AreEqual(World.Instance.nbUnity, 4);
            Assert.AreEqual(World.Instance.currentPlayer, 0);*/
        }      

        [TestMethod]
        public void testWorldVar()
        {
            Board b = new DemoBoard();
            World world = new World(b);
            b.initBoard();
            World.board.initVarBoard();
            Assert.AreEqual(World.Instance.maxnbTours, 5);
            Assert.AreEqual(World.Instance.nbUnity, 4);
            Assert.AreEqual(World.Instance.currentPlayer, 0);
        }

        [TestMethod]
        public void testInitType()
        {
            World w0 = new World(new DemoBoard());
            List<String> l = new List<string>();
            Assert.IsTrue(World.Instance.listAvailableType.Contains("Orc"));
            Assert.IsTrue(World.Instance.listAvailableType.Contains("Dwarf"));
            Assert.IsTrue(World.Instance.listAvailableType.Contains("Elf"));
            Assert.AreEqual(World.Instance.listAvailableType.Count, 3);
        }

        [TestMethod]
        public void testUniteBool()
        {
            //TODO
        }

        [TestMethod]
        public void testGetUnit()
        {
            //TODO
        }

        [TestMethod]
        public void testgetTile()
        {
            //TODO
        }

        [TestMethod]
        public void testAddPlayer()
        {
            World w0 = new World(new DemoBoard());
            //w0.addPlayer("Jean-Pierre", "Elfe");
            Assert.IsNotNull(w0);
        }

        [TestMethod]
        public void removePlayer()
        {
            //TODO
        }

        [TestMethod]
        public void endGame()
        {
            //TODO
        }

        [TestMethod]
        public void endTurn()
        {
            //TODO
        }
    }
}
