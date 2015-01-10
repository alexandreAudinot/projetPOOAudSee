using System;
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
            DemoBoard b = new DemoBoard();
            ((DemoBoard)World.Instance.board).Tiles = this.createTilesBoard();
            World.Instance.board.initVarBoard();
        }
    }

    public class MonteurNormal : Monteur
    {
        //permet de caster le board créer par la classe mère
        public MonteurNormal() : base()
        {
            NormalBoard b = new NormalBoard();
            ((NormalBoard)World.Instance.board).Tiles = this.createTilesBoard();
            World.Instance.board.initVarBoard();
        }
    }

    public class MonteurSmall : Monteur
    {
        //permet de caster le board créer par la classe mère
        public MonteurSmall() : base()
        {
            SmallBoard b = new SmallBoard();
            ((SmallBoard)World.Instance.board).Tiles = this.createTilesBoard();
            World.Instance.board.initVarBoard();
        }
    }

    public class FactoryUnit
    {
        private Elf elf;
        private Dwarf dwarf;
        private Orc orc;

        public FactoryUnit(List<Player> players, List<Position> lpos, List<String> types)
        {
            int nb,i = 0;
            foreach (Player player in players)
            {
                switch(types.ElementAt(i))
                {
                    case ("Elf"):
                        World.Instance.listType.Add("Elf");
                        elf = new Elf(player, lpos.ElementAt(i));
                        elf.controler.numero = player.numero;
                        nb = World.Instance.nbUnity;
                        while (nb > 0)
                        {
                             World.Instance.players.ElementAt(i).listUnit.Add(elf);
                            nb--;
                        }
                        break;


                    case ("Dwarf"):
                        World.Instance.listType.Add("Dwarf");
                        dwarf = new Dwarf(player, lpos.ElementAt(i));
                        dwarf.controler.numero = player.numero;
                        nb = World.Instance.nbUnity;
                        while (nb > 0)
                        {
                            World.Instance.players.ElementAt(i).listUnit.Add(dwarf);
                            nb--;
                        }
                        break;


                    case ("Orc"):
                        World.Instance.listType.Add("Orc");
                        orc = new Orc(player, lpos.ElementAt(i));
                        orc.controler.numero = player.numero;
                        nb = World.Instance.nbUnity;
                        while (nb > 0)
                        {
                            World.Instance.players.ElementAt(i).listUnit.Add(orc);
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
