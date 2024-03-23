using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditImmobilier
{
    public class InterfaceUtilisateur
    {
        private readonly IConsole console;

        public InterfaceUtilisateur(IConsole console)
        {
            this.console = console;
        }

        public void AfficheMessageBienvenue()
        {
            console.WriteLine("Bonjour, Bienvenue dans votre simulateur de crédit immobilier :) Veuillez entrer le montant que vous souhaitez emprunter");
        }
    }
}
