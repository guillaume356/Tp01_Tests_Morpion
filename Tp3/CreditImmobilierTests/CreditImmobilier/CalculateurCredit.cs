

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
            double mensualiteCalculee = CalculerMensualite(credit);

            for (int mois = 1; mois <= credit.DureeMois; mois++)
            {
                double interetPourLeMois = capitalRestant * tauxMensuel;
                double capitalRemboursePourLeMois = mensualiteCalculee - interetPourLeMois;

                // Ajustement pour la dernière mensualité
                if (mois == credit.DureeMois)
                {
                    capitalRemboursePourLeMois += capitalRestant - capitalRemboursePourLeMois;
                }

                capitalRestant -= capitalRemboursePourLeMois;

                // Ajout de la sécurité pour éviter un capital restant négatif
                if (capitalRestant < 0)
                {
                    capitalRestant = 0;
                }

                planAmortissement.Add(new Mensualite(
                    mois,
                    capitalRemboursePourLeMois,
                    capitalRestant,
                    interetPourLeMois,
                    mensualiteCalculee
                ));

                // Si le capital restant atteint 0, inutile de continuer
                if (capitalRestant == 0) break;
            }

            return planAmortissement;
        }






    }

}
