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
    public class UnitFactory
    {
        [TestMethod]
        public void testcreateTilesDemo()
        {
            MonteurDemo m = new MonteurDemo();
            int forest = 0;
            int mountain = 0;
            int desert = 0;
            int plain = 0;
            for (int i = 0; i < World.board.size; i++)
            {
                for (int j = 0; j < World.board.size; j++)
                {
                    switch (World.board.Tiles[i, j].GetType().ToString())
                    {
                        case "ProjetPOO.Desert":
                            desert++;
                            break;
                        case "ProjetPOO.Mountain":
                            mountain++;
                            break;
                        case "ProjetPOO.Forest":
                            forest++;
                            break;
                        case "ProjetPOO.Plain":
                            plain++;
                            break;
                        default:
                            throw new Exception("le nom n'est pas correct" + World.board.Tiles[i, j].GetType().ToString());
                    }
                }
            }
            Assert.AreEqual(9, forest);
            Assert.AreEqual(9, desert);
            Assert.AreEqual(9, plain);
            Assert.AreEqual(9, mountain);
        }

        [TestMethod]
        public void testcreateTilesSmall()
        {
            World.Clean();
            AbstractBoard b = new SmallBoard();
            World.board = b;
            Assert.IsNotNull(World.Instance);

            MonteurSmall m = new MonteurSmall();
            int forest = 0;
            int mountain = 0;
            int desert = 0;
            int plain = 0;
            for (int i = 0; i < World.board.size; i++)
            {
                for (int j = 0; j < World.board.size; j++)
                {
                    switch (World.board.Tiles[i, j].GetType().ToString())
                    {
                        case "ProjetPOO.Desert":
                            desert++;
                            break;
                        case "ProjetPOO.Mountain":
                            mountain++;
                            break;
                        case "ProjetPOO.Forest":
                            forest++;
                            break;
                        case "ProjetPOO.Plain":
                            plain++;
                            break;
                        default:
                            throw new Exception("le nom n'est pas correct" + World.board.Tiles[i, j].GetType().ToString());
                    }
                }
            }
            Assert.AreEqual(25, forest);
            Assert.AreEqual(25, desert);
            Assert.AreEqual(25, plain);
            Assert.AreEqual(25, mountain);
        }

        [TestMethod]
        public void testcreateTilesNormal()
        {
            World.Clean();
            NormalBoard b = new NormalBoard();
            World.board = b;
            Assert.IsNotNull(World.Instance);
            World.board.initVarBoard();
            Assert.IsNotNull(World.Instance);

            MonteurNormal m = new MonteurNormal();
            int forest = 0;
            int mountain = 0;
            int desert = 0;
            int plain = 0;
            for (int i = 0; i < World.board.size; i++)
            {
                for (int j = 0; j < World.board.size; j++)
                {
                    switch (World.board.Tiles[i, j].GetType().ToString())
                    {
                        case "ProjetPOO.Desert":
                            desert++;
                            break;
                        case "ProjetPOO.Mountain":
                            mountain++;
                            break;
                        case "ProjetPOO.Forest":
                            forest++;
                            break;
                        case "ProjetPOO.Plain":
                            plain++;
                            break;
                        default:
                            throw new Exception("le nom n'est pas correct" + World.board.Tiles[i, j].GetType().ToString());
                    }
                }
            }
            Assert.AreEqual(14*14/4, forest);
            Assert.AreEqual(49, desert);
            Assert.AreEqual(49, plain);
            Assert.AreEqual(49, mountain);
        }

        [TestMethod]
        public void testFactoryUnitDemo()
        {
            MonteurDemo m = new MonteurDemo();
            World.Instance.addPlayer("Charlie and the chocolate factory", "Orc");
            World.Instance.addPlayer("Factory-elle", "Dwarf");
            List<Position> lpos = new List<Position>();
            foreach (Player p in World.Instance.players)
            {
                lpos.Add(p.pDepart);
            }
            FactoryUnit f = new FactoryUnit(World.Instance.players, lpos, World.Instance.listType);
            Assert.AreEqual(4, World.Instance.players.First().listUnit.Count());
            Assert.AreEqual(4, World.Instance.players.ElementAt(1).listUnit.Count());
            Assert.IsNotNull(World.Instance.players.ElementAt(0).listUnit.First());
            Assert.IsNotNull(World.Instance.players.ElementAt(1).listUnit.First());
        }

        [TestMethod]
        public void testFactoryUnitSmall()
        {
            World.Clean();
            MonteurSmall m = new MonteurSmall();
            World.Instance.addPlayer("Charlie and the chocolate factory", "Orc");
            World.Instance.addPlayer("Factory-elle", "Dwarf");
            List<Position> lpos = new List<Position>();
            foreach (Player p in World.Instance.players)
            {
                lpos.Add(p.pDepart);
            }
            FactoryUnit f = new FactoryUnit(World.Instance.players, lpos, World.Instance.listType);
            Assert.AreEqual(6, World.Instance.players.First().listUnit.Count());
            Assert.AreEqual(6, World.Instance.players.ElementAt(1).listUnit.Count());
            Assert.IsNotNull(World.Instance.players.ElementAt(0).listUnit.First());
            Assert.IsNotNull(World.Instance.players.ElementAt(1).listUnit.First());
        }

        [TestMethod]
        public void testFactoryUnitNormal()
        {
            World.Clean();
            MonteurNormal m = new MonteurNormal();
            World.Instance.addPlayer("Charlie and the chocolate factory", "Orc");
            World.Instance.addPlayer("Factory-elle", "Dwarf");
            List<Position> lpos = new List<Position>();
            foreach (Player p in World.Instance.players)
            {
                lpos.Add(p.pDepart);
            }
            FactoryUnit f = new FactoryUnit(World.Instance.players, lpos, World.Instance.listType);
            Assert.AreEqual(8, World.Instance.players.First().listUnit.Count());
            Assert.AreEqual(8, World.Instance.players.ElementAt(1).listUnit.Count());
            Assert.IsNotNull(World.Instance.players.ElementAt(0).listUnit.First());
            Assert.IsNotNull(World.Instance.players.ElementAt(1).listUnit.First());
        }
    }
}
