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
    public class UnitUnitImpl
    {
        [TestMethod]
        public void testOrc()
        {
            Player p = new Player("Azog",1);
            Orc o = new Orc(p, new Tile(new Position(1, 1)));
            Assert.IsNotNull(o);
            Assert.AreEqual(0, o.pvOrc);
            Assert.AreEqual(2, o.att);
            Assert.AreEqual(1, o.def);
            Assert.AreEqual(5, o.hp);
            Assert.AreEqual(0, o.nbDeplacement);
            Assert.AreEqual(p, o.controler);
            Assert.IsTrue((new Position(1, 1)).equals(o.position));
            World.Clean();
        }

        [TestMethod]
        public void testincPvOrc()
        {
            //TODO
        }

        [TestMethod]
        public void testcalcDeplAttOrc()
        {
            //TODO
        }

        [TestMethod]
        public void testcalcDeplOrc()
        {
            //TODO
        }

        [TestMethod]
        public void testwinFightOrc()
        {
            //TODO
        }

        [TestMethod]
        public void testendGameOrc()
        {
            //TODO
        }

        [TestMethod]
        public void testDwarf()
        {
            //TODO
        }

        [TestMethod]
        public void testcalcDeplAttDwarf()
        {
            //TODO
        }

        [TestMethod]
            public void testcalcDeplOrcDwarf()
        {
            //TODO
        }

        [TestMethod]
            public void testwinFightDwarf()
        {
            //TODO
        }

        [TestMethod]
            public void testloseFightDwarf()
        {
            //TODO
        }

        [TestMethod]
            public void testendGameDwarf()
        {
            //TODO
        }

        [TestMethod]
        public void testElf()
        {
            //TODO
        }

        [TestMethod]
        public void testcalcDeplElf()
        {
            //TODO
        }

        [TestMethod]
        public void testwinFightElf()
        {
            //TODO
        }

        [TestMethod]
        public void testloseFightElf()
        {
            //TODO
        }

        [TestMethod]
        public void testrepliElf()
        {
            //TODO
        }

        [TestMethod]
        public void testendGameElf()
        {
            //TODO
        }
    }
}
