using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
namespace ProjetPOO
{
    public class SaveManager
    {
        //fonction saveOnDisk() qui permet d'enregistrer la partie en un fichier saveX.txt
        public string saveOnDisk()
        {
            //on définit le nom du fichier
            string assemblyDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pathString = Path.Combine(assemblyDir, "save");
            int save = 1;
            while (System.IO.File.Exists(pathString + save.ToString() + ".txt"))
            {
                save++;
            }
            //on prépare le fichier avant écriture
            pathString += save.ToString() + ".txt";
            String resul = "save" + save.ToString() + ".txt";
            String text = this.savePlayer(this.saveBoard(this.saveWorld()));
            //on écrit le contenu de text dans le fichier.
            System.IO.File.WriteAllText(pathString, text);
            return resul;
        }
        //La fonction saveWorld copie le world dans un String qu'elle renvoie en sortie
        public string saveWorld()
        {
            string text = "Sauvegarde ProjetPOOAudSee\n";
            //On remplit le fichier avec les données de world
            //variables int ou boolean
            text += "[World]\n";
            text += "[maxnbTours = " + World.Instance.maxnbTours + "], ";
            text += "[nbTours = " + World.Instance.nbTours + "], ";
            text += "[nbUnity = " + World.Instance.nbUnity + "], ";
            text += "[currentPlayer = " + World.Instance.currentPlayer + "], ";
            text += "[stateGame = " + World.Instance.stateGame + "], ";
            text += "[nbPlayers = " + World.Instance.players.Count() + "]\n";
            return text;
        }
        //La fonction saveBoard enregistre le board à la suite de text et le renvoie
        public string saveBoard(String text)
        {
            //board
            text += "[Board]\n";
            text += "[size = " + World.Instance.board.size + "], ";
            for (int i = 0; i < World.Instance.board.size; i++)
            {
                for (int j = 0; j < World.Instance.board.size; j++)
                {
                    switch (World.Instance.board.Tiles[i, j].GetType().ToString())
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
                            throw new Exception("Type de terrain non matché : " + World.Instance.board.Tiles[i, j].GetType().ToString());
                    }
                    text += "[" + i + "," + j + "], ";
                }
            }
            return text;
        }
        //la fonction savePlayer enregistre le player dans un string qu'elle concatène avec le
        //String d'entrée pour rendre un String final
        public string savePlayer(String text)
        {
            //Liste Type
            text += "\n[listType]\n";
            foreach (String s in World.Instance.listType)
            {
                text += "[" + s + "], ";
            }
            //Liste Type disponible
            text += "\n[listTypeAvailaible]\n";
            foreach (String s0 in World.Instance.listAvailableType)
            {
                text += "[" + s0 + "], ";
            }
            foreach (Player p in World.Instance.players)
            {
                text += "\n\n[player]\n";
                //attributs généraux de player
                text += "[nom = " + p.nom + "], ";
                text += "[numero = " + p.numero + "], ";
                text += "[score = " + p.score + "], ";
                //text += "[type = " + p.type + "], ";
                //text += "[pDepart = (" + p.pDepart.x + "," + p.pDepart.y + ")]\n[listunit";
                text += "[type = " + p.type + "]\n[listunit";
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
                        text += "[pvOrc = " + ((Orc)u).pvOrc + "], ";
                    }
                }
            }
            return text;
        }
        //fonction qui charge la partie contenue dans le fichier nomFichier
        public void loadOnDisk(String nomFichier)
        {
            World.Clean();
            //on récupère le fichier trié par lignes
            string[] lines = new String[0];
            try
            {
                string assemblyDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string pathString = Path.Combine(assemblyDir, nomFichier);
                lines = System.IO.File.ReadAllLines(pathString);
            }
            catch (Exception)
            {
                throw new Exception("Le fichier de sauvegarde n'a pas été trouvé");
            }
            if (lines[0] != "Sauvegarde ProjetPOOAudSee")
            {
                throw new Exception("Le fichier lu n'est pas comptabible");
            }
            loadPlateau(lines);
            loadPlayer(lines, loadWorld(lines));
        }
        //La fonction LoadPlateau récupère le monteur et le board
        public void loadPlateau(String[] lines)
        {
            Monteur m;
            //on recupère le type du plateau
            Regex rsize = new Regex(@"^\[size = ([\w]+)\],? ");
            Match msize = rsize.Match(lines[4]);
            if (msize.Success)
            {
                switch (msize.Groups[1].Value)
                {
                    case "6":
                        m = new MonteurDemo();
                        break;
                    case "10":
                        m = new MonteurSmall();
                        break;
                    case "14":
                        m = new MonteurNormal();
                        break;
                    default:
                        throw new Exception("Size non reconnue");
                }
            }
            else
            {
                throw new Exception("Type du plateau non matché");
            }
            //on récupère le board
            string sourceString = lines[4];
            Regex ItemRegex = new Regex(@" (\w+?)\[(\w+?),(\w+?)\]", RegexOptions.Compiled);
            foreach (Match ItemMatch in ItemRegex.Matches(sourceString))
            {
                if (ItemMatch.Success)
                {
                    try
                    {
                        switch (ItemMatch.Groups[1].Value)
                        {
                            case "D":
                                World.Instance.board.Tiles[int.Parse(ItemMatch.Groups[2].Value), int.Parse(ItemMatch.Groups[3].Value)] = Monteur.desertTile;
                                break;
                            case "F":
                                World.Instance.board.Tiles[int.Parse(ItemMatch.Groups[2].Value), int.Parse(ItemMatch.Groups[3].Value)] = Monteur.forestTile;
                                break;
                            case "M":
                                World.Instance.board.Tiles[int.Parse(ItemMatch.Groups[2].Value), int.Parse(ItemMatch.Groups[3].Value)] = Monteur.mountainTile;
                                break;
                            case "P": ;
                                World.Instance.board.Tiles[int.Parse(ItemMatch.Groups[2].Value), int.Parse(ItemMatch.Groups[3].Value)] = Monteur.plainTile;
                                break;
                            default:
                                throw new Exception("Terrain du board non reconnu");
                        }
                    }
                    catch (Exception)
                    {
                        throw new Exception("Problème dans la conversion des String pour le stockage des variables du board");
                    }
                }
                else
                {
                    throw new Exception("Variables du plateau non matchées");
                }
            }
        }
        public int loadWorld(String[] lines)
        {
            int snbPlayers = 0;
            //on récupère les informations relatives au world
            Regex rline1 = new Regex(@"^\[maxnbTours = ([\w]+)\],? \[nbTours = ([\w]+)\],? \[nbUnity = ([\w]+)\],?"
            + @" \[currentPlayer = ([\w]+)\],? \[stateGame = ([\w]+)\],? \[nbPlayers = ([\w]+)\]?");
            Match mline1 = rline1.Match(lines[2]);
            if (mline1.Success)
            {
                try
                {
                    int smaxnbTours = int.Parse(mline1.Groups[1].Value);
                    int snbTours = int.Parse(mline1.Groups[2].Value);
                    int snbUnity = int.Parse(mline1.Groups[3].Value);
                    int scurrentPlayer = int.Parse(mline1.Groups[4].Value);
                    Boolean sstateGame = Boolean.Parse(mline1.Groups[5].Value);
                    snbPlayers = int.Parse(mline1.Groups[6].Value);
                    World.Instance.loadGameWorld(smaxnbTours, snbTours, snbUnity, scurrentPlayer, sstateGame);
                }
                catch (Exception)
                {
                    throw new Exception("Problème dans la conversion des String pour le stockage des variables de World");
                }
            }
            else
            {
                throw new Exception("Variables de World non matchées");
            }
            // gestion de la liste de types
            string sourcelistType = lines[6];
            Regex ItemRegex2 = new Regex(@"\[(\w+?)\]", RegexOptions.Compiled);
            List<String> sltype = new List<string>();
            foreach (Match ItemMatch in ItemRegex2.Matches(sourcelistType))
            {
                if (ItemMatch.Success)
                {
                    sltype.Add(ItemMatch.Groups[1].Value);
                }
                else
                {
                    throw new Exception("listType non matché");
                }
            }
            // gestion de la liste de types available
            string sourcelistType2 = lines[8];
            Regex ItemRegex3 = new Regex(@"\[(\w+?)\]", RegexOptions.Compiled);
            List<String> sltypeAv = new List<string>();
            foreach (Match ItemMatch in ItemRegex3.Matches(sourcelistType2))
            {
                if (ItemMatch.Success)
                {
                    sltypeAv.Add(ItemMatch.Groups[1].Value);
                }
                else
                {
                    throw new Exception("listTypeAvailable non matché");
                }
            }
            return snbPlayers;
        }
        //loadPlayer load les players dans l'environnement World
        public void loadPlayer(String[] lines, int snbPlayers)
        {
            //Gestion des players
            //on calcule l'indice de ligne avec (tare + nbplayerRead * 4)
            int tare = 11;
            int nbplayerRead = 0;
            String stype;
            while (nbplayerRead < snbPlayers)
            {
                Regex rlineP = new Regex(@"^\[nom = (.*)\],? \[numero = ([\w]+)\],? \[score = ([\w]+)\],? \[type = ([\w]+)\],?");
                Match mlineP = rlineP.Match(lines[tare + nbplayerRead * 4]);
                if (mlineP.Success)
                {
                    try
                    {
                        String snom = mlineP.Groups[1].Value;
                        int snumero = int.Parse(mlineP.Groups[2].Value);
                        int sscore = int.Parse(mlineP.Groups[3].Value);
                        stype = mlineP.Groups[4].Value;
                        //Position pDepart = new Position(int.Parse(mlineP.Groups[5].Value), int.Parse(mlineP.Groups[6].Value));
                        World.Instance.addPlayer(snom, stype);
                        World.Instance.players.ElementAt(nbplayerRead).score = sscore;
                        //World.Instance.players.ElementAt(nbplayerRead).pDepart = pDepart;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Problème dans la conversion des String pour le stockage des variables de player");
                    }
                    //on récupère listunit
                    if (stype != "Orc")
                    {
                        //le joueur est elf ou dwarf
                        string sourceString4 = lines[tare + nbplayerRead * 4 + 1];
                        Regex ItemRegex4 = new Regex(@"\[att = (\w+?)\], \[def = (\w+?)\], \[hp = (\w+?)\], \[nbDeplacement = (\w+?)\], \[initialLife = (\w+?)\], \[controler = (\w+?)\], \[position = \((\w+?),(\w+?)\)\],", RegexOptions.Compiled);
                        int cptUnity = -1;
                        foreach (Match ItemMatch in ItemRegex4.Matches(sourceString4))
                        {
                            cptUnity++;
                            if (ItemMatch.Success)
                            {
                                try
                                {
                                    int uatt = int.Parse(ItemMatch.Groups[1].Value);
                                    int udef = int.Parse(ItemMatch.Groups[2].Value);
                                    int uhp = int.Parse(ItemMatch.Groups[3].Value);
                                    int unbDeplacement = int.Parse(ItemMatch.Groups[4].Value);
                                    int uinitialLife = int.Parse(ItemMatch.Groups[5].Value);
                                    int ucontroler = int.Parse(ItemMatch.Groups[6].Value);
                                    Position uposition = new Position(int.Parse(ItemMatch.Groups[7].Value), int.Parse(ItemMatch.Groups[8].Value));
                                    if (stype == "Elf")
                                    {
                                        World.Instance.players.ElementAt(nbplayerRead).listUnit.Add(new Elf(World.Instance.players.ElementAt(nbplayerRead), uposition));
                                    }
                                    else
                                    {
                                        World.Instance.players.ElementAt(nbplayerRead).listUnit.Add(new Dwarf(World.Instance.players.ElementAt(nbplayerRead), uposition));
                                    }
                                    ((Unit)World.Instance.players.ElementAt(nbplayerRead).listUnit.ElementAt(cptUnity)).loadUnit(uatt, udef, uhp, unbDeplacement, uinitialLife, -1);
                                }
                                catch (Exception)
                                {
                                    throw new Exception("Problème dans la conversion des String pour le stockage des variables de listunit classique");
                                }
                            }
                            else
                            {
                                throw new Exception("Variables de listunit classique non matchées");
                            }
                        }
                        nbplayerRead++;
                    }
                    else
                    {
                        //le joueur est orc (gestion de pvorc)
                        string sourceString4 = lines[tare + nbplayerRead * 4 + 1];
                        Regex ItemRegex4 = new Regex(@"\[att = (\w+?)\], \[def = (\w+?)\], \[hp = (\w+?)\], \[nbDeplacement = (.*?)\], \[initialLife = (\w+?)\], \[controler = (\w+?)\], \[position = \((\w+?),(\w+?)\)\], \[pvOrc = (\w+?)\],", RegexOptions.Compiled);
                        String s = "";
                        int cptUnity = -1;
                        foreach (Match ItemMatch in ItemRegex4.Matches(sourceString4))
                        {
                            cptUnity++;
                            if (ItemMatch.Success)
                            {
                                try
                                {
                                    int uatt = int.Parse(ItemMatch.Groups[1].Value);
                                    int udef = int.Parse(ItemMatch.Groups[2].Value);
                                    int uhp = int.Parse(ItemMatch.Groups[3].Value);
                                    double unbDeplacement = double.Parse(ItemMatch.Groups[4].Value);
                                    int uinitialLife = int.Parse(ItemMatch.Groups[5].Value);
                                    int ucontroler = int.Parse(ItemMatch.Groups[6].Value);
                                    Position uposition = new Position(int.Parse(ItemMatch.Groups[7].Value), int.Parse(ItemMatch.Groups[8].Value));
                                    int upvOrc = int.Parse(ItemMatch.Groups[9].Value);
                                    s += " (" + uatt + "," + udef + "," + uhp + "," + unbDeplacement + "," + uinitialLife + "," + ucontroler + "," + uposition.x + "," + uposition.y + "," + upvOrc + ")";
                                    World.Instance.players.ElementAt(nbplayerRead).listUnit.Add(new Orc(World.Instance.players.ElementAt(nbplayerRead), uposition));
                                    ((Unit)World.Instance.players.ElementAt(nbplayerRead).listUnit.ElementAt(cptUnity)).loadUnit(uatt, udef, uhp, unbDeplacement, uinitialLife, upvOrc);
                                }
                                catch (Exception)
                                {
                                    throw new Exception("Problème dans la conversion des String pour le stockage des variables de listunit Orc");
                                }
                            }
                            else
                            {
                                throw new Exception("Variables de listunit Orc non matchées");
                            }
                        }
                        nbplayerRead++;
                    }
                }
                else
                {
                    throw new Exception("Variables de player non matchées");
                }
            }
        }
    }
}