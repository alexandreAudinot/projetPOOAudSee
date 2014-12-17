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
    public class UnitTestWorld
    {

        public static void InitAll()
        {
            World.Clean();
            AbstractBoard b = new DemoBoard();
            World.board = b;
            Assert.IsNotNull(World.Instance);
            World.board.initBoard();
            World.board.initVarBoard();
            Assert.IsNotNull(World.Instance);
        }

        [TestMethod]
        public void testWorldBoard()
        {
            World.Clean();
            AbstractBoard b = new DemoBoard();
            World.board = b;
            Assert.IsNotNull(World.Instance);
            Assert.AreEqual(0, World.Instance.nbPlayer);
            Assert.IsTrue(World.Instance.stateGame);
            Assert.AreEqual(World.board, b);
            Assert.AreEqual(0, World.Instance.nbTours);
            Assert.IsNotNull(World.Instance.listType);
            Assert.IsNotNull(World.Instance.listAvailableType);
            Assert.IsNotNull(World.Instance.players);
        }

        [TestMethod]
        public void testWorldVar()
        {
            InitAll();
            Assert.AreEqual(5, World.Instance.maxnbTours);
            Assert.AreEqual(4, World.Instance.nbUnity);
            Assert.AreEqual(0, World.Instance.currentPlayer);
        }

        [TestMethod]
        public void testInitType()
        {
            Board b = new DemoBoard();
            Assert.IsNotNull(World.Instance);
            Assert.IsTrue(World.Instance.listAvailableType.Contains("Orc"));
            Assert.IsTrue(World.Instance.listAvailableType.Contains("Dwarf"));
            Assert.IsTrue(World.Instance.listAvailableType.Contains("Elf"));
            Assert.AreEqual(3, World.Instance.listAvailableType.Count);
        }

        [TestMethod]
        public void testUnitBool()
        {
            InitAll();
            MonteurDemo m = new MonteurDemo();
            m.createTiles();
            World.Instance.addPlayer("Jean-Pierre", "Orc");
            World.Instance.players.First().listUnit.Add(new Orc(World.Instance.players.First(), World.board.getTile(new Position(1,1))));
            Assert.IsTrue(World.Instance.unitBool(new Position(1, 1)));
            Assert.IsFalse(World.Instance.unitBool(new Position(1, 2)));
        }

        [TestMethod]
        public void testGetUnit()
        {
            InitAll();
            MonteurDemo m = new MonteurDemo();
            m.createTiles();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            Orc o0 = new Orc(World.Instance.players.First(), World.board.getTile(new Position(1, 1)));
            o0.incpv()
            World.Instance.players.First().listUnit.Add(o0);
            World.Instance.players.First().listUnit.Add());
            //Assert.AreEquals(World.Instance.getUnit(new Position(1, 1)));
            Assert.IsNull(World.Instance.getUnit(new Position(1, 2)));
            //initialiser les pièces à la position voulue
            //tester dans le cas vrai et le cas false
            //tester dans le cas 2 unités random et 2 unités défenses différentes
            //rend l'unité la meilleure défensivement (random si égalité) si dessus, l'unité nulle sinon
        }

        [TestMethod]
        public void testgetTile()
        {
            InitAll();
            //Retourne la Tile attachée à la position
        }

        [TestMethod]
        public void testAddPlayer()
        {

            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            Assert.AreEqual(1, World.Instance.nbPlayer);
            Assert.IsTrue(World.Instance.listType.Contains("Elf"));
            Assert.AreEqual("Jean-Pierre", World.Instance.players.First().nom);
        }

        [ExpectedException(typeof(ArgumentException), "Le type n'est pas valide")]
        [TestMethod]
        public void testWrongTypePlayer()
        {

            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Perdu");
            Assert.AreEqual(0, World.Instance.nbPlayer);
        }

        [ExpectedException(typeof(ArgumentException), "Le type est déjà utilisé par un autre joueur")]
        [TestMethod]
        public void testWrongTwiceTypePlayer()
        {

            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Elf");
            Assert.AreEqual(1, World.Instance.nbPlayer);
        }

        [TestMethod]
        public void testremovePlayer()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Orc");
            World.Instance.removePlayer(World.Instance.players.First());
            Assert.IsFalse(World.Instance.stateGame);
        }

        [ExpectedException(typeof(ArgumentException), "Erreur dans la suppression d'un joueur")]
        [TestMethod]
        public void testremovePlayerFail()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Orc");
            World.Instance.removePlayer(null);
        }

        [TestMethod]
        public void endGame()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.removePlayer(World.Instance.players.First());
            Assert.IsTrue(World.Instance.stateGame);
            //vérification des points de vistoire à faire + pv orcs
            //création d'unités
            //leur faire faire des combats avec des morts => création de points de victoire
            World.Instance.players.First().incScore();
            World.Instance.players.ElementAt(1).incScore();
            World.Instance.players.ElementAt(1).incScore();
            //faire faire des combats avec des orcs
            //compter les points
        }

        [TestMethod]
        public void endTurn()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Orc");
            Assert.AreEqual(0, World.Instance.currentPlayer);
            World.Instance.endTurn();
            Assert.AreEqual(1, World.Instance.currentPlayer);
            World.Instance.endTurn();
            Assert.AreEqual(0, World.Instance.currentPlayer);
        }

        [TestMethod]
        public void testEndTurn()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.addPlayer("Georgette", "Orc");
            int turn = 0;
            while(turn < 10)
            {
                World.Instance.endTurn();
                turn++;
            }
            Assert.IsFalse(World.Instance.stateGame);
        }

        [TestMethod]
        public void testGagnant()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.removePlayer(World.Instance.players.First());
            Assert.IsTrue(World.Instance.stateGame);
            World.Instance.players.First().incScore();
            World.Instance.players.ElementAt(1).incScore();
            World.Instance.players.ElementAt(1).incScore();
            Assert.AreEqual("Georgette", World.Instance.gagnant());
        }

        [TestMethod]
        public void testGagnantNul()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.removePlayer(World.Instance.players.First());
            Assert.IsTrue(World.Instance.stateGame);
            World.Instance.players.First().incScore();
            World.Instance.players.ElementAt(1).incScore();
            Assert.AreEqual("Match null", World.Instance.gagnant());
        }
    }
}
