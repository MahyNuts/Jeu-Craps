using System;
using System.Collections.Generic;
using System.Text;

namespace Craps
{
    public struct sousProgrammes
    {
        public void miseJoueur(int j, int[] tokens, out int mise)
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

        public void distTokens(int nbJoueurs, ref int[] tokens)
        {
            for(int i = 0; i < nbJoueurs; i++)
            {
                tokens[i] = 10;
            }
        }
    }
}