using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public abstract class Monteur : IBuilder
    {
        public Desert desert { get; private set; }
        public Forest forest { get; private set; }
        public Mountain mountain { get; private set; }
        public Plain plain { get; private set; }

        //constructeur monteur
        public Monteur()
        {
            desert = new Desert();
            forest = new Forest();
            mountain = new Mountain();
            plain = new Plain();
        }

        public Tile[,] createTilesBoard()
        {
            int size0 = World.board.size;
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
                        tab[i, j] = (Tile)new Mountain();
                        break;
                        case 1:
                        tab[i, j] = (Tile)new Desert();
                        break;
                        case 2:
                        tab[i, j] = (Tile)new Forest();
                        break;
                        case 3:
                        tab[i, j] = (Tile)new Plain();
                        break;
                        default:
                        throw new Exception("Nombre aléatoire non matché");
                    }
                }
            }
            return tab;
        }
    }

    public abstract class AbstractFactoryUnit : AbstractFactory
    {

        protected void createTiles()
        {
            throw new System.NotImplementedException();
        }
    }
}
