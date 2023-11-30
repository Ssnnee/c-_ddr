public class Achat
{
    // Attributs
    private Article article;
    private int quantite;

    // Propriétés
    public Article Article
    {
        get { return article; }
        set { article = value; }
    }

    public int Quantite
    {
        get { return quantite; }
        set { quantite = value; }
    }

    // Constructeurs
    public Achat()
    {
        article = new Article(0, "", 0.0, "");
        quantite = 0;
    }

    public Achat(Article article, int quantite)
    {
        this.article = article;
        this.quantite = quantite;
    }


    // Méthode ToString()
    public override string ToString()
    {
        return $"{article};{quantite}";
    }
}
