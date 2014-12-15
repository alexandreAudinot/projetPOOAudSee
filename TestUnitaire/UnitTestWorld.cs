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
            Board b = new DemoBoard();
            World world = new World(b);
            b.initBoard();
            World.board.initVarBoard();
        }

        [TestMethod]
        public void testWorldBoard()
        {
            Board b = new DemoBoard();
            World world = new World(b);
            Assert.IsNotNull(world);
            Assert.AreEqual(0, World.Instance.nbPlayer);
            Assert.IsTrue(World.stateGame);
            Assert.AreEqual(World.board, b);
            Assert.AreEqual(0, World.Instance.nbTours);
            Assert.IsNotNull(World.Instance.listType);
            Assert.IsNotNull(World.Instance.listAvailableType);
            Assert.IsNotNull(World.Instance.players);
        }

        [TestMethod]
        public void testWorldBoard2()
        {
            Board b = new DemoBoard();
            World world = new World(b);
            b.initBoard();
            World.board.initVarBoard();
            Assert.AreEqual(World.Instance.maxnbTours, 5);
            World world2 = new World(World.Instance, World.board);
            Assert.IsNotNull(world2);
            Assert.AreEqual(0, World.Instance.nbPlayer);
            Assert.IsTrue(World.stateGame);
            Assert.AreEqual(World.board, b);
            Assert.AreEqual(0, World.Instance.nbTours);
            Assert.IsNotNull(World.Instance.listType);
            Assert.IsNotNull(World.Instance.listAvailableType);
            Assert.IsNotNull(World.Instance.players);
            //Assert.AreEqual(World.Instance.maxnbTours, 5);
            /*Assert.AreEqual(World.Instance.nbUnity, 4);
            Assert.AreEqual(World.Instance.currentPlayer, 0);*/
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
            World w0 = new World(new DemoBoard());
            List<String> l = new List<string>();
            Assert.IsTrue(World.Instance.listAvailableType.Contains("Orc"));
            Assert.IsTrue(World.Instance.listAvailableType.Contains("Dwarf"));
            Assert.IsTrue(World.Instance.listAvailableType.Contains("Elf"));
            Assert.AreEqual(3, World.Instance.listAvailableType.Count);
        }

        [TestMethod]
        public void testUnitBool()
        {
            InitAll();
            //initialiser les pièces à la position voulue
            //tester dans le cas vrai et le cas false
            //rend vrai si dessus, faux sinon
        }

        [TestMethod]
        public void testGetUnit()
        {
            InitAll();
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
            Assert.IsFalse(World.stateGame);
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
            Assert.IsFalse(World.stateGame);
        }

        [TestMethod]
        public void testGagnant()
        {
            InitAll();
            World.Instance.addPlayer("Jean-Pierre", "Elf");
            World.Instance.removePlayer(World.Instance.players.First());
            Assert.IsTrue(World.stateGame);
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
            Assert.IsTrue(World.stateGame);
            World.Instance.players.First().incScore();
            World.Instance.players.ElementAt(1).incScore();
            Assert.AreEqual("Match null", World.Instance.gagnant());
        }
    }
}
