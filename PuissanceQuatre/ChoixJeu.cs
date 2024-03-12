using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::MorpionApp.Interfaces;
using System;

    namespace MorpionApp
    {
        public class ChoixJeu : IChoixJeu
        {
            private IGameView gameView = new ConsoleGameView();

            public void LancerSelectionJeu()
            {

                bool quitter = false;
                while (!quitter)
                {
                    gameView.ClearScreen();
                    gameView.DisplayLineBreakMessage("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4. Taper [Echap] pour quitter.");

                    var key = gameView.GetUserInput();
                    switch (key)
                    {
                        case ConsoleKey.X:
                            var morpion = new Morpion(gameView);
                            morpion.BoucleJeu();
                            break;
                        case ConsoleKey.P:
                            var puissanceQuatre = new PuissanceQuatre(gameView);
                            puissanceQuatre.BoucleJeu();
                            break;
                        case ConsoleKey.Escape:
                            quitter = true;
                            break;
                        default:
                            continue;
                
                }
            }
        }
    }

}
