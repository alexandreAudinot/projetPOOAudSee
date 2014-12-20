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
    public class UnitBoard
    {
        [TestMethod]
        public void testGetTile()
        {
            UnitUnit.InitAll();
            Assert.AreEqual("ProjetPOO.Forest", World.board.getTile(new Position(1, 1)).GetType().ToString());
            Assert.AreEqual("ProjetPOO.Plain", World.board.getTile(new Position(2, 2)).GetType().ToString());
        }

        [TestMethod]
        public void testInitBoardDemo()
        {
            World.Clean();
            AbstractBoard b = new DemoBoard();
            World.board = b;
            Assert.IsNotNull(World.Instance);
            Assert.IsNotNull(World.board);
            //Assert.IsNotNull(World.board.forest);
            World.board.initBoard();
            World.board.initVarBoard();
            Assert.IsNotNull(World.Instance);
        }

        [TestMethod]
        public void testInitVarBoardDemo()
        {
            World.Clean();
            AbstractBoard b = new DemoBoard();
            World.board = b;
            Assert.IsNotNull(World.Instance);
            World.board.initBoard();
            World.board.initVarBoard();
            Assert.IsNotNull(World.Instance);
            Assert.AreEqual(5, World.Instance.maxnbTours);
            Assert.AreEqual(4, World.Instance.nbUnity);
            Assert.AreEqual(0, World.Instance.currentPlayer);
        }

        [TestMethod]
        public void testInitBoardSmall()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testInitVarBoardSmall()
        {
            World.Clean();
            AbstractBoard b = new SmallBoard();
            World.board = b;
            Assert.IsNotNull(World.Instance);
            World.board.initBoard();
            World.board.initVarBoard();
            Assert.IsNotNull(World.Instance);
            Assert.AreEqual(20, World.Instance.maxnbTours);
            Assert.AreEqual(6, World.Instance.nbUnity);
            Assert.AreEqual(0, World.Instance.currentPlayer);
        }

        [TestMethod]
        public void testInitBoardNormal()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testInitVarBoardNormal()
        {
            World.Clean();
            AbstractBoard b = new NormalBoard();
            World.board = b;
            Assert.IsNotNull(World.Instance);
            World.board.initBoard();
            World.board.initVarBoard();
            Assert.IsNotNull(World.Instance);
            Assert.AreEqual(30, World.Instance.maxnbTours);
            Assert.AreEqual(8, World.Instance.nbUnity);
            Assert.AreEqual(0, World.Instance.currentPlayer);
        }
    }
}
