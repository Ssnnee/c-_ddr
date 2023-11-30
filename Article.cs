
public class Article
{
    // a. Attributs
    protected int code;
    protected string designation;
    protected double prix;
    protected string categorie;

    // b. Accesseur pour l'attribut catégorie
    public string Categorie
    {
        get { return categorie; }
        set
        {
            if (value.ToLower() == "informatique" || value.ToLower() == "bureautique")
                categorie = value;
            else
                throw new CategorieInvalideException();
        }
    }

    // c. Constructeur par défaut et d'initialisation
    public Article(int code, string designation, double prix, string categorie)
    {
        this.code = code;
        this.designation = designation;
        this.prix = prix;
        this.categorie = categorie;
    }

    // d. Méthode virtuelle getPrix()
    public virtual double GetPrix()
    {
        return prix;
    }

    // e. Méthode setPrix(double)
    public void SetPrix(double nouveauPrix)
    {
        prix = nouveauPrix;
    }

    // Methode getDesignation()
    public string GetDesignation()
    {
        return designation;
    }


    // f. Méthode toString()
    public override string ToString()
    {
        return $"{code};{designation};{prix};{categorie}";
    }

    // g. Méthode Equals()
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Article otherArticle = (Article)obj;
        return code == otherArticle.code &&
               designation == otherArticle.designation &&
               prix == otherArticle.prix &&
               categorie == otherArticle.categorie;
    }



    // h. Méthode GetHashCode()
    public override int GetHashCode()
    {
        return code.GetHashCode() ^ designation.GetHashCode() ^ prix.GetHashCode() ^ categorie.GetHashCode();
    }

    // h. Exception CatégorieInvalide
    public class CategorieInvalideException : Exception
    {
        public CategorieInvalideException() : base("Catégorie invalide. Elle doit être 'Informatique' ou 'Bureautique'.")
        {
        }
    }
}

