using System;
using System.Collections.Generic;
using System.Text;

namespace Craps
{
    public struct sousProgrammes
    {
        public void miseJoueur(int tokens, out int mise)
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
            } while (mise > tokens || mise < 1);

            Console.WriteLine("Vous misez " + mise + " jetons.");
        }

        public void lanceDes(out int de1, out int de2, out int sommeDes)
        {
            Random rand = new Random();
            de1 = rand.Next(1, 6);
            de2 = rand.Next(1, 6);
            sommeDes = de1 + de2;
        }

        public void VerifSomme(int sommeDes, int de1, int de2, int mise, int saveSomme, ref int tokens)
        {

            if (sommeDes == 7 || sommeDes == 11)
            {
                tokens = tokens + mise;
                Console.WriteLine("Vous êtes tombé sur " + sommeDes + ". Vous remportez votre mise.");
            }
            else
            {
                if (sommeDes == 2 || sommeDes == 3 || sommeDes == 12)
                {
                    tokens = tokens - mise;
                    Console.WriteLine("Vous êtes tombé sur " + sommeDes + ". Vous perdez votre mise.");
                }
                else
                {
                    saveSomme = sommeDes;
                    sommeDes = 0;
                    while (sommeDes != saveSomme || sommeDes != 7 || sommeDes != 11 || sommeDes != 2 || sommeDes != 3 || sommeDes != 12)
                    {
                        lanceDes(out de1, out de2, out sommeDes);
                    }
                    if (sommeDes == saveSomme)
                    {
                        Console.WriteLine("Vous êtes tombé sur la somme exacte. Vous remportez votre mise.");
                    }
                    else
                    {
                        if (sommeDes == 7 || sommeDes == 11)
                        {
                            Console.WriteLine("Vous êtes tombé sur " + sommeDes + ". Vous remportez votre mise.");
                        }
                        else
                        {
                            if (sommeDes == 2 || sommeDes == 3 || sommeDes == 12)
                            {
                                Console.WriteLine("Vous êtes tombé sur " + sommeDes + ". Vous perdez votre mise.");
                            }
                        }
                    }
                }
            }

        }
    }
}