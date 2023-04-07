using System;

namespace Craps
{
    class Program
    {
        static void Main(string[] args)
        {
            int mise;
            int de1;
            int de2;
            int sommeDes;
            int saveSomme = 0;
            int nbJoueurs;
            bool fin = false;
            sousProgrammes sousP = new sousProgrammes();
            joueurs joueurs = new joueurs();

            joueurs.AjoutJoueurs(out nbJoueurs);

            int[] tokens = new int[nbJoueurs];
            sousP.distTokens(nbJoueurs, ref tokens);

            do
            {
                for (int j = 0; j < nbJoueurs; j++)
                {
                    int numJoueur = j + 1;
                    Console.WriteLine("Joueur " + numJoueur + " à vous !");

                    if (tokens[j] > 0)
                    {
                        Console.WriteLine("Vous avez " + tokens[j] + " jetons.");
                        Console.WriteLine("");
                        sousP.miseJoueur(j, tokens, out mise);
                        Console.WriteLine("");
                        sousP.lanceDes(out de1, out de2, out sommeDes);
                        Console.WriteLine("Les dés tirés sont " + de1 + " et " + de2 + ".");
                        Console.WriteLine("La somme des dés est de " + sommeDes + ".");
                        sousP.VerifSomme(j, sommeDes, de1, de2, mise, saveSomme, ref tokens);
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Passez votre tour, vous n'avez plus de jetons.");
                    }

                    int verifUneValeure = 0;
                    
                    for(int i = 0; i < nbJoueurs; i++)//Verification une seule case de la table est positive
                    {
                        if(tokens[i] > 0)
                        {
                            verifUneValeure += 1;
                        }
                    }
                    if(verifUneValeure == 1)
                    {
                        fin = true;
                    }
                }
            } while ();
        }
    }
}
