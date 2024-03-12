using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorpionApp.Interfaces;

namespace MorpionApp
{
    public class Joueur : IJoueur

    {
        public char Symbole { get; }
        public string Nom { get; }

        public Joueur(char symbole, string nom)
        {
            Symbole = symbole;
            Nom = nom;
        }
    }

}
