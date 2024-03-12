using MorpionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Morpion : Jeu
    {

        public Morpion(IGameView gameView) : base(gameView, 3, 3)
        {
            joueur1 = JoueurFactory.CreerJoueur('X', "Joueur 1");
            joueur2 = JoueurFactory.CreerJoueur('O', "Joueur 2");
            joueurActuel = joueur1; 
        }


        protected override void TourJoueur(char joueur)
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                gameView.ClearScreen();
                affichePlateau();
                gameView.DisplayLineBreakMessage($"Joueur {joueurActuel.Nom}, choisir une case valide et appuyer sur [Entrer]");
                int cursorLeft = (column * 4) + 2;
                int cursorTop = (row * 2) + 1;

                gameView.SetCursorPosition(cursorLeft, cursorTop);

                var key = gameView.GetUserInput();
                switch (key)
                {
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        gameView.ClearScreen();
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
                        if (grilleJeu.GetValeurCase(row, column) == ' ')
                        {
                            grilleJeu.SetValeurCase(row, column, joueurActuel.Symbole);
                            moved = true;
                            joueurActuel = joueurActuel == joueur1 ? joueur2 : joueur1;
                        }
                        break;
                }
            }
        }



        protected override bool verifVictoire(char c)
        {
            for (int i = 0; i < 3; i++)
            {
                if (grilleJeu.GetValeurCase(i, 0) == c && grilleJeu.GetValeurCase(i, 1) == c && grilleJeu.GetValeurCase(i, 2) == c)
                    return true;
            }
            for (int i = 0; i < 3; i++)
            {
                if (grilleJeu.GetValeurCase(0, i) == c && grilleJeu.GetValeurCase(1, i) == c && grilleJeu.GetValeurCase(2, i) == c)
                    return true;
            }
            if (grilleJeu.GetValeurCase(0, 0) == c && grilleJeu.GetValeurCase(1, 1) == c && grilleJeu.GetValeurCase(2, 2) == c)
                return true;
            if (grilleJeu.GetValeurCase(0, 2) == c && grilleJeu.GetValeurCase(1, 1) == c && grilleJeu.GetValeurCase(2, 0) == c)
                return true;

            return false;
        }
    }
}
