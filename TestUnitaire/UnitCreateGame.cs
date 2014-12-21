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
    public class UnitCreateGame
    {
        [TestMethod]
        public void testinit()
        {
            //TODO later, avec les cases et les graphismes
            Assert.IsFalse(false);
        }

        [TestMethod]
        public void testMonteurDemo()
        {
            MonteurDemo m = new MonteurDemo();
            Assert.IsNotNull(World.Instance);
            Assert.AreEqual(5, World.Instance.maxnbTours);
            Assert.AreEqual(4, World.Instance.nbUnity);
            Assert.AreEqual(0, World.Instance.currentPlayer);
            UnitCreateGame.testMonteurTiles();
        }

        public static void testMonteurTiles()
        {
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
            Assert.AreEqual(World.board.size * World.board.size/4, forest);
            Assert.AreEqual(World.board.size * World.board.size / 4, desert);
            Assert.AreEqual(World.board.size * World.board.size / 4, plain);
            Assert.AreEqual(World.board.size * World.board.size / 4, mountain);
        }


        [TestMethod]
        public void testMonteurSmall()
        {
            MonteurSmall m = new MonteurSmall();
            Assert.AreEqual(20, World.Instance.maxnbTours);
            Assert.AreEqual(6, World.Instance.nbUnity);
            Assert.AreEqual(0, World.Instance.currentPlayer);
            UnitCreateGame.testMonteurTiles();
        }

        [TestMethod]
        public void testMonteurNormal()
        {
            MonteurNormal m = new MonteurNormal();
            Assert.AreEqual(30, World.Instance.maxnbTours);
            Assert.AreEqual(8, World.Instance.nbUnity);
            Assert.AreEqual(0, World.Instance.currentPlayer);
            UnitCreateGame.testMonteurTiles();

        }

        [TestMethod]
        public void testSaveGame()
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
            SaveGame save = new SaveGame();
            //save.saveOnDisk();
            save.loadOnDisk();
        }
    }
}
