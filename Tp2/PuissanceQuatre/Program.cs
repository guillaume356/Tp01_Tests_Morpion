using MorpionApp.Interfaces;

namespace MorpionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IChoixJeu choixJeu = new ChoixJeu();
            choixJeu.LancerSelectionJeu();
        }
    }
}
