using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetPOO;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTestWorld
    {

        [TestMethod]
        public void initWorldConstructeur()
        {
            Board b = new DemoBoard();
            World world = new World(b);
            Assert.IsNotNull(world);
            Assert.AreEqual(world.nbPlayer, 0);
            Assert.IsTrue(World.stateGame);
            Assert.AreEqual(b, World.board);
            Assert.AreEqual(world.nbTours, 0);
            Assert.IsNotNull(world.listType);
            Assert.IsNotNull(World.Instance.players);

        }

        [TestMethod]
        public void initWorldConstructeurTotal()
        {
            Board b = new DemoBoard();
            World world = new World(b);
            b.initBoard();
            Assert.IsNotNull(world);
            World.board.initVarBoard();
            //initial tests
            Assert.AreEqual(World.Instance.nbPlayer, 0);
            Assert.IsTrue(World.stateGame);
            Assert.AreEqual(b, World.board);
            Assert.AreEqual(World.Instance.nbTours, 0);
            Assert.IsNotNull(World.Instance.listType);
            Assert.IsNotNull(World.Instance.players);
            //new tests
            Assert.IsNotNull(World.Instance);
            Assert.AreEqual(World.Instance.nbTours, 0);
            Assert.AreEqual(World.Instance.maxnbTours, 5);
            Assert.AreEqual(World.Instance.nbUnity, 4);
            Assert.AreEqual(World.Instance.nbPlayer, 0);
            Assert.AreEqual(World.Instance.currentPlayer, 0);

        }


        [TestMethod]
        public void initPlayer()
        {
            World w0 = new World(new DemoBoard());
            //w0.addPlayer("Jean-Pierre", "Elfe");
            Assert.IsNotNull(w0);
        }
    }
}
