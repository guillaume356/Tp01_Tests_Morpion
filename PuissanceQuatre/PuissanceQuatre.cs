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
                affichePlateau();
                Console.WriteLine();
                Console.WriteLine($"Joueur {joueur}, choisir une colonne et appuyer sur [Entrer]");
                Console.SetCursorPosition(column * 6 + 1, 0);

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


        public void affichePlateau()
        {
            Console.WriteLine();
            Console.WriteLine($" {grille[0, 0]}  |  {grille[0, 1]}  |  {grille[0, 2]}  |  {grille[0, 3]}  |  {grille[0, 4]}  |  {grille[0, 5]}  |  {grille[0, 6]}");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine("----+-----+-----+-----+-----+-----+----");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine($" {grille[1, 0]}  |  {grille[1, 1]}  |  {grille[1, 2]}  |  {grille[1, 3]}  |  {grille[1, 4]}  |  {grille[1, 5]}  |  {grille[1, 6]}");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine("----+-----+-----+-----+-----+-----+----");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine($" {grille[2, 0]}  |  {grille[2, 1]}  |  {grille[2, 2]}  |  {grille[2, 3]}  |  {grille[2, 4]}  |  {grille[2, 5]}  |  {grille[1, 6]}");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine("----+-----+-----+-----+-----+-----+----");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine($" {grille[3, 0]}  |  {grille[3, 1]}  |  {grille[3, 2]}  |  {grille[3, 3]}  |  {grille[3, 4]}  |  {grille[3, 5]}  |  {grille[1, 6]}");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine("----+-----+-----+-----+-----+-----+----");
        }

        public bool verifVictoire(char c) =>
             grille[0, 0] == c && grille[1, 0] == c && grille[2, 0] == c && grille[3, 0] == c ||
             grille[0, 1] == c && grille[1, 1] == c && grille[2, 1] == c && grille[3, 1] == c ||
             grille[0, 2] == c && grille[1, 2] == c && grille[2, 2] == c && grille[3, 2] == c ||
             grille[0, 3] == c && grille[1, 3] == c && grille[2, 3] == c && grille[3, 3] == c ||
             grille[0, 4] == c && grille[1, 4] == c && grille[2, 4] == c && grille[3, 4] == c ||
             grille[0, 5] == c && grille[1, 5] == c && grille[2, 5] == c && grille[3, 5] == c ||
             grille[0, 6] == c && grille[1, 6] == c && grille[2, 6] == c && grille[3, 6] == c ||
             grille[0, 0] == c && grille[0, 1] == c && grille[0, 2] == c && grille[0, 3] == c ||
             grille[0, 1] == c && grille[0, 2] == c && grille[0, 3] == c && grille[0, 4] == c ||
             grille[0, 2] == c && grille[0, 3] == c && grille[0, 3] == c && grille[0, 5] == c ||
             grille[0, 3] == c && grille[0, 4] == c && grille[0, 5] == c && grille[0, 6] == c ||
             grille[1, 0] == c && grille[1, 1] == c && grille[1, 2] == c && grille[1, 3] == c ||
             grille[1, 1] == c && grille[1, 2] == c && grille[1, 3] == c && grille[1, 4] == c ||
             grille[1, 2] == c && grille[1, 3] == c && grille[1, 4] == c && grille[1, 5] == c ||
             grille[1, 4] == c && grille[1, 4] == c && grille[1, 5] == c && grille[1, 6] == c ||
             grille[2, 0] == c && grille[2, 1] == c && grille[2, 2] == c && grille[2, 3] == c ||
             grille[2, 1] == c && grille[2, 2] == c && grille[2, 3] == c && grille[2, 4] == c ||
             grille[2, 2] == c && grille[2, 3] == c && grille[2, 3] == c && grille[2, 5] == c ||
             grille[2, 3] == c && grille[2, 4] == c && grille[2, 5] == c && grille[2, 6] == c ||
             grille[3, 0] == c && grille[3, 1] == c && grille[3, 2] == c && grille[3, 3] == c ||
             grille[3, 1] == c && grille[3, 2] == c && grille[3, 3] == c && grille[3, 4] == c ||
             grille[3, 2] == c && grille[3, 3] == c && grille[3, 4] == c && grille[3, 5] == c ||
             grille[3, 3] == c && grille[3, 4] == c && grille[3, 5] == c && grille[3, 6] == c ||
             grille[0, 0] == c && grille[1, 1] == c && grille[2, 2] == c && grille[3, 3] == c ||
             grille[0, 1] == c && grille[1, 2] == c && grille[2, 3] == c && grille[3, 4] == c ||
             grille[0, 2] == c && grille[1, 3] == c && grille[2, 4] == c && grille[3, 5] == c ||
             grille[0, 3] == c && grille[1, 4] == c && grille[2, 5] == c && grille[3, 6] == c ||
             grille[0, 3] == c && grille[1, 2] == c && grille[2, 1] == c && grille[3, 0] == c ||
             grille[0, 4] == c && grille[1, 4] == c && grille[2, 2] == c && grille[3, 1] == c ||
             grille[0, 5] == c && grille[1, 3] == c && grille[2, 3] == c && grille[3, 2] == c ||
             grille[0, 6] == c && grille[1, 5] == c && grille[2, 4] == c && grille[3, 3] == c;

        public bool verifEgalite() =>
            grille[0, 0] != ' ' && grille[0, 1] != ' ' && grille[0, 2] != ' ' && grille[0, 3] != ' ' && grille[0, 4] != ' ' && grille[0, 5] != ' ' && grille[0, 6] != ' ' &&
            grille[1, 0] != ' ' && grille[1, 1] != ' ' && grille[1, 2] != ' ' && grille[1, 3] != ' ' && grille[1, 4] != ' ' && grille[1, 5] != ' ' && grille[1, 6] != ' ' &&
            grille[2, 0] != ' ' && grille[2, 1] != ' ' && grille[1, 2] != ' ' && grille[2, 3] != ' ' && grille[2, 4] != ' ' && grille[2, 5] != ' ' && grille[2, 6] != ' ' &&
            grille[3, 0] != ' ' && grille[3, 1] != ' ' && grille[3, 2] != ' ' && grille[3, 3] != ' ' && grille[3, 4] != ' ' && grille[3, 5] != ' ' && grille[3, 5] != ' ';


        public void finPartie(string msg)
        {
            Console.Clear();
            affichePlateau();
            Console.WriteLine(msg);
        }
    }
}
