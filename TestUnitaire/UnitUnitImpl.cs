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
            Player p = new Player("Azog", 1);
            Orc o = new Orc(p, new Tile(new Position(1, 1)));
            o.incPvOrc();
            Assert.IsNotNull(o);
            Assert.AreEqual(1, o.pvOrc);
            Assert.AreEqual(2, o.att);
            Assert.AreEqual(1, o.def);
            Assert.AreEqual(5, o.hp);
            Assert.AreEqual(0, o.nbDeplacement);
            Assert.AreEqual(p, o.controler);
            Assert.IsTrue((new Position(1, 1)).equals(o.position));
            Assert.AreEqual("ProjetPOO.Orc", o.GetType().ToString());
            World.Clean();
        }

        [TestMethod]
        public void testcalcDeplAttOrc()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testcalcDeplOrc()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testwinFightOrc()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testendGameOrc()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testDwarf()
        {
            Player p = new Player("Thorin", 1);
            Dwarf o = new Dwarf(p, new Tile(new Position(1, 1)));
            Assert.IsNotNull(o);
            Assert.AreEqual(2, o.att);
            Assert.AreEqual(1, o.def);
            Assert.AreEqual(5, o.hp);
            Assert.AreEqual(0, o.nbDeplacement);
            Assert.AreEqual(p, o.controler);
            Assert.IsTrue((new Position(1, 1)).equals(o.position));
            Assert.AreEqual("ProjetPOO.Dwarf", o.GetType().ToString());
            World.Clean();
        }

        [TestMethod]
        public void testcalcDeplAttDwarf()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
            public void testcalcDeplOrcDwarf()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
            public void testwinFightDwarf()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
            public void testloseFightDwarf()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
            public void testendGameDwarf()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testElf()
        {
            Player p = new Player("Boucle d'or", 1);
            Elf o = new Elf(p, new Tile(new Position(1, 1)));
            Assert.IsNotNull(o);
            Assert.AreEqual(2, o.att);
            Assert.AreEqual(1, o.def);
            Assert.AreEqual(5, o.hp);
            Assert.AreEqual(0, o.nbDeplacement);
            Assert.AreEqual(p, o.controler);
            Assert.IsTrue((new Position(1, 1)).equals(o.position));
            Assert.AreEqual("ProjetPOO.Elf", o.GetType().ToString());
            World.Clean();
        }

        [TestMethod]
        public void testcalcDeplElf()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testwinFightElf()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testloseFightElf()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testrepliElf()
        {
            //TODO
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testendGameElf()
        {
            //TODO
            Assert.IsFalse(true);
        }
    }
}
