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
    public class UnitBoard
    {
        [TestMethod]
        public void testGetTile()
        {
            UnitUnit.InitAll();
            Assert.AreEqual("ProjetPOO.Forest", World.Instance.board.getTile(new Position(1, 1)).GetType().ToString());
            Assert.AreEqual("ProjetPOO.Plain", World.Instance.board.getTile(new Position(2, 2)).GetType().ToString());
        }

        [TestMethod]
        public void testInitBoardDemo()
        {
            DemoBoard b = new DemoBoard();
            Assert.IsNotNull(b);
            Assert.IsNotNull(World.Instance.board);
            Assert.AreEqual(6, World.Instance.board.size);
        }

        [TestMethod]
        public void testInitVarBoardDemo()
        {
            World.Clean();
            AbstractBoard b = new DemoBoard();
            World.Instance.board = b;
            Assert.IsNotNull(World.Instance);
            World.Instance.board.initVarBoard();
            Assert.IsNotNull(World.Instance);
            Assert.AreEqual(5, World.Instance.maxnbTours);
            Assert.AreEqual(4, World.Instance.nbUnity);
            Assert.AreEqual(0, World.Instance.currentPlayer);
        }

        [TestMethod]
        public void testInitBoardSmall()
        {
            SmallBoard b = new SmallBoard();
            Assert.IsNotNull(b);
            Assert.IsNotNull(World.Instance.board);
            Assert.AreEqual(10, World.Instance.board.size);
        }

        [TestMethod]
        public void testInitVarBoardSmall()
        {
            World.Clean();
            AbstractBoard b = new SmallBoard();
            World.Instance.board = b;
            Assert.IsNotNull(World.Instance);
            World.Instance.board.initVarBoard();
            Assert.IsNotNull(World.Instance);
            Assert.AreEqual(20, World.Instance.maxnbTours);
            Assert.AreEqual(6, World.Instance.nbUnity);
            Assert.AreEqual(0, World.Instance.currentPlayer);
        }

        [TestMethod]
        public void testInitBoardNormal()
        {
            NormalBoard b = new NormalBoard();
            Assert.IsNotNull(b);
            Assert.IsNotNull(World.Instance.board);
            Assert.AreEqual(14, World.Instance.board.size);
        }

        [TestMethod]
        public void testInitVarBoardNormal()
        {
            World.Clean();
            AbstractBoard b = new NormalBoard();
            World.Instance.board = b;
            Assert.IsNotNull(World.Instance);
            World.Instance.board.initVarBoard();
            Assert.IsNotNull(World.Instance);
            Assert.AreEqual(30, World.Instance.maxnbTours);
            Assert.AreEqual(8, World.Instance.nbUnity);
            Assert.AreEqual(0, World.Instance.currentPlayer);
        }
    }
}
