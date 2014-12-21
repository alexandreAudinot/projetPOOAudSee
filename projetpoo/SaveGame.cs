using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ProjetPOO
{
    public class SaveGame
    {
        public void saveOnDisk()
       { 
            string assemblyDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pathString = Path.Combine(assemblyDir, "save");
           int save = 1;
           while (System.IO.File.Exists(pathString + save.ToString() + ".txt"))
            {
                save++;
            }
            pathString += save.ToString() + ".txt";
            string text = "Sauvegarde ProjetPOOAudSee\n";
            //On remplit le fichier avec les données de world et du board
            //variables int ou boolean
            text += "[World]\n";
            text += "[maxnbTours = " + World.Instance.nbTours + "], ";
            text += "[nbTours = " + World.Instance.maxnbTours + "], ";
            text += "[nbUnity = " + World.Instance.nbUnity + "], ";
            text += "[currentPlayer = " + World.Instance.currentPlayer + "], ";
            text += "[stateGame = " + World.Instance.stateGame + "], ";
            text += "[repliCurrentPlayer = " + World.Instance.repliCurrentPlayer + "]\n";
            //board
            text += "[Board]\n";
            text += "[size = " + World.board.size + "], ";
            for (int i = 0; i < World.board.size; i++)
            {
                for (int j = 0; j < World.board.size; j++)
                {
                    switch (World.board.Tiles[i,j].GetType().ToString())
                    {
                        case "ProjetPOO.Mountain":
                            text += "M";
                            break;
                        case "ProjetPOO.Forest":
                            text += "F";
                            break;
                        case "ProjetPOO.Plain":
                            text += "P";
                            break;
                        case "ProjetPOO.Desert":
                            text += "D";
                            break;
                        default:
                            throw new Exception("Type de terrain non matché : " + World.board.Tiles[i,j].GetType().ToString());
                    }
                    text += "[" + i + "," + j + "], ";
                }
            }
            //Liste Type
            text += "\n[listType]\n";
            foreach (String s in World.Instance.listType)
            {
                text += "[" + s + "] ,";
            }
            //Liste Type disponible
            text += "\n[listTypeAvailaible]\n";
            foreach (String s0 in World.Instance.listAvailableType)
            {
                text += "[" + s0 + "] ,";
            }
            int cpt = -1;
            foreach (Player p in World.Instance.players)
            {
                cpt++;
                text += "\n\n[player" + cpt + "]\n";
                //attributs généraux de player
                text += "[nom = " + p.nom + "], ";
                text += "[numero = " + p.numero + "], ";
                text += "[score = " + p.score + "], ";
                text += "[pDepart  = (" + p.pDepart.x + "," + p.pDepart.y + ")]\n[listunit";
                //liste d'unités
                foreach (Unit u in p.listUnit)
                {
                    text += "[att = " + u.att + "], ";
                    text += "[def = " + u.def + "], ";
                    text += "[hp = " + u.hp + "], ";
                    text += "[nbDeplacement = " + u.nbDeplacement + "], ";
                    text += "[initialLife = " + u.initialLife + "], ";
                    text += "[controler = " + u.controler.numero + "], ";
                    text += "[position = (" + u.position.x + "," + u.position.y + ")], ";
                    if (u.GetType().ToString() == "ProjetPOO.Orc")
                    {
                        text += "[pvOrc = " + ((Orc) u).pvOrc + "], ";
                    }
                }
            }
            System.IO.File.WriteAllText(pathString, text);
        }


        public void loadOnDisk()
        {
            //on récupère le fichier trié par lignes
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Dan\Desktop\Cours\projetPOOAudSee\TestUnitaire\bin\Debug\save1.txt");
            if (lines[0] != "Sauvegarde ProjetPOOAudSee")
            {
                throw new Exception("Le fichier lu n'est pas comptabible");
            }

            //on recupère le type du plateau
            Regex rsize = new Regex(@"^\[size = ([\w]+)\],? ");
            Match msize = rsize.Match(lines[4]);
            if (msize.Success)
            {
                switch (msize.Groups[1].Value)
                {
                    case "6":
                        MonteurDemo monteur = new MonteurDemo();
                        break;
                    case "10":
                        MonteurSmall monteur2 = new MonteurSmall();
                        break;
                    case "14":
                        MonteurNormal monteur3 = new MonteurNormal();
                        break;
                    default:
                        throw new Exception("Size non matchée");
                }
            }
            //on récupère les informations relatives au world
            Regex rline1 = new Regex(@"^\[maxnbTours = ([\w]+)\],? \[nbTours = ([\w]+)\],? \[nbUnity = ([\w]+)\],?"
                + @" \[currentPlayer = ([\w]+)\],? \[stateGame = ([\w]+)\],? \[repliCurrentPlayer = ([-\w]+)\]?");
            Match mline1 = rline1.Match(lines[2]);
            if (mline1.Success)
            {
                int smaxnbTours = int.Parse(mline1.Groups[1].Value);
                int snbTours = int.Parse(mline1.Groups[2].Value);
                int snbUnity = int.Parse(mline1.Groups[3].Value);
                int scurrentPlayer = int.Parse(mline1.Groups[4].Value);
                Boolean sstateGame = Boolean.Parse(mline1.Groups[5].Value);
                int srepliCurrentPlayer = int.Parse(mline1.Groups[6].Value);
                //throw new Exception(smaxnbTours + " " + snbTours + " " + snbUnity + " " + scurrentPlayer + " " + sstateGame + " " + srepliCurrentPlayer);
            }
            //on récupère le board
            String s = "";
            string sourceString = @"<box><3>\n<table><1>\n<chair><8>";
            Regex ItemRegex = new Regex(@"<(?<item>\w+?)><(?<count>\d+?)>", RegexOptions.Compiled);
            foreach (Match ItemMatch in ItemRegex.Matches(sourceString))
            {
                s += ItemMatch.Groups[1].Value + " ";
            }

            throw new Exception (s);
        }
    }
}
