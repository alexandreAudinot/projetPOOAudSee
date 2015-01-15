using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class World
    {
        public int nbTours { get; private set; }
        public int maxnbTours { get; private set; }
        public int nbUnity;
        public int currentPlayer { get; set; }
        public List<Player> players { get; set; }
        private static World world;
        public AbstractBoard board { get; set; }
        public List<string> listType { get; set; }
        public List<string> listAvailableType { get; private set; }
        public bool stateGame;
        public int repliCurrentPlayer;
        public static World Instance
        {
            get
            {
                if (world == null)
                {
                    world = new World();
                }
                return World.world;
            }
        }

        //constructeur classique
        //les autres variables sont initialisées par les monteurs
        private World()
        {
            stateGame = true;
            nbTours = 0;
            listType = new List<string>();
            players = new List<Player>();
            listAvailableType = new List<string>();
            InitType();
            repliCurrentPlayer = -1;
        } 

        //fonction qui permet d'initialiser World lors d'un chargement
        public void loadGameWorld(int smaxnbTours, int snbTours, int snbUnity, int scurrentPlayer, bool sstateGame, int srepliCurrentPlayer)
        {
            maxnbTours = smaxnbTours;
            nbTours = snbTours;
            nbUnity = snbUnity;
            currentPlayer = scurrentPlayer;
            stateGame = sstateGame;
            repliCurrentPlayer = srepliCurrentPlayer;
        }

        //ajoute les types possibles des variables pendant l'initialisation
        public void InitType()
        {
            listAvailableType.Add("Orc");
            listAvailableType.Add("Dwarf");
            listAvailableType.Add("Elf");
        }

        //méthode qui permet de nettoyer world entre les tests
        public static void Clean()
        {
            world = null;
            World.Instance.board = null;
        }

        //initialisation des variables de world par les monteurs
        public void WorldVar(int nbT, int nbU)
        {
            Instance.maxnbTours = nbT;
            Instance.nbUnity = nbU;
            Instance.currentPlayer = 0;
        }

        //unitBool rend vrai s'il y a une unité sur la position p
        public bool unitBool(Position p)
        {
            return unitCount(p) > 0;
        }

        //unitCount rend le nombre d'unités sur la position p
        public int unitCount(Position p)
        {
            int cpt = 0;
            foreach (Player player in World.Instance.players)
            {
                foreach (Unit unit in player.listUnit)
                {
                    if (unit.position.equals(p))
                    {
                        cpt++;
                    }
                }
            }

            return cpt;
        }

        //getUnit rend une unité nulle s'il n'y a pas de pièce sur la position
        //ou sinon rend l'unité de plus grande défense de la case (l'unité au hasard en cas d'égalité)
        public Unit getUnit(Position position)
        {
            List<Unit> l = new List<Unit>();
            foreach (Player player in World.Instance.players)
            {
                foreach (Unit unit in player.listUnit)
                {
                    if (unit.position.equals(position))
                    {
                        if (!l.Any())
                        {
                            l.Add(unit);
                        }
                        else
                        {
                            if (unit.def > l.First().def)
                            {
                                l.Clear();
                                l.Add(unit);
                            }
                            else
                            {
                                if (unit.def == l.First().def)
                                {
                                    l.Add(unit);
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                }
            }
            
            //renvoie null si rien n'a été trouvé sur la case
            if (!l.Any())
            {
                return null;
            }
            else
            {
                if (l.Count() == 1)
                {
                    return l.First();
                } 
                else
                {
                    //renvoie une unité au hasard
                    //tester que le nombre est bien dans les cordes
                    Random rnd = new Random();
                    return l.ElementAt(rnd.Next(0,l.Count()));
                }
            }
        }

        //renvoie la liste des unités à une position
        public List<Unit> getUnitList(Position pos)
        {
            List<Unit> l = new List<Unit>();
            foreach (Player player in World.Instance.players)
            {
                foreach (Unit unit in player.listUnit)
                {
                    if (unit.position.equals(pos))
                    {
                        l.Add(unit);
                    }
                }
            }
            return l;
        }

        //fonction qui prend une position et renvoie un tile
        public Tile getTile(Position p)
        {
            return board.getTile(p);
        }
 
        //fonction qui ajoute un joueur
        public void addPlayer(string nomJoueur, string type)
        {
            if (!World.Instance.listAvailableType.Contains(type))
            {
                throw new Exception("Le type n'est pas valide");
            } 
            else
            {
                if (World.Instance.listType.Contains(type))
                {
                    throw new Exception("Le type est déjà utilisé par un autre joueur");
                }
                else
                {
                    Player player = new Player(nomJoueur, World.Instance.players.Count(), type);
                    World.Instance.listType.Add(type);
                    World.Instance.players.Add(player);
                }
            }
        }

        //fonction qui enlève un joueur
        public void removePlayer(Player p)
        {
            if (!World.Instance.players.Remove(p))
            {
                throw new Exception("Erreur dans la suppression d'un joueur");
            }
            if (World.Instance.players.Count() == 1)
            {
                this.endGame();
            }
        }

        //fonction qui termine le jeu
        public void endGame()
        {
            stateGame = false;
            World.Instance.updateScore();
        }

        //méthode updateScore qui update le score de tous les joueurs
        //appelle la méthode sur chaque joueur
        public void updateScore()
        {
            foreach (Player p in players)
            {
                p.updateScore();
            }
        }

        //fonction qui termine le tour du joueur
        public void endTurn()
        {
            World.Instance.updateScore();
            World.Instance.currentPlayer = (World.Instance.currentPlayer + 1) % World.Instance.players.Count();
            if (World.Instance.currentPlayer == 0)
            {
                World.Instance.players.First().initDeplacement();
                nbTours++;
                if (World.Instance.nbTours == World.Instance.maxnbTours)
                {
                    World.Instance.endGame();
                }
            }
            else
            {
                World.Instance.players.ElementAt(1).initDeplacement();
            }
        }

        //gagnant permet de rendre le gagnant de la partie (String)
        //rend match nul en cas d'égalité
        public String gagnant()
        {
            if (World.Instance.players.Count() == 1)
            {
                return World.Instance.players.First().nom;
            } 
            else
            {
                String s = "No";
                int scoreMax = -1;
                foreach (Player player in World.Instance.players)
                {
                    if (player.score > scoreMax)
                    {
                        s = player.nom;
                        scoreMax = player.score;
                    }
                    else
                    {
                        if (player.score == scoreMax)
                        {
                            return "Match nul";
                        }
                        return s;
                    }
                }
                throw new Exception("Il n'y a pas de gagnant avec une liste vide");
            }
        }
    }
}
