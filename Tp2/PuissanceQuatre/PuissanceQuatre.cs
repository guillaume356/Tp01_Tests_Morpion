using MorpionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class PuissanceQuatre : Jeu  
    {

        public PuissanceQuatre(IGameView gameView) : base(gameView, 4, 7)
        {
            joueur1 = JoueurFactory.CreerJoueur('X', "Joueur 1");
            joueur2 = JoueurFactory.CreerJoueur('O', "Joueur 2");
            joueurActuel = joueur1;
        }
        

        protected override void TourJoueur(char joueur)
        {
            int column = 0;
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                gameView.ClearScreen();
                affichePlateau();
                gameView.DisplayLineBreak();
                gameView.DisplayLineBreakMessage($"Joueur {joueurActuel.Nom}, choisissez une colonne et appuyez sur [Entrer]");
                int cursorLeft = column * 4 + 4;
                int cursorTop = grilleJeu.Lignes * 2;

                gameView.SetCursorPosition(cursorLeft, cursorTop);

                var key = gameView.GetUserInput();
                switch (key)
                {
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        gameView.ClearScreen();
                        return;

                    case ConsoleKey.RightArrow:
                        column = column >= 6 ? 0 : column + 1;
                        break;

                    case ConsoleKey.LeftArrow:
                        column = column <= 0 ? 6 : column - 1;
                        break;

                    case ConsoleKey.Enter:
                        for (int row = grilleJeu.Lignes - 1; row >= 0; row--)
                        {
                            if (grilleJeu.GetValeurCase(row, column) == ' ')
                            {
                                grilleJeu.SetValeurCase(row, column, joueurActuel.Symbole);
                                moved = true;
                                joueurActuel = joueurActuel == joueur1 ? joueur2 : joueur1;
                                break;
                            }
                        }
                        if (!moved)
                        {
                            gameView.DisplayLineBreakMessage("Colonne pleine. Choisissez une autre colonne.");
                            gameView.GetUserInput();
                        }
                        break;
                }
            }
        }

        protected override bool verifVictoire(char c)
        {
            int lignes = grilleJeu.Lignes;
            int colonnes = grilleJeu.Colonnes;

            
            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j <= colonnes - 4; j++)
                {
                    if (grilleJeu.GetValeurCase(i, j) == c && grilleJeu.GetValeurCase(i, j + 1) == c && grilleJeu.GetValeurCase(i, j + 2) == c && grilleJeu.GetValeurCase(i, j + 3) == c)
                        return true;
                }
            }
            for (int i = 0; i <= lignes - 4; i++)
            {
                for (int j = 0; j < colonnes; j++)
                {
                    if (grilleJeu.GetValeurCase(i, j) == c && grilleJeu.GetValeurCase(i + 1, j) == c && grilleJeu.GetValeurCase(i + 2, j) == c && grilleJeu.GetValeurCase(i + 3, j) == c)
                        return true;
                }
            }
            for (int i = 0; i <= lignes - 4; i++)
            {
                for (int j = 0; j <= colonnes - 4; j++)
                {
                    if (grilleJeu.GetValeurCase(i, j) == c && grilleJeu.GetValeurCase(i + 1, j + 1) == c && grilleJeu.GetValeurCase(i + 2, j + 2) == c && grilleJeu.GetValeurCase(i + 3, j + 3) == c)
                        return true;
                    if (j >= 3 && grilleJeu.GetValeurCase(i, j) == c && grilleJeu.GetValeurCase(i + 1, j - 1) == c && grilleJeu.GetValeurCase(i + 2, j - 2) == c && grilleJeu.GetValeurCase(i + 3, j - 3) == c)
                        return true;
                }
            }

            return false;
        }

    }
}
