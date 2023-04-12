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
                Console.WriteLine("Combien de joueurs seriez-vous au total ? (5 joueurs maximum)");
                int.TryParse(Console.ReadLine(), out nbJoueurs);
                Console.Clear();
            } while (nbJoueurs < 1 || nbJoueurs > 5);         
        }
        public void choixPseudo(int nbJoueurs, out string[] pseudonyme)
            {
                pseudonyme = new string[nbJoueurs];
                for(int i = 0;i < nbJoueurs; i++)
                {
                    int joueur = i + 1;
                    do
                    {
                        Console.WriteLine("Joueur " + joueur + " ! Quel est votre pseudonyme/surnom ?");
                        pseudonyme[i ] = Console.ReadLine();
                        Console.Clear();
                    } while (string.IsNullOrWhiteSpace(pseudonyme[i]));
                }
            }
    }

    
        


}
