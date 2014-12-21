using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

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
            text += "[nbPlayer = " + World.Instance.nbPlayer + "], ";
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


        public void loadOnDisk(String s)
        {
            
        // Read and display the data from your file.
        try
        {
            string pathString = @"c:\Users\Dan\Desktop\Cours\projetPOOAudSee\Save\" + s;
            byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
            foreach (byte ba in readBuffer)
            {
                Console.Write(ba + " ");
            }
            Console.WriteLine();
        }
        catch (System.IO.IOException e)
        {
            Console.WriteLine(e.Message);
        }

        // Keep the console window open in debug mode.
        System.Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();
    }
    // Sample output:

    // Path to my file: c:\Top-Level Folder\SubFolder\ttxvauxe.vv0

    //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29
    //30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56
    // 57 58 59 60 61 62 63 64 65 66 67 68 69 70 71 72 73 74 75 76 77 78 79 80 81 82 8
    //3 84 85 86 87 88 89 90 91 92 93 94 95 96 97 98 99
    }
}
