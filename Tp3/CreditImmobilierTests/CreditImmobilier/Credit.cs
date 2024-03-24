using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
