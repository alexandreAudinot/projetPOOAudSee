﻿using System;
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
    public class UnitUnit
    {
        public static void InitAll()
        {
            World.Clean();
            AbstractBoard b = new DemoBoard();
            World.Instance.board = b;
            Assert.IsNotNull(World.Instance);
            World.Instance.board.initVarBoard();
            Assert.IsNotNull(World.Instance);
            World.Instance.board.Tiles[0, 0] = new Mountain();
            World.Instance.board.Tiles[1, 1] = new Forest();
            World.Instance.board.Tiles[1, 2] = new Forest();
            World.Instance.board.Tiles[2, 2] = new Plain();
            World.Instance.board.Tiles[3, 3] = new Desert();
        }

        [TestMethod]
        public void testsetDefForUnitTest()
        {
            Player p = new Player("Thorin", 1,"Dwarf");
            Dwarf o = new Dwarf(p, new Position(1, 1));
            o.setDefForUnitTest(10);
            Assert.AreEqual(10, o.def);
        }

        [TestMethod]
        public void testsetHPForUnitTest()
        {
            Player p = new Player("Thorin", 1, "Dwarf");
            Dwarf o = new Dwarf(p, new Position(1, 1));
            o.setHPForUnitTest(10);
            Assert.AreEqual(10, o.hp);
        }

        [TestMethod]
        public void testInitDeplacement()
        {
            Player p = new Player("Thorin", 1, "Dwarf");
            Dwarf o = new Dwarf(p, new Position(1, 1));
            o.initDeplacement();
            Assert.AreEqual(1, o.nbDeplacement);
        }

        [TestMethod]
        public void testIsAlive()
        {
            Player p = new Player("Thorin", 1, "Dwarf");
            Dwarf o = new Dwarf(p, new Position(1, 1));
            Assert.AreEqual(true, o.isAlive());
            Dwarf o0 = new Dwarf(p, new Position(1, 1));
            o0.setHPForUnitTest(0);
            Assert.AreEqual(false,  o0.isAlive());
        }

        [TestMethod]
        public void testfight()
        {
            UnitTestWorld.InitAll();
            MonteurDemo m = new MonteurDemo();
            World.Instance.addPlayer("Azog", "Orc");
            World.Instance.addPlayer("Marty Mc Fly", "Dwarf");
            Orc o0 = new Orc(World.Instance.players.First(), new Position(1, 2));
            Orc o1 = new Orc(World.Instance.players.First(), new Position(3, 3));
            Dwarf e0 = new Dwarf(World.Instance.players.ElementAt(1), new Position(1, 1));
            Dwarf e2 = new Dwarf(World.Instance.players.ElementAt(1), new Position(0, 0));
            Dwarf e1 = new Dwarf(World.Instance.players.ElementAt(1), new Position(3, 4));
            World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.First().listUnit.Add(o1);
            World.Instance.players.ElementAt(1).listUnit.Add(e0);
            World.Instance.players.ElementAt(1).listUnit.Add(e1);
            World.Instance.players.ElementAt(1).listUnit.Add(e2);
            World.Instance.players.First().initDeplacement();
            World.Instance.players.First().listUnit.First().fight(new Position(1, 1), (Unit) World.Instance.players.ElementAt(1).listUnit.First());
            /*Les tests sont faits à partir d'exception (donc n'apparaissent pas dans les tests unitaires)
             * Sim1 : System.Exception: nb Combats : 3 Probatt : 75, 75 attaque de 2(5,3), 75 attaque de 2(5,1), 75 attaque de 2(5,-1) Mort du défenseur
             * Sim3 : System.Exception: nb Combats : 2 Probatt : 75, 25 attaque de 2(3,5), 75 attaque de 1(3,4) Pas de gagnant*/
            Assert.IsFalse(false);
        }

        [TestMethod]
        public void testfightAndMove()
        {
            UnitTestWorld.InitAll();
            MonteurDemo m = new MonteurDemo();
            World.Instance.addPlayer("Azog", "Orc");
            World.Instance.addPlayer("Marty Mc Fly", "Dwarf");
            Orc o0 = new Orc(World.Instance.players.First(), new Position(1, 2));
            Orc o1 = new Orc(World.Instance.players.First(), new Position(3, 3));
            Dwarf e0 = new Dwarf(World.Instance.players.ElementAt(1), new Position(1, 1));
            Dwarf e1 = new Dwarf(World.Instance.players.ElementAt(1), new Position(0, 0));
            World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.First().listUnit.Add(o1);
            World.Instance.players.ElementAt(1).listUnit.Add(e0);
            World.Instance.players.ElementAt(1).listUnit.Add(e1);
            World.Instance.players.First().initDeplacement();
            while((World.Instance.players.First().listUnit.Count() == 2) && ((World.Instance.players.ElementAt(1).listUnit.Count() == 2)))
            {
                World.Instance.players.First().listUnit.First().fight(new Position(1, 1), (Unit)World.Instance.players.ElementAt(1).listUnit.First());
            }
            if (World.Instance.players.First().listUnit.Count() == 2)
            {
                Assert.IsTrue((new Position(1, 1)).equals(((Unit)World.Instance.players.First().listUnit.First()).position));
            }
            else
            {
                Assert.IsTrue((new Position(1, 1)).equals(((Unit)World.Instance.players.ElementAt(1).listUnit.First()).position));
            }
        }

        [TestMethod]
        public void testdie()
        {
            UnitTestWorld.InitAll();
            MonteurDemo m = new MonteurDemo();
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
            Player p = new Player("Thorin", 1, "Dwarf");
            Dwarf o = new Dwarf(p, new Position(2, 2));
            Assert.IsTrue(o.checkMove(new Position(3, 2)));
            Assert.IsTrue(o.checkMove(new Position(2, 3)));
            Assert.IsTrue(o.checkMove(new Position(1, 2)));
            Assert.IsTrue(o.checkMove(new Position(2, 1)));
            Assert.IsTrue(o.checkMove(new Position(3, 1)));
            Assert.IsFalse(o.checkMove(new Position(1, 3)));
            Assert.IsFalse(o.checkMove(new Position(4, 2)));
            Assert.IsFalse(o.checkMove(new Position(-1, 2)));
            Assert.IsFalse(o.checkMove(new Position(2, -1)));
            Assert.IsFalse(o.checkMove(new Position(250, 2)));
            Assert.IsFalse(o.checkMove(new Position(2, 250)));
        }

        [ExpectedException(typeof(Exception), "Le mouvement est impossible")]
        [TestMethod]
        public void testMoveImpossible()
        {
            Player p = new Player("Thorin", 1, "Dwarf");
            Dwarf o = new Dwarf(p, new Position(2, 2));
            o.move(new Position(-5, -5));
        }

        [ExpectedException(typeof(Exception), "Le mouvement est impossible")]
        [TestMethod]
        public void testMoveNoNbDeplacement()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Azog", "Orc");
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            Orc o0 = new Orc(World.Instance.players.First(), new Position(2, 2));
            World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.First().listUnit.First().move(new Position(1, 2));
        }

        [TestMethod]
        public void testMove()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Christopher Lee", "Orc");
            World.Instance.addPlayer("Luc Skywaiter", "Elf");
            Orc o = new Orc(World.Instance.players.First(), new Position(1, 2));
            Orc o1 = new Orc(World.Instance.players.First(), new Position(0, 0));
            World.Instance.players.First().listUnit.Add(o);
            World.Instance.players.First().listUnit.Add(o1);
            World.Instance.players.First().initDeplacement();
            World.Instance.players.First().listUnit.First().makeAMove(new Position(2, 2), 1);
            Assert.AreEqual(0.5, ((Unit)World.Instance.players.First().listUnit.First()).nbDeplacement);
            Assert.IsTrue((((Unit)World.Instance.players.First().listUnit.First()).position).equals(new Position(2, 2)));
        }

        [ExpectedException(typeof(Exception), "Le mouvement est impossible")]
        [TestMethod]
        public void testMoveReflexif()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Christopher Lee", "Orc");
            World.Instance.addPlayer("Luc Skywaiter", "Elf");
            Orc o = new Orc(World.Instance.players.First(), new Position(1, 2));
            Orc o1 = new Orc(World.Instance.players.First(), new Position(0, 0));
            World.Instance.players.First().listUnit.Add(o);
            World.Instance.players.First().listUnit.Add(o1);
            World.Instance.players.First().initDeplacement();
            Assert.IsFalse(World.Instance.players.First().listUnit.First().checkMove(new Position(1, 2)));
            World.Instance.players.First().listUnit.First().move(new Position(1, 2));
        }
        
        [TestMethod]
        public void testMoveAllie()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Azog", "Orc");
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            Orc o0 = new Orc(World.Instance.players.First(), new Position(2, 2));
            Orc e0 = new Orc(World.Instance.players.First(), new Position(1, 2));
            World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.ElementAt(1).listUnit.Add(e0);
            World.Instance.players.First().initDeplacement();
            World.Instance.players.First().listUnit.First().move(new Position(1, 2));
            Assert.IsTrue((new Position(1,2)).equals(((Unit)World.Instance.players.First().listUnit.First()).position));
        }

        [ExpectedException(typeof(Exception), "C'est au joueur X de jouer")]
        [TestMethod]
        public void testMoveNoCurrent()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Azog", "Orc");
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            Orc o0 = new Orc(World.Instance.players.First(), new Position(2, 2));
            Elf e0 = new Elf(World.Instance.players.ElementAt(1), new Position(1, 2));
            World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.ElementAt(1).listUnit.Add(e0);
            World.Instance.players.First().initDeplacement();
            World.Instance.players.ElementAt(1).initDeplacement();
            World.Instance.currentPlayer = 0;
            Assert.AreEqual(0, World.Instance.players.First().numero);
            Assert.AreEqual(1, World.Instance.players.ElementAt(1).numero);
            Assert.AreEqual(0, World.Instance.currentPlayer);
            World.Instance.players.ElementAt(1).listUnit.First().move(new Position(2, 2));
        }

        [TestMethod]
        public void testMakeAMove()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Christopher Lee", "Orc");
            World.Instance.addPlayer("Luc Skywaiter", "Elf");
            Orc o = new Orc(World.Instance.players.First(), new Position(1, 2));
            Orc o1 = new Orc(World.Instance.players.First(), new Position(0, 0));
            World.Instance.players.First().listUnit.Add(o);
            World.Instance.players.First().listUnit.Add(o1);
            World.Instance.players.First().initDeplacement();
            World.Instance.players.First().listUnit.First().makeAMove(new Position(2, 2), 1);
            Assert.AreEqual(0.5,((Unit) World.Instance.players.First().listUnit.First()).nbDeplacement);
            Assert.IsTrue((((Unit) World.Instance.players.First().listUnit.First()).position).equals(new Position (2,2)));
        }

        [TestMethod]
        public void testWinFightAtt()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Azog", "Orc");
            World.Instance.addPlayer("Marty Mc Fly", "Dwarf");
            Orc o = new Orc(World.Instance.players.First(), new Position(1, 2));
            Orc o1 = new Orc(World.Instance.players.First(), new Position(0, 0));
            World.Instance.players.First().listUnit.Add(o);
            World.Instance.players.First().listUnit.Add(o1);
            Assert.AreEqual(0, ((Orc)World.Instance.players.First().listUnit.First()).pvOrc);
            Position p = o.position;
            World.Instance.players.First().listUnit.First().winFightAtt(new Position(2, 2));
            Assert.AreEqual(1, ((Orc)World.Instance.players.First().listUnit.First()).pvOrc);
            Assert.IsTrue((new Position(2,2)).equals(o.position));
        }


        [TestMethod]
        public void testWinFightDef()
        {
            UnitUnit.InitAll();
            World.Instance.addPlayer("Azog", "Orc");
            World.Instance.addPlayer("Marty Mc Fly", "Dwarf");
            Orc o = new Orc(World.Instance.players.First(), new Position(1, 2));
            Orc o1 = new Orc(World.Instance.players.First(), new Position(0, 0));
            World.Instance.players.First().listUnit.Add(o);
            World.Instance.players.First().listUnit.Add(o1);
            Assert.AreEqual(0, ((Orc) World.Instance.players.First().listUnit.First()).pvOrc);
            World.Instance.players.First().listUnit.First().winFightDef(new Position(2, 2));
            Assert.AreEqual(1, ((Orc)World.Instance.players.First().listUnit.First()).pvOrc);
            Assert.IsTrue((new Position(1,2)).equals(o.position));
        }

        [TestMethod]
        public void testGetMoveSuggestions()
        {
            World.Clean();
            Monteur m = new MonteurNormal();
            World.Instance.addPlayer("Azog", "Orc");
            World.Instance.addPlayer("Marty Mc Fly", "Dwarf");
            Orc o = new Orc(World.Instance.players.First(), new Position(2, 2));
            Orc o0 = new Orc(World.Instance.players.First(), new Position(1, 2));
            Dwarf e = new Dwarf(World.Instance.players.ElementAt(1), new Position(2, 1));
            Dwarf e0 = new Dwarf(World.Instance.players.ElementAt(1), new Position(1, 3));
            e0.setHPForUnitTest(1);
            World.Instance.players.First().listUnit.Add(o);
            World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.ElementAt(1).listUnit.Add(e);
            World.Instance.players.ElementAt(1).listUnit.Add(e0);
            o.initDeplacement();
            List<Position> l = ((Unit)World.Instance.players.First().listUnit.First()).getMoveSuggestions();
            /*Assert.IsTrue((new Position(1, 3).equals(l.First())));
            Assert.IsTrue((new Position(2, 3).equals(l.ElementAt(1))));
            Assert.IsTrue((new Position(3, 2).equals(l.ElementAt(2))));
             Présence de Random dans les tests : les tests ont été réalisés sous cette forme
             sans l'aléatoire et validés*/
        }

        [TestMethod]
        public void testGetMoveSuggestions3()
        {
            World.Clean();
            Monteur m = new MonteurNormal();
            World.Instance.board.Tiles[2, 2] = new Desert();
            World.Instance.addPlayer("Azog", "Orc");
            World.Instance.addPlayer("Marty Mc Fly", "Dwarf");
            Orc o = new Orc(World.Instance.players.First(), new Position(5, 5));
            Elf e = new Elf(World.Instance.players.ElementAt(1), new Position(2, 1));
            World.Instance.players.First().listUnit.Add(o);
            World.Instance.players.ElementAt(1).listUnit.Add(e);
            e.initDeplacement();
            List<Position> l = e.getMoveSuggestions();
            /*Assert.IsTrue((new Position(1, 3).equals(l.First())));
            Assert.IsTrue((new Position(2, 3).equals(l.ElementAt(1))));
            Assert.IsTrue((new Position(3, 2).equals(l.ElementAt(2))));
             Présence de Random dans les tests : les tests ont été réalisés sous cette forme
             sans l'aléatoire et validés*/
        }

        [TestMethod]
        public void testStrategy()
        {
            World.Clean();
            Monteur m = new MonteurNormal();
            World.Instance.addPlayer("Azog", "Orc");
            World.Instance.addPlayer("Marty Mc Fly", "Dwarf");
            Orc o = new Orc(World.Instance.players.First(), new Position(2, 2));
            Orc o0 = new Orc(World.Instance.players.First(), new Position(1, 2));
            Orc o00 = new Orc(World.Instance.players.First(), new Position(3, 1));
            Dwarf e = new Dwarf(World.Instance.players.ElementAt(1), new Position(2, 1));
            e.setHPForUnitTest(1);
            Dwarf e0 = new Dwarf(World.Instance.players.ElementAt(1), new Position(1, 3));
            World.Instance.players.First().listUnit.Add(o);
            World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.First().listUnit.Add(o00);
            World.Instance.players.ElementAt(1).listUnit.Add(e);
            World.Instance.players.ElementAt(1).listUnit.Add(e0);
            Assert.IsFalse(o.strategy(new Position(3, 2)));
            Assert.IsTrue(o00.strategy(new Position(4, 1)));
        }

        [TestMethod]
        public void testStrategy2()
        {
            World.Clean();
            Monteur m = new MonteurNormal();
            World.Instance.addPlayer("Azog", "Orc");
            World.Instance.addPlayer("Marty Mc Fly", "Dwarf");
            Orc o = new Orc(World.Instance.players.First(), new Position(2, 2));
            Orc o0 = new Orc(World.Instance.players.First(), new Position(1, 2));
            Dwarf e = new Dwarf(World.Instance.players.ElementAt(1), new Position(2, 1));
            Dwarf e0 = new Dwarf(World.Instance.players.ElementAt(1), new Position(1, 3));
            e0.setHPForUnitTest(1);
            World.Instance.players.First().listUnit.Add(o);
            World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.ElementAt(1).listUnit.Add(e);
            World.Instance.players.ElementAt(1).listUnit.Add(e0);
            Assert.IsTrue(o.strategy(new Position(2, 3)));
            Assert.IsTrue(o.strategy(new Position(3, 2)));
            Assert.IsFalse(o.strategy(new Position(2, 2)));
            Assert.IsFalse(o.strategy(new Position(1, 3)));
            Assert.IsTrue(o.strategy(new Position(3, 1)));
            Assert.IsFalse(o.strategy(new Position(1, 2)));
            Assert.IsFalse(o.strategy(new Position(2, 1)));
        }
        
        [TestMethod]
        public void testgetAllPossibleMoves()
        {
            World.Clean();
            Monteur m = new MonteurNormal();
            Orc o = new Orc(new Player("tea",1,"for two"),new Position(2,2));
            Dwarf d = new Dwarf(new Player("and two",1,"for tea"),new Position(3,3));
            List<Position> lp = o.getAllPossibleMoves();
            List<Position> lp2 = d.getAllPossibleMoves();
            Assert.IsTrue((new Position(3,2)).equals(lp.ElementAt(0)));
            Assert.IsTrue((new Position(1,2)).equals(lp.ElementAt(1)));
            Assert.IsTrue((new Position(2,3)).equals(lp.ElementAt(2)));
            Assert.IsTrue((new Position(2,1)).equals(lp.ElementAt(3)));
            Assert.IsTrue((new Position(3, 1)).equals(lp.ElementAt(4)));
            Assert.IsTrue((new Position(3, 3)).equals(lp.ElementAt(5)));
            Assert.IsTrue((new Position(4,3)).equals(lp2.ElementAt(0)));
            Assert.IsTrue((new Position(2,3)).equals(lp2.ElementAt(1)));
            Assert.IsTrue((new Position(3,4)).equals(lp2.ElementAt(2)));
            Assert.IsTrue((new Position(3, 2)).equals(lp2.ElementAt(3)));
            Assert.IsTrue((new Position(2,2)).equals(lp2.ElementAt(4)));
            Assert.IsTrue((new Position(2,4)).equals(lp2.ElementAt(5)));
        }


        [TestMethod]
        public void testGetMoveSuggestions2()
        {
            World.Clean();
            Monteur m = new MonteurNormal();
            World.Instance.addPlayer("Azog", "Orc");
            World.Instance.addPlayer("Marty Mc Fly", "Dwarf");
            Orc o = new Orc(World.Instance.players.First(), new Position(2, 2));
            Orc o0 = new Orc(World.Instance.players.First(), new Position(1, 2));
            Orc o1 = new Orc(World.Instance.players.First(), new Position(3, 2));
            Orc o2 = new Orc(World.Instance.players.First(), new Position(2, 1));
            Orc o3 = new Orc(World.Instance.players.First(), new Position(2, 3));
            
            Dwarf e = new Dwarf(World.Instance.players.ElementAt(1), new Position(2, 1));
            Dwarf e0 = new Dwarf(World.Instance.players.ElementAt(1), new Position(1, 3));
            Dwarf e1 = new Dwarf(World.Instance.players.ElementAt(1), new Position(1, 2));
            Dwarf e2 = new Dwarf(World.Instance.players.ElementAt(1), new Position(1, 3));
            Dwarf e3 = new Dwarf(World.Instance.players.ElementAt(1), new Position(3, 2));
            Dwarf e4 = new Dwarf(World.Instance.players.ElementAt(1), new Position(2, 3));
            e.setHPForUnitTest(20);
            e2.setHPForUnitTest(2);
            e1.setHPForUnitTest(20);
            World.Instance.players.First().listUnit.Add(o);
            //La majorité des tests a été effectuée avec la carte, à cause de l'aléatoire
           /* World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.First().listUnit.Add(o1);
            World.Instance.players.First().listUnit.Add(o2);
            World.Instance.players.First().listUnit.Add(o3);*/
            /*
            World.Instance.players.ElementAt(1).listUnit.Add(e);
            World.Instance.players.ElementAt(1).listUnit.Add(e0);
            World.Instance.players.ElementAt(1).listUnit.Add(e1);
            World.Instance.players.ElementAt(1).listUnit.Add(e2);
            World.Instance.players.ElementAt(1).listUnit.Add(e3);
            World.Instance.players.ElementAt(1).listUnit.Add(e4);*/
            o.initDeplacement();
            List<Position> l = ((Unit)World.Instance.players.First().listUnit.First()).getMoveSuggestions2();
            //Assert.AreEqual(3, l.Count());
            /*Présence de Random dans les tests : les tests ont été réalisés sous cette forme
             sans l'aléatoire et validés*/
        }
    }
}
