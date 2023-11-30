using System.Collections.Generic;
using System.Text;

public class Facture : IFacturePrintable
{
    // a. Attributs
    private static int numeroFactureAutoIncrement = 1;
    private int numeroFacture;
    private DateTime dateFacture;
    private List<Achat> achats;

    // b. Constructeurs par défaut et d'initialisation
    public Facture(int numeroFacture, DateTime dateTime)
    {
        this.numeroFacture = numeroFactureAutoIncrement++;
        this.dateFacture = DateTime.Now;
        this.achats = new List<Achat>();
    }

    public int GetNumeroFacture()
    {
        return numeroFacture;
    }

    public DateTime GetDateFacture()
    {
        return dateFacture;
    }

    // c. Méthode Ajouter(Achat a)
    public void Ajouter(Achat a)
    {
        // Vérifier la non-existence du même achat dans la collection
        if (achats.Any(achat => achat.Equals(a)))
        {
            Console.WriteLine("Erreur : Cet achat existe déjà dans la facture.");
        }
        else
        {
            achats.Add(a);
        }
    }

    // d. Méthode Montant_facture()
    public double MontantFacture()
    {
        return achats.Sum(achat => achat.Article.GetPrix() * achat.Quantite);
    }

    // e. Méthode EnregistrerAchats(string nom_fichier)
    public void EnregistrerAchats(string nomFichier)
    {
        // Trier les achats par désignation
        List<Achat> achatsTries = achats.OrderBy(achat => achat.Article.GetDesignation()).ToList();

        // Enregistrer dans un fichier binaire
        using (FileStream fs = new FileStream(nomFichier, FileMode.Create))
        {
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                foreach (Achat achat in achatsTries)
                {
                    writer.Write(achat.Article.GetDesignation());
                    writer.Write(achat.Article.GetPrix());
                    writer.Write(achat.Quantite);
                }
            }
        }
    }

    // f. Méthode ToString()
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Numéro facture...... {numeroFacture}");
        sb.AppendLine($"Date facture {dateFacture.ToString("dd/MM/yyyy")}");
        sb.AppendLine("Liste des achats : ");

        foreach (Achat achat in achats)
        {
            double prixTotal = achat.Article.GetPrix() * achat.Quantite;
            string designation = achat.Article.GetDesignation();
            string prixInfo = $"Prix : {achat.Article.GetPrix()}";
            string quantiteInfo = $"Quantité : {achat.Quantite}";
            string prixTotalInfo = $"Prix total : {prixTotal}";

            // Check if the article is of type ArticleEnSolde
            if (achat.Article is ArticleEnSolde)
            {
                // Include remise information
                double remise = ((ArticleEnSolde)achat.Article).GetRemise();
                string remiseInfo = $"Remise : {remise}%";
                sb.AppendLine($"{designation}, {prixInfo}, {quantiteInfo}, {remiseInfo}, {prixTotalInfo}");
            }
            else
            {
                sb.AppendLine($"{designation}, {prixInfo}, {quantiteInfo}, {prixTotalInfo}");
            }
        }

        sb.AppendLine($"Montant de la facture : {MontantFacture()}");
        return sb.ToString();
    }
}

