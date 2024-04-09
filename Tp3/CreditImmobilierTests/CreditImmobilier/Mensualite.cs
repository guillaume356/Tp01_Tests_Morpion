

namespace CreditImmobilier
{
    public class Mensualite
    {
        public int Numero { get; }
        public double CapitalRembourse { get; }
        public double CapitalRestantDu { get; }
        public double Interet { get; }
        public double MensualiteTotal { get; }

        public Mensualite(int numero, double capitalRembourse, double capitalRestantDu, double interet, double mensualiteTotal)
        {
            Numero = numero;
            CapitalRembourse = capitalRembourse;
            CapitalRestantDu = capitalRestantDu;
            Interet = interet;
            MensualiteTotal = mensualiteTotal;
        }
    }

}
