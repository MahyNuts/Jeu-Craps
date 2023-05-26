using System;
using System.Collections.Generic;
using System.Text;

namespace Craps
{
    public struct sousProgrammes
    {
        public void miseJoueur(bool bot, int j, int[] tokens, int difficulty, out int mise)
        {
            Random rand = new Random();
            if(bot == false)
            {
                do
                {
                    Console.WriteLine("Combien voulez-vous misez ? ");
                    int.TryParse(Console.ReadLine(), out mise);
                    if (mise == 0)
                    {
                        Console.WriteLine("Impossible de ne rien miser.");
                    }
                    else
                    {
                        if (mise < 0)
                        {
                            Console.WriteLine("Pas la peine d'essayer.");
                        }
                        else
                        {
                            if (mise > 10)
                            {
                                Console.WriteLine("Vous n'avez pas assez de jetons");
                            }
                        }
                    }
                    Console.WriteLine("");
                } while (mise > tokens[j] || mise < 1);

                Console.WriteLine("Vous misez " + mise + " jetons.");
            }

            else
            {
                if (j == 1)
                {
                    mise = 0;
                    if (difficulty == 1 )
                    {
                        if(tokens[j] > 1)
                        {
                            int MoitieTokens = tokens[j] / 2;
                            mise = rand.Next(MoitieTokens, tokens[j]);
                            
                        }
                        else
                        {
                            mise = 1;
                        }
                        Console.WriteLine("Le joueur virtuel a misé " + mise + " jetons.");
                    }
                    if(difficulty == 2)
                    {
                        int cc = rand.Next(1, 20);
                        if (cc == 20)
                        {
                            if(tokens[j] > 1)
                            {
                                int MoitieTokens = tokens[j] / 2;
                                mise = rand.Next(MoitieTokens, tokens[j]);
                            }
                            else
                            {
                                mise = 1;
                            }
                        }
                        else
                        {
                            mise = rand.Next(1, tokens[j]-1);
                        }
                        
                        Console.WriteLine("Le joueur virtuel a misé " + mise + " jetons.");
                    }
                    if(difficulty == 3)
                    {
                        if(tokens[j] > 1)
                        {
                            int MoitieTokens = tokens[j] / 2;
                            mise = rand.Next(1, MoitieTokens);
                        }
                        else
                        {
                            mise = 1;
                        }
                        Console.WriteLine("Le joueur virtuel a misé " + mise + " jetons.");  
                    }
                    
                    
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Combien voulez-vous misez ? ");
                        int.TryParse(Console.ReadLine(), out mise);
                        if (mise == 0)
                        {
                            Console.WriteLine("Impossible de ne rien miser.");
                        }
                        else
                        {
                            if (mise < 0)
                            {
                                Console.WriteLine("Pas la peine d'essayer.");
                            }
                            else
                            {
                                if (mise > 10)
                                {
                                    Console.WriteLine("Vous n'avez pas assez de jetons");
                                }
                            }
                        }
                        Console.WriteLine("");
                    } while (mise > tokens[j] || mise < 1);

                    Console.WriteLine("Vous misez " + mise + " jetons.");
                }
            }

        }

        public void lanceDes(out int de1, out int de2, out int sommeDes)
        {
            Random rand = new Random();
            de1 = rand.Next(1, 6);
            de2 = rand.Next(1, 6);
            sommeDes = de1 + de2;
        }

        public void VerifSomme(int j, int sommeDes, int de1, int de2, int mise, int saveSomme, ref int[] tokens)
        {
            des des = new des();

            if (sommeDes == 7 || sommeDes == 11)
            {
                tokens[j] += mise;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vous êtes tombé sur " + sommeDes + ". Vous remportez votre mise.");
                Console.ResetColor();
            }
            else
            {
                if (sommeDes == 2 || sommeDes == 3 || sommeDes == 12)
                {
                    tokens[j] -= mise;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vous êtes tombé sur " + sommeDes + ". Vous perdez votre mise.");
                    Console.ResetColor();
                }
                else
                {
                    saveSomme = sommeDes;
                    sommeDes = 0;
                    do
                    {
                        lanceDes(out de1, out de2, out sommeDes);
                    } while (sommeDes != saveSomme && sommeDes != 7 && sommeDes != 11 && sommeDes != 2 && sommeDes != 3 && sommeDes != 12);
                    if (sommeDes == saveSomme)
                    {
                        des.affichDes(de1, de2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Ouf ! Vous êtes retombé sur "+saveSomme+". Vous remportez votre mise.");
                        Console.ResetColor();
                        tokens[j] += mise;
                    }
                    else
                    {
                        if (sommeDes == 7 || sommeDes == 11)
                        {
                            des.affichDes(de1, de2);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Vous n'êtes pas tombé sur " + saveSomme + " mais sur " + sommeDes + ". La chance vous sourit. Vous remportez votre mise.");
                            Console.ResetColor();
                            tokens[j] += mise;
                        }
                        else
                        {
                            if (sommeDes == 2 || sommeDes == 3 || sommeDes == 12)
                            {
                                des.affichDes(de1, de2);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Vous n'êtes pas tombé sur " + saveSomme + " mais sur " + sommeDes + ". Désolé mais vous perdez votre mise.");
                                Console.ResetColor();
                                tokens[j] -= mise;
                            }
                        }
                    }
                }
            }

        }

        public void distTokens(string[] pseudonyme, int nbJoueurs, ref int[] tokens)
        {
            for(int i = 0; i < nbJoueurs; i++)
            {
                if(pseudonyme[i] == "SDF" || pseudonyme[i] == "sdf")
                {
                    tokens[i] = 1;
                }
                else
                {
                    tokens[i] = 10;
                }
            }
 
            
        }

        public void botDifficulty(out int difficulty)
        {
            do
            {
                affichageCraps();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Un joueur virtuel a été ajouté.\n");
                Console.ResetColor();
                Console.WriteLine("A quelle difficulté voulez-vous mettre votre joueur virtuel ?\n1 - Facile\n2 - Moyen\n3 - Difficile");
                int.TryParse(Console.ReadLine(), out difficulty);
                Console.Clear();
            } while (difficulty < 1 || difficulty > 3);
        }

        public void reglement()
        {
            int validRegle;
            do
            {
                affichageCraps();
                Console.WriteLine("Connaissez-vous les règles ?\n1 - Oui\n2 - Non\n");
                int.TryParse(Console.ReadLine(), out validRegle);
                Console.Clear();
            } while (validRegle < 1 || validRegle > 2);
            if (validRegle == 2)
            {
                affichageCraps();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" Chaque joueur débute la partie avec 10 jetons.\n Le but est d'être le dernier joueur à posséder au moins un jeton.\n Vous devez miser un nombre de jetons compris entre 1 et le total de vos jetons.\n\n Si la somme des dés que vous lancez est égale à 7 ou 11, vous gagnez votre mise.\n Par contre, si la somme des dés est de 2, 3 ou 12, vous perdez votre mise.\n Si la somme est différente de ces valeurs,\n vous devez relancer les dés jusqu'à obtenir la même somme que précédemment pour gagner votre mise.\n Il est également possible de tomber sur une somme chanceuse ou malchanceuse dans ce cas là.\n");
                Console.ResetColor();
                Console.WriteLine("Appuyez sur ENTER pour continuer.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void affichageCraps()
        {
            Console.WriteLine("   _____                     ");
            Console.WriteLine("  / ____|                    ");
            Console.WriteLine(" | |     _ __ __ _ _ __  ___ ");
            Console.WriteLine(" | |    | '__/ _` | '_ \\/ __|");
            Console.WriteLine(" | |____| | | (_| | |_) \\__ \\");
            Console.WriteLine("  \\_____|_|  \\__,_| .__/|___/");
            Console.WriteLine("                  | |        ");
            Console.WriteLine("                  |_|        \n");
        }
    }
}