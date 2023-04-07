using System;
using System.Collections.Generic;
using System.Text;

namespace Craps
{
    public struct joueurs
    {
        public void AjoutJoueurs(out int nbJoueurs)
        {
            Console.WriteLine("Combien de joueurs seriez-vous au total ? (5 joueurs maximum)");
            do
            {
                int.TryParse(Console.ReadLine(), out nbJoueurs);
            } while (nbJoueurs < 1 || nbJoueurs > 5);
        }
    }
}
