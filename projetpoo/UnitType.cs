using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPOO
{
    public class UnitType : ProjetPOO.IUnitType
    {
        private static List<string> listType { get; set; }
        public void init()
        {
            //on stocke tous les types dans une classe séparée de la classe world pour permettre d'ajouter de nouveaux types
            listType = new List<string>();
            addType("Orc");
            addType("Elfe");
            addType("Nain");
        }

        public void addType(string s)
        {
            listType.Add(s);
        }
            
    }
}
