using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class MonteurDemo : Monteur
    {
        override public void createTiles()
        {
            int size0 = World.board.size;
            Tile[,] tab = new Tile[size0, size0];

            for (int i = 0; i < size0; i++)
            {
                for (int j = 0; j < size0; j++)
                {
                    tab[i, j] = (Tile)new Forest(new Position(i, j));
                }
            }
            ((DemoBoard)World.board).Tiles = tab;
        }
    }

    public class MonteurNormal : Monteur
    {
        override public void createTiles()
        {
            int size0 = World.board.size;
            Tile[,] tab = new Tile[size0,size0];
            for (int i = 0; i < size0; i++)
            {
                for (int j = 0; j < size0; i++)
                {
                    tab[i,j] = new Forest(new Position(i, j));
                }
            }
                ((NormalBoard) World.board).Tiles = tab;
        }
    }
    /*
    public class MonteurLoadGame : Monteur
    {
        override public void createTiles()
        {

        }
    }
    */
    public class MonteurSmall : Monteur
    {
        override public void createTiles()
        {
            int size0 = World.board.size;
            Tile[,] tab = new Tile[size0, size0];
            for (int i = 0; i < size0; i++)
            {
                for (int j = 0; j < size0; i++)
                {
                    tab[i, j] = (Tile) new Forest(new Position(i, j));
                }
            }
            ((SmallBoard) World.board).Tiles = tab;
        }
    }

    public class FactoryUnit : AbstractFactory
    {
        private Elf elf;
        private Dwarf dwarf;
        private Orc orc;

        private List<Elf> Elfs = new List<Elf>();
        private List<Dwarf> Dwarves = new List<Dwarf>();
        private List<Orc> Orcs = new List<Orc>();

        override
        public void createUnit(List<Player> players, List<Tile> tiles, List<String> types)
        {
            int nb,i = 0;
            foreach (Player player in players)
            {
                switch(types.ElementAt(i))
                {
                    case ("Elfe"): //changer en appelant des factory d'elf
                        World.Instance.listType.Add("Elf");
                        elf = new Elf(player,tiles.ElementAt(i));
                        nb = World.Instance.nbUnity;
                        while (nb > 0)
                        {
                             Elfs.Add(elf);
                            nb--;
                        }
                        break;


                    case ("Dwarf"):
                        World.Instance.listType.Add("Dwarf");
                        dwarf = new Dwarf(player, tiles.ElementAt(i));
                        nb = World.Instance.nbUnity;
                        while (nb > 0)
                        {
                             Elfs.Add(elf);
                            nb--;
                        }
                        break;


                    case ("Orc"):
                        World.Instance.listType.Add("Orc");
                        orc = new Orc(player, tiles.ElementAt(i));
                        nb = World.Instance.nbUnity;
                        while (nb > 0)
                        {
                             Elfs.Add(elf);
                            nb--;
                        }
                        break;
                    default:
                        throw new Exception("Type not recognized in factory");
                }
                i++;
            }
        }
    }
}
