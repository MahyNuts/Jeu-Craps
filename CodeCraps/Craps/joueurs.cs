using System;
using System.Collections.Generic;
using System.Text;

namespace Craps
{
    public struct joueurs
    {
        public void AjoutJoueurs(out int nbJoueurs)
        {
            sousProgrammes sousP = new sousProgrammes();
            do
            {
                sousP.affichageCraps();
                Console.WriteLine("Combien de joueurs seriez-vous au total ? (1 à 5 joueurs)");
                int.TryParse(Console.ReadLine(), out nbJoueurs);
                Console.Clear();
            } while (nbJoueurs < 1 || nbJoueurs > 5);         
        }
        public void choixPseudo(int nbJoueurs, out string[] pseudonyme)
        {
            sousProgrammes sousP = new sousProgrammes();
            if (nbJoueurs > 1)
            {
                pseudonyme = new string[nbJoueurs];
            }
            else
            {
                pseudonyme = new string[nbJoueurs+1];
            }

            if(nbJoueurs > 1)
            {
                for(int i = 0;i < nbJoueurs; i++)
                {
                    int joueur = i + 1;
                    do
                    {
                        sousP.affichageCraps();
                        Console.WriteLine("Joueur " + joueur + " ! Quel est votre pseudonyme/surnom ?");
                        pseudonyme[i] = Console.ReadLine();
                        Console.Clear();
                    } while (string.IsNullOrWhiteSpace(pseudonyme[i]));
                }
            }
            if(nbJoueurs == 1)
            {
                do
                {
                    sousP.affichageCraps();
                    Console.WriteLine("Joueur 1 ! Quel est votre pseudonyme/surnom ?");
                    pseudonyme[0] = Console.ReadLine();
                    Console.Clear();
                } while (string.IsNullOrWhiteSpace(pseudonyme[0]));
                pseudonyme[1] = "Joueur virtuel";
            }

        }

        public void winner(int nbJoueurs, int[] tokens, string[] pseudonyme)
        {
            int gagnant = 0;
            bool exaequo = true;

            for (int i = 0; i < nbJoueurs; i++)
            {
                if (tokens[i] > 0)
                {
                    gagnant = i;
                    exaequo = false;
                }
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            if (exaequo == true)
            {
                Console.WriteLine("Il n'y a aucun gagnant.");
            }
            else
            {
                Console.WriteLine("Le gagnant est " + pseudonyme[gagnant] + " !");
            }
            Console.ResetColor();
        }
    }

    
        


}
