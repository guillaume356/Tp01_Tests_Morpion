using MorpionApp.Interfaces;
using System;

namespace MorpionApp
{
    public abstract class Jeu
    {
        protected IGameView gameView;
        protected IGrille grilleJeu;
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;
        protected Joueur joueur1;
        protected Joueur joueur2;
        protected Joueur joueurActuel;

        protected Jeu(IGameView gameView, int lignes, int colonnes)
        {
            this.gameView = gameView;
            this.grilleJeu = new Grille(lignes, colonnes);
            joueur1 = JoueurFactory.CreerJoueur('X', "Joueur 1");
            joueur2 = JoueurFactory.CreerJoueur('O', "Joueur 2");
            joueurActuel = joueur1;
        }

        public void BoucleJeu()
        {
            while (!quiterJeu)
            {
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
                    gameView.DisplayLineBreakMessage("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                GetKey:
                    switch (gameView.GetUserInput())
                    {
                        case ConsoleKey.Enter:
                            break;
                        case ConsoleKey.Escape:
                            quiterJeu = true;
                            gameView.ClearScreen();
                            break;
                        default:
                            goto GetKey;
                    }
                }

            }
        }

        protected abstract void TourJoueur(char joueur);

        protected void affichePlateau()
        {
            int lignes = grilleJeu.Lignes;
            int colonnes = grilleJeu.Colonnes;

            gameView.Display(" ");
            for (int j = 0; j < colonnes; j++)
            {
                gameView.Display($"  {j} ");
            }
            gameView.DisplayLineBreak();

            for (int i = 0; i < lignes; i++)
            {
                gameView.Display($"{i}");
                for (int j = 0; j < colonnes; j++)
                {
                    gameView.Display($" | {grilleJeu.GetValeurCase(i, j)}");
                }
                gameView.DisplayLineBreakMessage(" |");
                if (i < lignes - 1)
                {
                    gameView.Display("  ");
                    for (int j = 0; j < colonnes; j++)
                    {
                        gameView.Display("---+");
                    }
                    gameView.DisplayLineBreak();
                }
            }
            gameView.DisplayLineBreak();
        }

        protected abstract bool verifVictoire(char c);

        protected bool verifEgalite()
        {
            int lignes = grilleJeu.Lignes;
            int colonnes = grilleJeu.Colonnes;

            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < colonnes; j++)
                {
                    if (grilleJeu.GetValeurCase(i, j) == ' ')
                        return false;
                }
            }
            return true;
        }

        protected void finPartie(string msg)
        {
            gameView.ClearScreen();
            affichePlateau();
            gameView.DisplayLineBreakMessage(msg);
        }
    }
}
