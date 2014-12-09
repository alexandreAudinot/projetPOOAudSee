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

        override
        public void createUnit()
        {
            throw new System.NotImplementedException();
        }
    }
}
