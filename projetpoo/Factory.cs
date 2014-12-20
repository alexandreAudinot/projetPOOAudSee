﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class MonteurDemo : Monteur
    {
        //permet de caster le board créer par la classe mère
        public MonteurDemo() : base()
        {
            ((DemoBoard)World.board).Tiles = this.createTilesBoard();
        }
    }

    public class MonteurNormal : Monteur
    {
        //permet de caster le board créer par la classe mère
        public MonteurNormal() : base()
        {
            ((NormalBoard)World.board).Tiles = this.createTilesBoard();
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
        //permet de caster le board créer par la classe mère
        public MonteurSmall() : base()
        {
            ((SmallBoard)World.board).Tiles = this.createTilesBoard();
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
        public static Position pinitElf;
        public static Position pinitDwarf;
        public static Position pinitOrc;

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
                        elf = new Elf(player, pinitElf);
                        nb = World.Instance.nbUnity;
                        while (nb > 0)
                        {
                             Elfs.Add(elf);
                            nb--;
                        }
                        break;


                    case ("Dwarf"):
                        World.Instance.listType.Add("Dwarf");
                        dwarf = new Dwarf(player,pinitDwarf);
                        nb = World.Instance.nbUnity;
                        while (nb > 0)
                        {
                             Elfs.Add(elf);
                            nb--;
                        }
                        break;


                    case ("Orc"):
                        World.Instance.listType.Add("Orc");
                        orc = new Orc(player,pinitOrc);
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
