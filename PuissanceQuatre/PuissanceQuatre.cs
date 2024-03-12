using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class PuissanceQuatre
    {
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;
        public char[,] grille;

        public PuissanceQuatre()
        {
            grille = new char[4, 7];
        }

        public void BoucleJeu()
        {
            while (!quiterJeu)
            {
                grille = new char[4, 7]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                };
                while (!quiterJeu)
                {
                    if (tourDuJoueur)
                    {
                        TourJoueur('X');
                        if (verifVictoire('X'))
                        {
                            finPartie("Le joueur 1 à gagné !");
                            break;
                        }
                    }
                    else
                    {
                        TourJoueur('O');
                        if (verifVictoire('O'))
                        {
                            finPartie("Le joueur 2 à gagné !");
                            break;
                        }
                    }
                    tourDuJoueur = !tourDuJoueur;
                    if (verifEgalite())
                    {
                        finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                        break;
                    }
                }
                if (!quiterJeu)
                {
                    Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                GetKey:
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter:
                            break;
                        case ConsoleKey.Escape:
                            quiterJeu = true;
                            Console.Clear();
                            break;
                        default:
                            goto GetKey;
                    }
                }

            }
        }

        public void TourJoueur(char joueur)
        {
            int column = 0;
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                Console.Clear();
                affichePlateau(grille);
                Console.WriteLine();
                Console.WriteLine($"Joueur {joueur}, choisir une colonne et appuyer sur [Entrer]");
                int cursorLeft = column * 4 + 4; 
                int cursorTop = grille.GetLength(0) * 2;

                Console.SetCursorPosition(cursorLeft, cursorTop);

                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Escape: 
                        quiterJeu = true;
                        Console.Clear();
                        return;

                    case ConsoleKey.RightArrow:
                        column = column >= 6 ? 0 : column + 1;
                        break;

                    case ConsoleKey.LeftArrow:
                        column = column <= 0 ? 6 : column - 1;
                        break;

                    case ConsoleKey.Enter:
                        for (int row = grille.GetLength(0) - 1; row >= 0; row--) 
                        {
                            if (grille[row, column] == ' ') 
                            {
                                grille[row, column] = joueur; 
                                moved = true;
                                break; 
                            }
                        }
                        if (!moved)
                        {
                            Console.WriteLine("Colonne pleine. Choisissez une autre colonne.");
                            Console.ReadKey(true); 
                        }
                        break;
                }
            }
        }


        public void affichePlateau(char[,] grille)
        {
            int lignes = grille.GetLength(0);
            int colonnes = grille.GetLength(1);

            Console.Write(" ");
            for (int j = 0; j < colonnes; j++)
            {
                Console.Write($"  {j} ");
            }
            Console.WriteLine();

            for (int i = 0; i < lignes; i++)
            {
                Console.Write($"{i}");
                for (int j = 0; j < colonnes; j++)
                {
                    Console.Write(" | " + grille[i, j]);
                }
                Console.WriteLine(" |");

                if (i < lignes - 1)
                {
                    Console.Write("  ");
                    for (int j = 0; j < colonnes; j++)
                    {
                        Console.Write("---+");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        public bool verifVictoire(char c)
        {
            int lignes = grille.GetLength(0);
            int colonnes = grille.GetLength(1);

            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < colonnes - 3; j++)
                {
                    if (grille[i, j] == c && grille[i, j + 1] == c && grille[i, j + 2] == c && grille[i, j + 3] == c)
                        return true;
                }
            }

            for (int i = 0; i < lignes - 3; i++)
            {
                for (int j = 0; j < colonnes; j++)
                {
                    if (grille[i, j] == c && grille[i + 1, j] == c && grille[i + 2, j] == c && grille[i + 3, j] == c)
                        return true;
                }
            }

            for (int i = 0; i < lignes - 3; i++)
            {
                for (int j = 0; j < colonnes - 3; j++)
                {
                    if (grille[i, j] == c && grille[i + 1, j + 1] == c && grille[i + 2, j + 2] == c && grille[i + 3, j + 3] == c)
                        return true;
                    if (j >= 3 && grille[i, j] == c && grille[i + 1, j - 1] == c && grille[i + 2, j - 2] == c && grille[i + 3, j - 3] == c)
                        return true;
                }
            }

            return false;
        }


        public bool verifEgalite()
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (grille[i, j] == ' ')
                        return false; 
                }
            }
            return true; 
        }



        public void finPartie(string msg)
        {
            Console.Clear();
            affichePlateau(grille);
            Console.WriteLine(msg);
        }
    }
}
