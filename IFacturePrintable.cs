public interface IFacturePrintable
{
    int GetNumeroFacture();

    DateTime GetDateFacture();

    void Ajouter(Achat a);

    double MontantFacture();

    void EnregistrerAchats(string nomFichier);

    string ToString();
}
