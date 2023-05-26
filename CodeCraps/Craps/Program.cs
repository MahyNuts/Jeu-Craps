using System;
using System.Security.Cryptography.X509Certificates;

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
            string[] pseudonyme;
            int difficulty = 0;
            sousProgrammes sousP = new sousProgrammes();
            joueurs joueurs = new joueurs();
            des des = new des();

            sousP.reglement();
            joueurs.AjoutJoueurs(out nbJoueurs);

            if (nbJoueurs > 1)
            {
                joueurs.choixPseudo(nbJoueurs, out pseudonyme);
                int[] tokens = new int[nbJoueurs];
                sousP.distTokens(pseudonyme, nbJoueurs, ref tokens);
                bool bot = false;
                do
                {
                    for (int j = 0; j < nbJoueurs; j++)
                    {
                        sousP.affichageCraps();
                        int numJoueur = j + 1;
                        Console.WriteLine(pseudonyme[j] + " à vous !");

                        if (tokens[j] > 0)
                        {
                            Console.Write("Vous avez ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(tokens[j]);
                            Console.ResetColor();
                            Console.Write(" jetons.");
                            Console.WriteLine("");
                            sousP.miseJoueur(bot, j, tokens, difficulty, out mise);
                            Console.WriteLine("");
                            sousP.lanceDes(out de1, out de2, out sommeDes);
                            des.affichDes(de1, de2);
                            Console.WriteLine("");
                            Console.WriteLine("Les dés tirés sont " + de1 + " et " + de2 + ".");
                            Console.WriteLine("La somme des dés est de " + sommeDes + ".");
                            Console.WriteLine("");
                            sousP.VerifSomme(j, sommeDes, de1, de2, mise, saveSomme, ref tokens);
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Passez votre tour, vous n'avez plus de jetons.");
                        }

                        int verifUneValeure = 0;

                        for (int i = 0; i < nbJoueurs; i++)//Verification une seule case de la table est positive
                        {
                            if (tokens[i] > 0)
                            {
                                verifUneValeure += 1;
                            }
                        }
                        if (verifUneValeure == 1)
                        {
                            fin = true;
                        }
                        Console.WriteLine("Appuyez sur ENTER pour continuer.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                } while (fin == false);
                joueurs.winner(nbJoueurs, tokens, pseudonyme);

            }

            else
            {
                joueurs.choixPseudo(nbJoueurs, out pseudonyme);
                nbJoueurs += 1;
                int[] tokens = new int[nbJoueurs];
                sousP.distTokens(pseudonyme, nbJoueurs, ref tokens);
                sousP.botDifficulty(out difficulty);
                bool bot = true;

                do
                {
                    for (int j = 0; j < nbJoueurs; j++)
                    {
                        sousP.affichageCraps();
                        int numJoueur = j + 1;
                        Console.WriteLine(pseudonyme[j] + " à vous !");

                        if (tokens[j] > 0)
                        {
                            Console.Write("Vous avez ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(tokens[j]);
                            Console.ResetColor();
                            Console.Write(" jetons.");
                            Console.WriteLine("");
                            sousP.miseJoueur(bot, j, tokens, difficulty, out mise);
                            Console.WriteLine("");
                            sousP.lanceDes(out de1, out de2, out sommeDes);
                            des.affichDes(de1, de2);
                            Console.WriteLine("");
                            Console.WriteLine("Les dés tirés sont " + de1 + " et " + de2 + ".");
                            Console.WriteLine("La somme des dés est de " + sommeDes + ".");
                            Console.WriteLine("");
                            sousP.VerifSomme(j, sommeDes, de1, de2, mise, saveSomme, ref tokens);
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Passez votre tour, vous n'avez plus de jetons.");
                        }

                        int verifUneValeure = 0;

                        for (int i = 0; i < nbJoueurs; i++)//Verification une seule case de la table est positive
                        {
                            if (tokens[i] > 0)
                            {
                                verifUneValeure += 1;
                            }
                        }
                        if (verifUneValeure == 1)
                        {
                            fin = true;
                        }
                        Console.WriteLine("Appuyez sur ENTER pour continuer.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                } while (fin == false);
                joueurs.winner(nbJoueurs, tokens, pseudonyme);
            }
        }
    }
}
