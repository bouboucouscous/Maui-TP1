namespace Maui_TP1.Views;

public partial class vPhone : ContentPage
{
    public vPhone()
    {
        InitializeComponent();
        Routing.RegisterRoute($"{nameof(vEcran)}", typeof(vEcran));
        Routing.RegisterRoute($"{nameof(vBatterie)}", typeof(vBatterie));
        Phone_Info();
    }

    public void Phone_Info()
    {
        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        stringBuilder.AppendLine($"Modèle: {DeviceInfo.Current.Model}");
        stringBuilder.AppendLine($"Manufacturer: {DeviceInfo.Current.Manufacturer}");
        stringBuilder.AppendLine($"Name: {DeviceInfo.Current.Name}");
        stringBuilder.AppendLine($"VersionString: {DeviceInfo.Current.VersionString}");
        stringBuilder.AppendLine($"Platform: {DeviceInfo.Current.Platform.ToString()}");
        lbPhoneInfo.Text = stringBuilder.ToString();
    }

    public string Get_Idiom()
    {
        return
            DeviceInfo.Current.Idiom == DeviceIdiom.Phone ? "Téléphone " :
            DeviceInfo.Current.Idiom == DeviceIdiom.Tablet ? "Tablette" :
            DeviceInfo.Current.Idiom == DeviceIdiom.Desktop ? "PC" : "not found";
    }

    private async void Ecran_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(vEcran));
    }

    private async void Baterrie_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(vBatterie));
    }
}