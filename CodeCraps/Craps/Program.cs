using System;

namespace Craps
{
    class Program
    {
        static void Main(string[] args)
        {
            int tokens = 10;
            int mise;
            int de1;
            int de2;
            int sommeDes;
            int saveSomme;
            @base bases = new @base();
            Console.WriteLine("Vous commencez avec " + tokens + " jetons.");
            Console.WriteLine("");
            bases.miseJoueur(tokens, out mise);
            Console.WriteLine("");
            bases.lanceDes(out de1, out de2, out sommeDes);
            Console.WriteLine("Les dés tirés sont : "+de1+" et "+de2+".");
            Console.WriteLine("La somme des dés est de " + sommeDes + ".");
            if(sommeDes==7 || sommeDes == 11)
            {
                tokens = tokens + mise;
            }
            else
            {
                if (sommeDes == 2 || sommeDes == 3 || sommeDes == 12)
                {
                    tokens = tokens - mise;
                }
                else
                {
                    saveSomme = sommeDes;
                    while(sommeDes != saveSomme || sommeDes == 7 || sommeDes == 11 || sommeDes == 2 || sommeDes == 3 || sommeDes == 12)
                    {
                        bases.lanceDes(out de1, out de2, out sommeDes);
                    }
                    if(sommeDes == saveSomme)
                    {
                        Console.WriteLine("Vous êtes tombé sur la somme exacte. Vous remportez votre mise."); 
                    }
                    else
                    {
                        if (sommeDes == 7 || sommeDes == 11)
                        {
                            Console.WriteLine("Vous êtes tombé sur " + sommeDes + ". Vous remportez votre mise.");
                        }
                        else (sommeDes == 2 || sommeDes == 3 || sommeDes == 12)
                        {

                        }
                    }
                }
            }

        }
    }
}
