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

        }
    }

    public class MonteurNormal : Monteur
    {
        override public void createTiles()
        {

        }
    }

    public class MonteurLoadGame : Monteur
    {
        override public void createTiles()
        {

        }
    }

    public class MonteurSmall : Monteur
    {
        override public void createTiles()
        {

        }
    }

    public class FactoryUnit : AbstractFactory
    {
        private Elf elf;
        private Dwarf dwarf;
        private Orc orc;

        private List<Elf> Elfs;
        private List<Dwarf> Dwarves;
        private List<Orc> Orcs;

        override
        public void createUnit()
        {
            //init Elfs
            int i = World.Instance.nbUnity;
            while (i > 0)
            {
                Elfs.Add(elf);
                Dwarves.Add(dwarf);
                Orcs.Add(orc);
            }
        }

        public void init(List<Player> players, List<Tile> tiles, List<String> types)
        {
            int i = 0;
            foreach (Player player in players)
            {
                switch(types.ElementAt(i))
                {
                    case ("Elfe"):
                        elf = new Elf(player,tiles.ElementAt(i));
                        break;
                    case ("Dwarf"):
                        dwarf = new Dwarf(player, tiles.ElementAt(i));
                        break;
                    case ("Orc"):
                        orc = new Orc(player, tiles.ElementAt(i));
                        break;
                    default:
                        throw new Exception("Type not recognized in factory");
                }
                i++;
            }
        }
    }
}
