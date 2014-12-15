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
            Player p = new Player("Maurice", 1);
            Orc o0 = new Orc(World.Instance.players.ElementAt(1), new Tile(new Position(1, 2)));
            Orc o1 = new Orc(World.Instance.players.ElementAt(1), new Tile(new Position(1, 1)));
            p.listUnit.Add(o0);
            p.listUnit.Add(o1);
            p.killUnit((Unit) p.listUnit.First());
            Assert.AreEqual(1, p.listUnit.Count);
            Assert.AreEqual(2, ((Unit) p.listUnit.First()).position.y);
            List<Player> l = new List<Player>();
            Player s = l.First();
        }

        [TestMethod]
        public void testKillUnitLose()
        {

            UnitTestWorld.InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Orc");
            //ajouter une unité au joueur1
            //World.Instance.players.First().killUnit();
            Assert.AreEqual("Georgette", World.Instance.players.First().nom);
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
        public void testEndGame()
        {
            UnitTestWorld.InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.removePlayer(World.Instance.players.First());
            Assert.IsTrue(World.stateGame);
            //vérification des points de vistoire à faire + pv orcs
            //création d'unités
            //leur faire faire des combats avec des morts => création de points de victoire
            World.Instance.players.First().incScore();
            World.Instance.players.ElementAt(1).incScore();
            World.Instance.players.ElementAt(1).incScore();
            //faire faire des combats avec des orcs
            //compter les points
        }
    }
}
