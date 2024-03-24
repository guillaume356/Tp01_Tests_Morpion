using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditImmobilier
{
    public class Mensualite
    {
        public int Numero { get; }
        public double CapitalRembourse { get; }
        public double CapitalRestantDu { get; }

        public Mensualite(int numero, double capitalRembourse, double capitalRestantDu)
        {
            Numero = numero;
            CapitalRembourse = capitalRembourse;
            CapitalRestantDu = capitalRestantDu;
        }
    }
}
