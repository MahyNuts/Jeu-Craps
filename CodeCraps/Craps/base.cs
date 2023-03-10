using System;
using System.Collections.Generic;
using System.Text;

namespace Craps
{
    public struct @base
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
    }
}
