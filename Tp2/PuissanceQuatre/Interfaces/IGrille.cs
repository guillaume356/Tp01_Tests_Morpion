using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp.Interfaces
{
    public interface IGrille
    {
        char[,] GrilleMatrice { get; }
        char GetValeurCase(int ligne, int colonne);
        void SetValeurCase(int ligne, int colonne, char valeur);
        int Lignes { get; }
        int Colonnes { get; }
        void InitialiserGrille();
    }
}

