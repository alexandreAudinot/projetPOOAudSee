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
        public int nbPlayer {get; private set; }
        public int currentPlayer { get; set; }
        public List<Player> players;
        private static World world;
        public static Board board {get; private set;}
        public List<string> listType { get; set; }
        public List<string> listAvailableType { get; private set; }
        public static bool stateGame;
        public static World Instance
        {
            get
            {
                if (world == null)
                {
                    world = new World(board);
                }
                return World.world;
            }
        }

        //constructeur classique
        //les autres variables sont initialisées par les monteurs
        public World(Board b)
        {
            nbPlayer = 0;
            stateGame = true;
            board = b;
            nbTours = 0;
            listType = new List<string>();
            players = new List<Player>();
            listAvailableType = new List<string>();
            InitType();
        }
        
        //constructeur pour chargement du jeu
        public World(World w, Board b)
        {
            nbTours = w.nbTours;
            maxnbTours = w.maxnbTours;
            nbUnity = w.nbUnity;
            nbPlayer = w.nbPlayer;
            currentPlayer = w.currentPlayer;
            players = w.players;
            world = w;
            board = b;
            listType = w.listType;
            listAvailableType = w.listAvailableType;
            stateGame = true;
            world = w;
        }

        //ajoute les types possibles des variables pendant l'initialisation
        public void InitType()
        {
            listAvailableType.Add("Orc");
            listAvailableType.Add("Dwarf");
            listAvailableType.Add("Elf");
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
            foreach (Player player in players)
            {
                foreach (Unit unit in player.listUnit)
                {
                    if (unit.position.equals(p))
                    {
                        return true;
                    }
                }
            }
                
            return false;
        }

        //getUnit rend une unité nulle s'il n'y a pas de pièce sur la position
        //ou sinon rend l'unité de plus grande défense de la case (l'unité au hasard en cas d'égalité)
        public Unit getUnit(Position position)
        {
            List<Unit> l = new List<Unit>();
            foreach (Player player in players)
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
                    return l.ElementAt(rnd.Next(0,l.Count() + 1));
                }
            }
        }

        //fonction qui prend une position et renvoie un tile
        public Tile getTile(Position p)
        {
            return board.getTile(p);
        }
 
        //fonction qui ajoute un joueur
        public void addPlayer(string nomJoueur, string type)
        {
            if (!listAvailableType.Contains(type))
            {
                throw new Exception("Le type n'est pas valide");
            } 
            else
            {
                if (listType.Contains(type))
                {
                    throw new Exception("Le type est déjà utilisé par un autre joueur");
                }
                else
                {
                    Player player = new Player(nomJoueur, nbPlayer);
                    listType.Add(type);
                    players.Add(player);
                    nbPlayer++;
                }
                    
            }
        }

        //fonction qui enlève un joueur
        public void removePlayer(Player p)
        {
            if (!players.Remove(p))
            {
                throw new Exception("Erreur dans la suppression d'un joueur");
            }
            if (players.Count() == 1)
            {
                //message de players.First() a gagné la partie
                this.endGame();
            }
        }

        //fonction qui termine le jeu
        public void endGame()
        {
            stateGame = false;
            foreach (Player p in players)
            {
                p.endGame();
            }
        }

        //fonction qui termine le tour du joueur
        public void endTurn()
        {
            currentPlayer = (currentPlayer + 1) % nbPlayer;
            if (currentPlayer == 0)
            {
                nbTours++;
                if (nbTours == maxnbTours)
                {
                    this.endGame();
                }
            }
        }
    }
}
