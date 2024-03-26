using CreditImmobilier;
using System.Globalization;

public class InputHandler
{
    private readonly string[] args;
    private const double MONTANT_MIN = 50000;
    private const int DUREE_MIN = 108;
    private const int DUREE_MAX = 300;


    public InputHandler(string[] args)
    {
        this.args = args;

        if (!InterfaceUtilisateur.VerifierArguments(args))
        {
            throw new ArgumentException("Nombre d'arguments incorrect. Veuillez fournir exactement 3 arguments.");
        }
        if (!InterfaceUtilisateur.SontdesNombreValide(args))
        {
            throw new ArgumentException("Un ou plusieurs arguments ne sont pas des nombres valides.");
        }
    }

    private double GetInput(int index)
    {
        {
            if (index < args.Length && double.TryParse(args[index], NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }

            throw new ArgumentException($"L'argument à l'index {index} n'est pas un nombre valide.");
        }
    }

    public double InputMontant()
    {
        double montant = GetInput(0);

        if (montant < MONTANT_MIN)
        {
            throw new ArgumentException($"Le montant doit être d'au moins {MONTANT_MIN}€.");
        }

        return montant;
    }

    public int InputDuree()
    {
        double dureeDouble = GetInput(1);
        int duree = (int)dureeDouble; 

        if (duree < DUREE_MIN || duree > DUREE_MAX)
        {
            throw new ArgumentException($"La durée doit être comprise entre {DUREE_MIN} et {DUREE_MAX} mois.");
        }

        return duree;
    }
}
