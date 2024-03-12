using System;

namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gameView = new ConsoleGameView();

            bool continuePlaying = true;
            while (continuePlaying)
            {
                gameView.DisplayLineBreakMessage("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");

                var gameSelected = false;
                while (!gameSelected)
                {
                    switch (gameView.GetUserInput())
                    {
                        case ConsoleKey.X:
                            var morpion = new Morpion(gameView);
                            morpion.BoucleJeu();
                            gameSelected = true;
                            break;
                        case ConsoleKey.P:
                            var puissanceQuatre = new PuissanceQuatre(gameView);
                            puissanceQuatre.BoucleJeu();
                            gameSelected = true;
                            break;
                    }
                }

                gameView.DisplayLineBreakMessage("Jouer à un autre jeu ? Taper [R] pour changer de jeu. Taper [Echap] pour quitter.");

                var quitSelected = false;
                while (!quitSelected)
                {
                    switch (gameView.GetUserInput())
                    {
                        case ConsoleKey.R:
                            quitSelected = true;
                            break;
                        case ConsoleKey.Escape:
                            continuePlaying = false;
                            quitSelected = true;
                            break;
                    }
                }
            }
        }
    }
}
