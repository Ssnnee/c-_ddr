using static Article;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            Article article1 = new Article(1, "Ordinateur", 1000.0, "Informatique");
            Article article2 = new Article(2, "Imprimante", 200.0, "Informatique");
            Article article3 = new Article(3, "Téléviseur", 500.0, "bureautique");
            Article article4 = new Article(4, "Téléphone", 300.0, "bureautique");
            Article article5 = new Article(5, "Livre", 20.0, "informatique");
            Article article6 = new Article(6, "Cahier", 5.0, "bureautique");
            Article article7 = new Article(7, "Stylo", 2.0, "bureautique");
            Article article8 = new Article(8, "Crayon", 1.0, "bureautique");
            Article article9 = new Article(9, "Gomme", 1.0, "bureautique");
            Article article10 = new Article(10, "Trousse", 5.0, "bureautique");
            ArticleEnSolde articleEnsode1 = new ArticleEnSolde(23, "Stylet", 2, "informatique", 0.8);

            Achat achat1 = new Achat(article1, 2);
            Achat achat2 = new Achat(article2, 1);
            Achat achat3 = new Achat(article3, 1);
            Achat achat4 = new Achat(article4, 1);
            Achat achat5 = new Achat(article5, 3);
            Achat achat6 = new Achat(article6, 5);
            Achat achat7 = new Achat(article7, 10);
            Achat achat8 = new Achat(article8, 10);
            Achat achat9 = new Achat(article9, 10);
            Achat achat10 = new Achat(article10, 5);
            Achat achat12 = new Achat(articleEnsode1, 3);

            Facture facture1 = new Facture(1, DateTime.Now);
            facture1.Ajouter(achat1);
            facture1.Ajouter(achat2);
            facture1.Ajouter(achat3);
            facture1.Ajouter(achat4);
            facture1.Ajouter(achat5);
            facture1.Ajouter(achat12);

            Facture facture2 = new Facture(2, DateTime.Now);
            facture2.Ajouter(achat6);
            facture2.Ajouter(achat7);
            facture2.Ajouter(achat8);
            facture2.Ajouter(achat9);
            facture2.Ajouter(achat10);

            // Call the ToString() method of facture1 and facture2
            Console.WriteLine(facture1.ToString());
            Console.WriteLine(facture2.ToString());

            // Try the Méthode Equals()
            if (facture1.Equals(facture2))
                Console.WriteLine("Les deux articles sont identiques.");
            else
                Console.WriteLine("Les deux articles sont différents.");

            // Try Exception CatégorieInvalide
            try
            {
                Article article11 = new Article(11, "Ordinateur", 1000.0, "jsdhksdksd");
            }
            catch (CategorieInvalideException e)
            {
                Console.WriteLine("The error "+ e.Message);
            }

            // Try Méthode Enregistrer_Achats(string nom_fichier)
            facture1.EnregistrerAchats("facture1.txt");


        }
    }
}
