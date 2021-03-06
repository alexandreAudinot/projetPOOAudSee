﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapping;

namespace ProjetPOO
{
    public abstract class Monteur : IBuilder
    {
        public static Desert desert = new Desert();
        public static Desert desertTile
        {
            get { return desert; }
            private set { desert = value; }
        }
        public static Forest forestTile { get; private set; }
        public static Mountain mountainTile { get; private set; }
        public static Plain plainTile { get; private set; }

        //constructeur monteur
        public Monteur()
        {
            desertTile = new Desert();
            forestTile = new Forest();
            mountainTile = new Mountain();
            plainTile = new Plain();
            //World.Instance.board.Tiles = this.createTilesBoard2();
        }

        //fonction createTilesBoard() rend un tableau de tiles
        //initialisé à partir d'un algorithme C#
        public Tile[,] createTilesBoard()
        {
            int size0 = World.Instance.board.size;
            int forest = size0*size0 / 4;
            int mountain = size0 * size0 / 4;
            int desert = size0 * size0 / 4;
            int plain = size0 * size0 / 4;
            Random random = new Random();
            Tile[,] tab = new Tile[size0, size0];
            Boolean accept = false;
            int rn = -1;

            for (int i = 0; i < size0; i++)
            {
                for (int j = 0; j < size0; j++)
                {
                    accept = false;
                    do {
                            rn = random.Next(0, 4);
                            switch (rn)
                            {
                                case 0:
                                    if (mountain > 0)
                                    {
                                        mountain--;
                                        accept = true;
                                    }
                                    break;
                                case 1:
                                    if (desert > 0)
                                    {
                                        desert--;
                                        accept = true;
                                    }
                                    break;
                                case 2:
                                    if (forest > 0)
                                    {
                                        forest--;
                                        accept = true;
                                    }
                                    break;
                                case 3:
                                    if (plain > 0)
                                    {
                                        plain--;
                                        accept = true;
                                    }
                                    break;
                                default:
                                    throw new Exception("Nombre aléatoire non matché");
                            } 
                    }
                    while (!accept);
                    switch (rn)
                    {
                        case 0:
                        tab[i, j] = (Tile) mountainTile ;
                        break;
                        case 1:
                        tab[i, j] = (Tile) desertTile;
                        break;
                        case 2:
                        tab[i, j] = (Tile) forestTile;
                        break;
                        case 3:
                        tab[i, j] = (Tile) plainTile;
                        break;
                        default:
                        throw new Exception("Nombre aléatoire non matché");
                    }
                }
            }
            return tab;
        }

        //fonction createTilesBoard2() rend un tableau de tiles
        //initialisé à partir d'un algorithme C++ via le wrapper
        public Tile[,] createTilesBoard2()
        {
            int size = World.Instance.board.size;
            Wrapper board = new Wrapper();
            Tile[,] tab = new Tile[size, size];
            List<int> resul =  board.compute(size, size);
            int x = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    switch (resul.ElementAt(x))
                    {
                        case 0:
                            tab[i, j] = (Tile)mountainTile;
                            break;
                        case 1:
                            tab[i, j] = (Tile)desertTile;
                            break;
                        case 2:
                            tab[i, j] = (Tile)forestTile;
                            break;
                        case 3:
                            tab[i, j] = (Tile)plainTile;
                            break;
                        default:
                            throw new Exception("Nombre aléatoire non matché");
                    }
                    x++;
                }
            }
                return tab;
        }

        //fonction init qui initialise le jeu
        public void initForXaml()
        {
            /* ------------------------------Type du plateau, appels à faire--------------------------------- *
              * -----------------------Plateau Demo : MonteurDemo m = new MonteurDemo()----------------------- *
              * -----------------------Plateau Small : MonteurSmall m = new MonteurSmall()-------------------- *
              * -----------------------Plateau Normal : MonteurNormal m = new MonteurNormal()------------------- *
              * ---------------------------------------------------------------------------------------------- */


            /* ------------------------------Type des joueurs, appels à faire-------------------------------- *
             * ---------------------- les joueurs sont numérotés selon la vitesse d'inscription-------------- *
             * -----------------------Joueur nom, type : World.Instance.addPlayer(nom,type) ----------------- *
             * --------------------------------Donner le numéro de chaque joueur----------------------------- *
             * --------------------------------------------------------------------------------------------- */

            //pour décider quel joueur joue en premier
            Random rdm = new Random();
            World.Instance.currentPlayer = rdm.Next(0, World.Instance.players.Count());
            World.Instance.firstPlayer = World.Instance.currentPlayer;
            //changer les positions initiales, changer avec position Player.pDepart

            //La partie va commencer ? Charger alors les unités
            List<Position> lpos = new List<Position>();
            foreach (Player p in World.Instance.players)
            {
                lpos.Add(p.pDepart());
            }
            FactoryUnit f = new FactoryUnit(World.Instance.players, lpos, World.Instance.listType);
            if (World.Instance.currentPlayer == 0)
            {
                World.Instance.players.First().initDeplacement();
            }
            else
            {
                World.Instance.players.ElementAt(1).initDeplacement();
            }
        }
    }
}
