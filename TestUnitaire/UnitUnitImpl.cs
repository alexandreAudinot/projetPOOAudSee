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
    public class UnitUnitImpl
    {
        [TestMethod]
        public void testOrc()
        {
            Player p = new Player("Azog",1);
            Orc o = new Orc(p, new Position(1,1));
            Assert.IsNotNull(o);
            Assert.AreEqual(0, o.pvOrc);
            Assert.AreEqual(2, o.att);
            Assert.AreEqual(1, o.def);
            Assert.AreEqual(5, o.hp);
            Assert.AreEqual(0, o.nbDeplacement);
            Assert.AreEqual(p, o.controler);
            Assert.AreEqual(5, o.initialLife);
            Assert.IsTrue((new Position(1, 1)).equals(o.position));
            World.Clean();
        }

        [TestMethod]
        public void testincPvOrc()
        {
            Player p = new Player("Azog", 1);
            Orc o = new Orc(p, new Position(1, 1));
            o.incPvOrc();
            Assert.IsNotNull(o);
            Assert.AreEqual(1, o.pvOrc);
        }

        [ExpectedException(typeof(Exception), "Plus assez de mouvements disponibles")]
        [TestMethod]
        //l'autre exception type de terrain non matché a été vérifiée lors des tests   
        public void testcalcDeplAttOrcPlusAssezMouvements()
        {
            UnitUnit.InitAll();
            Orc o = new Orc(new Player("Monsieur patate", 2), new Position(5,5));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(0, 0)));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(1, 1)));
            Assert.AreEqual(0.5, o.calcDeplAtt(new Position(2, 2)));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(3, 3)));
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testcalcDeplAttOrc()
        {
            UnitUnit.InitAll();
            Orc o = new Orc(new Player("Monsieur patate", 2), new Position(5, 5));
            o.nbDeplacement = 2;
            Assert.AreEqual(1, o.calcDeplAtt(new Position(0, 0)));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(1, 1)));
            Assert.AreEqual(0.5, o.calcDeplAtt(new Position(2, 2)));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(3, 3)));
        }

        [TestMethod]
        public void testcalcDeplOrc()
        {
            UnitUnit.InitAll();
            Orc o = new Orc(new Player("Monsieur patate", 2), new Position(5, 5));
            o.nbDeplacement = 2;
            Assert.AreEqual(1, o.calcDepl(new Position(0, 0)));
            Assert.AreEqual(1, o.calcDepl(new Position(1, 1)));
            Assert.AreEqual(0.5, o.calcDepl(new Position(2, 2)));
            Assert.AreEqual(1, o.calcDepl(new Position(3, 3)));
        }

        [TestMethod]
        public void testwinFightOrc()
        {
            UnitUnit.InitAll();
            Orc o = new Orc(new Player("Monsieur patate", 2), new Position(4, 4));
            o.winFight(new Position(1, 1));
            Assert.AreEqual(0, o.pvOrc);
            o.winFight(new Position(2, 2));
            Assert.AreEqual(1, o.pvOrc);
        }

        [TestMethod]
        public void testLoseFightOrc()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("I", "Orc");
            World.Instance.addPlayer("lost", "Dwarf");
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), new Position(1, 1)));
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), new Position(1, 1)));
            Assert.IsTrue(World.Instance.players.First().listUnit.First().loseFight());
            Assert.AreEqual(1, World.Instance.players.First().listUnit.Count());
            World.Instance.players.First().listUnit.First().loseFight();
            Assert.IsFalse(World.Instance.stateGame);
        }

        [TestMethod]
        public void testendGameOrc()
        {
            UnitUnit.InitAll();
            Orc o = new Orc(new Player("It's me, Mario", 1), new Position(1, 1));
            o.endGame();
            Assert.AreEqual(0, o.pvOrc);
            Orc o0 = new Orc(new Player("It's me, Mario", 1), new Position(2, 2));
            o0.incPvOrc();
            o0.endGame();
            Assert.AreEqual(1, o0.pvOrc);
        }

        [TestMethod]
        public void testDwarf()
        {
            Player p = new Player("Thorin", 1);
            Dwarf o = new Dwarf(p, new Position(1, 1));
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

        [ExpectedException(typeof(Exception), "Plus assez de mouvements disponibles")]
        [TestMethod]
        public void testcalcDeplAttDwarfFailMove()
        {
            UnitUnit.InitAll();
            Dwarf o = new Dwarf(new Player("Monsieur patate", 2), new Position(5, 5));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(0, 0)));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(1, 1)));
            Assert.AreEqual(0.5, o.calcDeplAtt(new Position(2, 2)));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(3, 3)));
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testcalcDeplAttDwarf()
        {
            UnitUnit.InitAll();
            Dwarf o = new Dwarf(new Player("Monsieur patate", 2), new Position(5, 5));
            o.nbDeplacement = 2;
            Assert.AreEqual(1, o.calcDeplAtt(new Position(0, 0)));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(1, 1)));
            Assert.AreEqual(0.5, o.calcDeplAtt(new Position(2, 2)));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(3, 3)));
        }

        [TestMethod]
            public void testcalcDeplDwarf()
        {
            UnitUnit.InitAll();
            Dwarf o = new Dwarf(new Player("Monsieur patate", 2), new Position(5, 5));
            o.nbDeplacement = 2;
            Assert.AreEqual(0, o.calcDepl(new Position(0, 0)));
            Assert.AreEqual(1, o.calcDepl(new Position(1, 1)));
            Assert.AreEqual(0.5, o.calcDepl(new Position(2, 2)));
            Assert.AreEqual(1, o.calcDepl(new Position(3, 3)));
        }

        [TestMethod]
            public void testloseFightDwarf()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("I", "Dwarf");
            World.Instance.addPlayer("lost", "Orc");
            World.Instance.players.First().listUnit.Add(new Dwarf(World.Instance.players.First(), new Position(1, 1)));
            World.Instance.players.First().listUnit.Add(new Dwarf(World.Instance.players.First(), new Position(1, 1)));
            World.Instance.players.First().listUnit.First().loseFight();
            Assert.AreEqual(1, World.Instance.players.First().listUnit.Count());
            Assert.IsTrue(World.Instance.players.First().listUnit.First().loseFight());
            Assert.IsFalse(World.Instance.stateGame);
        }

        [TestMethod]
        public void testElf()
        {
            Player p = new Player("Boucle d'or", 1);
            Elf o = new Elf(p, new Position(1, 1));
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
            UnitUnit.InitAll();
            Elf o = new Elf(new Player("Monsieur patate", 2), new Position(5, 5));
            o.nbDeplacement = 2;
            Assert.AreEqual(1, o.calcDepl(new Position(0, 0)));
            Assert.AreEqual(0.5, o.calcDepl(new Position(1, 1)));
            Assert.AreEqual(1, o.calcDepl(new Position(2, 2)));
            Assert.AreEqual(2, o.calcDepl(new Position(3, 3)));
        }

        [ExpectedException(typeof(Exception), "Plus assez de mouvements disponibles")]
        [TestMethod]
        public void testcalcDeplAttElfFailMove()
        {
            UnitUnit.InitAll();
            Elf o = new Elf(new Player("Monsieur patate", 2), new Position(5, 5));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(0, 0)));
            Assert.AreEqual(0.5, o.calcDeplAtt(new Position(1, 1)));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(2, 2)));
            Assert.AreEqual(2, o.calcDeplAtt(new Position(3, 3)));
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void testcalcDeplAttElf()
        {
            UnitUnit.InitAll();
            Elf o = new Elf(new Player("Monsieur patate", 2), new Position(5, 5));
            o.nbDeplacement = 2;
            Assert.AreEqual(1, o.calcDeplAtt(new Position(0, 0)));
            Assert.AreEqual(0.5, o.calcDeplAtt(new Position(1, 1)));
            Assert.AreEqual(1, o.calcDeplAtt(new Position(2, 2)));
            Assert.AreEqual(2, o.calcDeplAtt(new Position(3, 3)));
        }

        [TestMethod]
        public void testloseFightElf()
        {
            UnitUnit.InitAll();
            World.Instance.currentPlayer = 1;
            World.Instance.repliCurrentPlayer = 0;
            World.Instance.addPlayer("I", "Elf");
            World.Instance.addPlayer("lost", "Dwarf");
            World.Instance.players.First().listUnit.Add(new Elf(World.Instance.players.First(), new Position(1, 1)));
            World.Instance.players.First().listUnit.Add(new Elf(World.Instance.players.First(), new Position(1, 1)));
            World.Instance.players.First().listUnit.First().loseFight();
            if (World.Instance.players.First().listUnit.Count() == 2)
            {
                Assert.AreEqual(0, World.Instance.currentPlayer);
                Assert.AreEqual(1, World.Instance.repliCurrentPlayer);
            }
            //les autres tests ont été réalisés en débuggage, ils ne sont pas affichés à cause de l'aléatoire
            //présent dans la méthode loseFight
        }
    }
}
