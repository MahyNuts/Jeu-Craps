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
            int saveSomme = 0;
            @base bases = new @base();
            Console.WriteLine("Vous commencez avec " + tokens + " jetons.");
            Console.WriteLine("");
            bases.miseJoueur(tokens, out mise);
            Console.WriteLine("");
            bases.lanceDes(out de1, out de2, out sommeDes);
            Console.WriteLine("Les dés tirés sont : "+de1+" et "+de2+".");
            Console.WriteLine("La somme des dés est de " + sommeDes + ".");
            bases.VerifSomme(sommeDes, de1, de2, mise, saveSomme, ref tokens);

        }
    }
}
