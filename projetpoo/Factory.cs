using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public class MonteurDemo : Monteur
    {
    }

    public class MonteurNormal : Monteur
    {
    }

    public class MonteurLoadGame : Monteur
    {
    }

    public class MonteurSmall : Monteur
    {
    }

    public class FactoryUnit : AbstractFactory
    {

        private List<Elf> Elfs
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private List<Dwarf> Dwarves
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private List<Orc> Orcs
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        protected void createUnit()
        {
            throw new System.NotImplementedException();
        }
    }
}
