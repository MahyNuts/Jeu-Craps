using System;
using System.Collections.Generic;
using System.Text;

namespace Craps
{
    public struct joueurs
    {
        public void AjoutJoueurs(out int nbJoueurs)
        {
            do
            {
                Console.WriteLine("Combien de joueurs seriez-vous au total ? (1 à 5 joueurs)");
                int.TryParse(Console.ReadLine(), out nbJoueurs);
                Console.Clear();
            } while (nbJoueurs > 1 || nbJoueurs > 5);         
        }
        public void choixPseudo(int nbJoueurs, out string[] pseudonyme)
        {
            if(nbJoueurs > 1)
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
                    Console.WriteLine("Joueur 1 ! Quel est votre pseudonyme/surnom ?");
                    pseudonyme[0] = Console.ReadLine();
                    Console.Clear();
                } while (string.IsNullOrWhiteSpace(pseudonyme[0]));
                pseudonyme[1] = "Bot";
                Console.WriteLine("Un joueur virtuel a été ajouté.");
            }

        }
    }

    
        


}
