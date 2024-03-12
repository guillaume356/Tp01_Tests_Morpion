using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public static class JoueurFactory
    {
        public static Joueur CreerJoueur(char symbole, string nom)
        {
            return new Joueur(symbole, nom);
        }

    }

}
