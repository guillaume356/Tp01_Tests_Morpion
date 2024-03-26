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

        public static double CalculerCoutTotal(Credit credit)
        {
            double mensualite = CalculerMensualite(credit);
            double coutTotal = mensualite * credit.DureeMois;
            return coutTotal;
        }

        public static List<Mensualite> GenererPlanAmortissement(Credit credit)
        {
            List<Mensualite> planAmortissement = new List<Mensualite>();
            double capitalRestant = credit.MontantEmprunte;
            double tauxMensuel = credit.TauxNominal / 12 / 100;
            double mensualite = CalculerMensualite(credit);

            for (int i = 1; i <= credit.DureeMois; i++)
            {
                double interets = capitalRestant * tauxMensuel;
                double capitalRembourse = mensualite - interets;

                if (capitalRestant < mensualite)
                {
                    capitalRembourse = capitalRestant;
                    mensualite = capitalRembourse + interets;
                }

                capitalRestant -= capitalRembourse;

                if (capitalRestant < 0) capitalRestant = 0;

                planAmortissement.Add(new Mensualite(i, capitalRembourse, capitalRestant));
            }


            return planAmortissement;
        }




    }

}
