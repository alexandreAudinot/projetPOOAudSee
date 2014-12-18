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
    public class UnitUnit
    {

        [TestMethod]
        public void testsetDefForUnitTest()
        {
            Player p = new Player("Thorin", 1);
            Dwarf o = new Dwarf(p, new Position(1, 1));
            o.setDefForUnitTest(10);
            Assert.AreEqual(10, o.def);
        }

        [TestMethod]
        public void testsetHPForUnitTest()
        {
            Player p = new Player("Thorin", 1);
            Dwarf o = new Dwarf(p, new Position(1, 1));
            o.setHPForUnitTest(10);
            Assert.AreEqual(10, o.hp);
        }

        [TestMethod]
        public void testInitDeplacement()
        {
            Player p = new Player("Thorin", 1);
            Dwarf o = new Dwarf(p, new Position(1, 1));
            o.initDeplacement();
            Assert.AreEqual(2, o.nbDeplacement);
        }

        [TestMethod]
        public void testIsAlive()
        {
            Player p = new Player("Thorin", 1);
            Dwarf o = new Dwarf(p, new Position(1, 1));
            Assert.AreEqual(true, o.isAlive());
            Dwarf o0 = new Dwarf(p, new Position(1, 1));
            o0.setHPForUnitTest(0);
            Assert.AreEqual(false,  o0.isAlive());
        }

        [TestMethod]
        public void testfight()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testdie()
        {
            UnitTestWorld.InitAll();
            MonteurDemo m = new MonteurDemo();
            m.createTiles();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            Orc o0 = new Orc(World.Instance.players.First(), new Position(1,2));
            Orc o1 = new Orc(World.Instance.players.First(), new Position(1,2));
            World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.First().listUnit.Add(o1);
            World.Instance.players.First().listUnit.First().die();
            Assert.AreEqual(1, World.Instance.players.First().listUnit.Count());
            Assert.AreEqual(2, ((Unit) World.Instance.players.First().listUnit.First()).position.y);
        }

        [TestMethod]
        public void testcheckmove()
        {
            UnitTestWorld.InitAll();
            Player p = new Player("Thorin", 1);
            Dwarf o = new Dwarf(p, new Position(2, 2));
            Assert.IsTrue(o.checkMove(new Position(3, 2)));
            Assert.IsTrue(o.checkMove(new Position(2, 3)));
            Assert.IsTrue(o.checkMove(new Position(1, 2)));
            Assert.IsTrue(o.checkMove(new Position(2, 1)));
            Assert.IsTrue(o.checkMove(new Position(3, 1)));
            Assert.IsTrue(o.checkMove(new Position(1, 3)));
            Assert.IsFalse(o.checkMove(new Position(4, 2)));
            Assert.IsFalse(o.checkMove(new Position(-1, 2)));
            Assert.IsFalse(o.checkMove(new Position(2, -1)));
            Assert.IsFalse(o.checkMove(new Position(250, 2)));
            Assert.IsFalse(o.checkMove(new Position(2, 250)));
        }

        [TestMethod]
        public void testMakeAMove()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testWinFightAtt()
        {
            //TODO
            Assert.IsFalse(true);
        }


        [TestMethod]
        public void testWinFightDef()
        {
            //TODO
            Assert.IsFalse(true);
        }
    }
}
