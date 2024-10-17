namespace Maui_TP1;

public partial class NewPage1 : ContentPage
{
    public NewPage1()
    {
        InitializeComponent();
    }

    private async void APropos_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://www.3il-ingenieurs.fr/");
    }
}