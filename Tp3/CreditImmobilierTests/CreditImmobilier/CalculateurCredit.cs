using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditImmobilier
{
    static public class CalculateurCredit
    {
        public static double CalculerMensualite(Credit credit)
        {
            double tauxMensuel = credit.TauxNominal / 12 / 100;
            double denominateur = 1 - Math.Pow(1 + tauxMensuel, -credit.DureeMois);
            double mensualite = (credit.MontantEmprunte * tauxMensuel) / denominateur;
            return Math.Round(mensualite, 2);

        }

    }

}
