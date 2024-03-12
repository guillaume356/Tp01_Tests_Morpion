﻿using MorpionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Morpion
    {
        private IGameView view;
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;
        public char[,] grille;

        public Morpion(IGameView gameView)
        {
            view = gameView;
            grille = new char[3, 3];
        }

        public void BoucleJeu()
        {
            while (!quiterJeu)
            {
                grille = new char[3, 3]
                {
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
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
                    view.DisplayLineBreakMessage("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                GetKey:
                    switch (view.GetUserInput())
                    {
                        case ConsoleKey.Enter:
                            break;
                        case ConsoleKey.Escape:
                            quiterJeu = true;
                            view.ClearScreen();
                            break;
                        default:
                            goto GetKey;
                    }
                }

            }
        }

        public void TourJoueur(char joueur)
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                view.ClearScreen();
                affichePlateau(grille);
                view.DisplayLineBreak();
                view.DisplayLineBreakMessage($"Joueur {joueur}, choisir une case valide et appuyer sur [Entrer]");
                int cursorLeft = (column * 4) + 2;
                int cursorTop = (row * 2) + 1;

                view.SetCursorPosition(cursorLeft, cursorTop);

                var key = view.GetUserInput();
                switch (key)
                {
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        view.ClearScreen();
                        return;

                    case ConsoleKey.RightArrow:
                        column = column >= 2 ? 0 : column + 1;
                        break;

                    case ConsoleKey.LeftArrow:
                        column = column <= 0 ? 2 : column - 1;
                        break;

                    case ConsoleKey.UpArrow:
                        row = row <= 0 ? 2 : row - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        row = row >= 2 ? 0 : row + 1;
                        break;
                    case ConsoleKey.Enter:
                        if (grille[row, column] == ' ')
                        {
                            grille[row, column] = joueur;
                            moved = true;
                        }
                        break;
                }
            }
        }


        public void affichePlateau(char[,] grille)
        {
            int lignes = grille.GetLength(0);
            int colonnes = grille.GetLength(1);

            view.Display(" ");
            for (int j = 0; j < colonnes; j++)
            {
                view.Display($"  {j} ");
            }
            view.DisplayLineBreak();

            for (int i = 0; i < lignes; i++)
            {
                view.Display($"{i}");
                for (int j = 0; j < colonnes; j++)
                {
                    view.Display(" | " + grille[i, j]);
                }
                view.DisplayLineBreakMessage(" |");

                if (i < lignes - 1)
                {
                    view.Display("  ");
                    for (int j = 0; j < colonnes; j++)
                    {
                        view.Display("---+");
                    }
                    view.DisplayLineBreak();
                }
            }
            view.DisplayLineBreak();
        }


        public bool verifVictoire(char c)
        {
            for (int i = 0; i < 3; i++)
            {
                if (grille[i, 0] == c && grille[i, 1] == c && grille[i, 2] == c)
                    return true;
            }
            for (int i = 0; i < 3; i++)
            {
                if (grille[0, i] == c && grille[1, i] == c && grille[2, i] == c)
                    return true;
            }
            if (grille[0, 0] == c && grille[1, 1] == c && grille[2, 2] == c)
                return true;
            if (grille[0, 2] == c && grille[1, 1] == c && grille[2, 0] == c)
                return true;

            return false;
        }


        public bool verifEgalite()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grille[i, j] == ' ')
                        return false;
                }
            }
            return true;
        }



        public void finPartie(string msg)
        {
            view.ClearScreen();
            affichePlateau(grille);
            view.DisplayLineBreakMessage(msg);
        }
    }
}
