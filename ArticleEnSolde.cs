public class ArticleEnSolde : Article
{
    // Attribut additionnel pour les articles en solde
    private double remise;

    // b. Constructeurs par défaut et d'initialisation
    public ArticleEnSolde(int code, string designation, double prix, string categorie, double remise) : base(code, designation, prix, categorie)
    {
        this.remise = remise;
    }

    // c. Redéfinir la méthode getPrix() pour tenir compte de la remise
    public override double GetPrix()
    {
        return prix - (prix * remise / 100);
    }

    // Methode GetRemise
    public double GetRemise()
    {
        return this.remise;
    }

}
