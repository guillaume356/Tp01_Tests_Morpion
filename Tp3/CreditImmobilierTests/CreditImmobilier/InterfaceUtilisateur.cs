﻿
using System.Globalization;

namespace CreditImmobilier
{
    public class InterfaceUtilisateur
    {
        private readonly IConsole console;

        public InterfaceUtilisateur(IConsole console)
        {
            this.console = console;
        }

        public static bool VerifierArguments(string[] args)
        {
            return args.Length == 3;
        }

        public static bool SontdesNombreValide(string[] args)
        {
            var culture = CultureInfo.InvariantCulture;
            foreach (var arg in args)
            {
                if (!double.TryParse(arg, NumberStyles.Any, culture, out double number) || number < 0)
                {
                    return false;
                }
            }
            return true;
        }


    }
}
