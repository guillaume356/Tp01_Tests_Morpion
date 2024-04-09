

namespace CreditImmobilier
{
    public class Credit
    {
        public double MontantEmprunte { get; }
        public int DureeMois { get; }
        public double TauxNominal { get; }

        public Credit(double montantEmprunte, int dureeMois, double tauxNominal)
        {
            MontantEmprunte = montantEmprunte;
            DureeMois = dureeMois;
            TauxNominal = tauxNominal;
        }
    }


}
