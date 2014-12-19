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
    public class UnitTestPlayer
    {
        [TestMethod]
        public void testPlayer()
        {
            Player p = new Player("Maurice", 1);
            Assert.AreEqual(0, p.score);
            Assert.AreEqual("Maurice", p.nom);
            Assert.AreEqual(1, p.numero);
            Assert.IsNotNull(p.listUnit);
        }

        [TestMethod]
        public void testIncScore()
        {
            Player p = new Player("Maurice", 1);
            p.incScore();
            Assert.AreEqual(1, p.score);
        }

        [TestMethod]
        public void testKillUnit()
        {
            UnitTestWorld.InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Caathy Couss", "Orc");
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), new Position(1, 1)));
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), new Position(1, 2)));
            World.Instance.players.First().killUnit((Unit)World.Instance.players.First().listUnit.First());
            Assert.AreEqual(1, World.Instance.players.First().listUnit.Count());
            Assert.AreEqual(2, ((Unit)World.Instance.players.First().listUnit.First()).position.y);
            World.Instance.players.First().killUnit((Unit)World.Instance.players.First().listUnit.First());
            Assert.AreEqual(1, World.Instance.players.Count());
        }

        [TestMethod]
        public void testKillUnitLose()
        {
            UnitTestWorld.InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Caathy Couss", "Orc");
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), new Position(1, 1)));
            World.Instance.players.First().killUnit((Unit)World.Instance.players.First().listUnit.First());
            Assert.AreEqual(1, World.Instance.players.Count());
        }

        [TestMethod]
        public void testlose()
        {
            UnitTestWorld.InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Orc");
            World.Instance.players.First().lose();
            Assert.AreEqual("Georgette", World.Instance.players.First().nom);
        }

        [TestMethod]
        public void testupdateSpecialPv()
        {
            UnitTestWorld.InitAll();
            World.Instance.addPlayer("Legolas a toujours des flèches", "Elf");
            World.Instance.addPlayer("Il va mourir à la fin", "Orc");
            Orc o = new Orc(World.Instance.players.ElementAt(1), new Position(1, 1));
            o.setPvForUnitTest(2);
            Orc o0 = new Orc(World.Instance.players.ElementAt(1), new Position(1, 1));
            o0.setPvForUnitTest(1);
            World.Instance.players.ElementAt(1).listUnit.Add(o);
            World.Instance.players.ElementAt(1).listUnit.Add(o0);
            World.Instance.players.First().score = 2;
            World.Instance.players.ElementAt(1).score = 0;
            World.Instance.players.First().updateSpecialPv();
            World.Instance.players.ElementAt(1).updateSpecialPv();
            Assert.AreEqual(2, World.Instance.players.First().score);
            Assert.AreEqual(3, World.Instance.players.ElementAt(1).score);
        }

        //teste aussi updateScoreOrc
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
            Orc o = new Orc(World.Instance.players.ElementAt(1), new Position(2, 2));
            o.setPvForUnitTest(9);
            Orc o0 = new Orc(World.Instance.players.ElementAt(1), new Position(2, 2));
            o0.setPvForUnitTest(0);
            World.Instance.players.ElementAt(1).listUnit.Add(o);
            World.Instance.players.ElementAt(1).listUnit.Add(o0);
            World.Instance.players.First().score = 2;
            World.Instance.players.ElementAt(1).score = 0;
            World.Instance.players.First().updateScore();
            World.Instance.players.ElementAt(1).updateScore();
            Assert.AreEqual(2, World.Instance.players.First().score);
            Assert.AreEqual(10, World.Instance.players.ElementAt(1).score);
        }

        //teste updateScoreDwarf sans plaine
        [TestMethod]
        public void testUpdateScoreForDwarves()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Les nains sentent mauvais", "Dwarf");
            Dwarf e = new Dwarf(World.Instance.players.First(), new Position(1, 1));
            Dwarf e1 = new Dwarf(World.Instance.players.First(), new Position(3, 3));
            World.Instance.players.ElementAt(0).listUnit.Add(e);
            World.Instance.players.ElementAt(0).listUnit.Add(e1);
            World.Instance.players.First().score = 2;
            World.Instance.players.First().updateScore();
            Assert.AreEqual(2, World.Instance.players.First().score);
        }

        //teste updateScoreDwarf avec plaine
        [TestMethod]
        public void testUpdateScoreForDwarvesPlain()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Les nains sentent mauvais", "Dwarf");
            Dwarf e = new Dwarf(World.Instance.players.First(), new Position(2, 2));
            Dwarf e1 = new Dwarf(World.Instance.players.First(), new Position(1, 1));
            World.Instance.players.ElementAt(0).listUnit.Add(e);
            World.Instance.players.ElementAt(0).listUnit.Add(e1);
            World.Instance.players.First().score = 2;
            World.Instance.players.First().updateScore();
            Assert.AreEqual(1, World.Instance.players.First().score);
        }

        //teste aussi updateScoreOrc
        [TestMethod]
        public void testUpdateScoreForest()
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
            Orc o0 = new Orc(World.Instance.players.ElementAt(1), new Position(2, 2));
            o0.setPvForUnitTest(0);
            World.Instance.players.ElementAt(1).listUnit.Add(o);
            World.Instance.players.ElementAt(1).listUnit.Add(o0);
            World.Instance.players.First().score = 2;
            World.Instance.players.ElementAt(1).score = 0;
            World.Instance.players.First().updateScore();
            World.Instance.players.ElementAt(1).updateScore();
            Assert.AreEqual(2, World.Instance.players.First().score);
            Assert.AreEqual(1, World.Instance.players.ElementAt(1).score);
        }

    }
}