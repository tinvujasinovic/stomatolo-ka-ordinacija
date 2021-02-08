namespace Services.RadnoVrijeme
{
    public interface IRadnoVrijemeService
    {
        Model.RadnoVrijeme GetRadnoVrijeme();
        bool SaveRadnoVrijeme(Model.RadnoVrijeme model);
    }
}
